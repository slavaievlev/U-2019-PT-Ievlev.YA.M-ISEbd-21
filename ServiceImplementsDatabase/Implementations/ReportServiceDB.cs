using Microsoft.Office.Interop.Word;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data.Entity.SqlServer;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ServiceImplementsDatabase.Implementations
{
    public class ReportServiceDB : IReportService
    {
        private readonly AbstractDbContext context;

        public ReportServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<ClientOrdersModel> GetClientOrders(ReportBindingModel model)
        {
            return context.Orders
                .Include(rec => rec.Customer)
                .Include(rec => rec.Work)
            .Where(rec => rec.DateCreate >= model.DateFrom &&
                rec.DateCreate <= model.DateTo)
            .Select(rec => new ClientOrdersModel
            {
                 ClientName = rec.Customer.CustomerFIO,
                 DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " + 
                    SqlFunctions.DateName("mm", rec.DateCreate) + " " + SqlFunctions.DateName("yyyy", rec.DateCreate),
                 ProductName = rec.Work.WorkName,
                 Count = rec.Count,
                 Sum = rec.Sum,
                 Status = rec.Status.ToString()
             })
            .ToList();
        }

        public List<StocksLoadViewModel> GetStocksLoad()
        {
            return context.Stocks
                .ToList()
                .GroupJoin(
                    context.StockMaterials
                        .Include(r => r.Material)
                        .ToList(),
                    stock => stock,
                    stockMaterial => stockMaterial.Stock,
                    (stock, stockMaterialList) =>
             new StocksLoadViewModel
             {
                 StockName = stock.StockName,
                 TotalCount = stockMaterialList.Sum(r => r.Count),
                 Components = stockMaterialList.Select(r => new Tuple<string,int>(
                     r.Material.MaterialName, r.Count))
             })
             .ToList();
        }

        public void SaveClientOrders(ReportBindingModel model)
        {
            // Из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }

            // Открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            
            // Создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            
            // Вставляем заголовок
            var phraseTitle = new Phrase("Заказы клиентов",
            new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER, SpacingAfter = 12
            };
            doc.Add(paragraph);
            var phrasePeriod = new Phrase("c " + model.DateFrom.Value.ToShortDateString() + 
                " по " + model.DateTo.Value.ToShortDateString(), new iTextSharp.text.Font(
                    baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phrasePeriod)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);
            
            // Вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(6)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160, 100, 100, 140 });
            
            // Вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase("ФИО клиента", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            table.AddCell(new PdfPCell(new Phrase("Дата создания", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            table.AddCell(new PdfPCell(new Phrase("Изделие", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            table.AddCell(new PdfPCell(new Phrase("Количество", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            table.AddCell(new PdfPCell(new Phrase("Сумма", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            table.AddCell(new PdfPCell(new Phrase("Статус", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            
            // Заполняем таблицу
            var list = GetClientOrders(model);
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.Count; i++)
            {
                cell = new PdfPCell(new Phrase(list[i].ClientName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].DateCreate, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].ProductName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Count.ToString(), fontForCells));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);
            cell = new PdfPCell(new Phrase(list[i].Sum.ToString(), fontForCells));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Status, fontForCells));
                table.AddCell(cell);
            }

            // Вставляем итого
            cell = new PdfPCell(new Phrase("Итого:", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Colspan = 4,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(list.Sum(rec => rec.Sum).ToString(), fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("", fontForCellBold))
            {
                Border = 0
            };
            table.AddCell(cell);
            
            // Вставляем таблицу
            doc.Add(table);
            doc.Close();
        }

        public void SaveProductPrice(ReportBindingModel model)
        {
            if (File.Exists(model.FileName))
            {
                File.Delete(model.FileName);
            }
            
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;

                // Создаем документ
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(
                    ref missing, ref missing, ref missing, ref missing);

                // Получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;

                // Задаем текст
                range.Text = "Прайс изделий";

                // Задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;

                // Задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;

                // Добавляем абзац в документ
                range.InsertParagraphAfter();

                var works = context.Works.ToList();

                // Создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, works.Count, 2, ref missing, ref missing);

                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;

                for (int i = 0; i < works.Count; i++)
                {
                    table.Cell(i + 1, 1).Range.Text = works[i].WorkName;
                    table.Cell(i + 1, 2).Range.Text = works[i].Price.ToString();
                }

                // Задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;

                range.Text = "Дата: " + DateTime.Now.ToLongDateString();

                font = range.Font;
                font.Size = 12;
                font.Name = "Times New Roman";

                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;

                range.InsertParagraphAfter();

                // Сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(model.FileName, ref fileFormat, ref missing, ref missing, 
                    ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref missing, ref missing);

                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }

        public void SaveStocksLoad(ReportBindingModel model)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                // Или создаем excel-файл, или открываем существующий
                if (File.Exists(model.FileName))
                {
                    excel.Workbooks.Open(model.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing,Type.Missing,Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(model.FileName, XlFileFormat.xlExcel8, Type.Missing, Type.Missing, 
                        false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing);
                }
                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                
                // Получаем ссылку на лист
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                
                // Очищаем ячейки
                excelworksheet.Cells.Clear();
                
                // Настройки страницы
                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;
                
                // Получаем ссылку на первые 3 ячейки
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "C1");
                
                // Объединяем их
                excelcells.Merge(Type.Missing);
                
                // Задаем текст, настройки шрифта и ячейки
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Загруженность складов";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;
                excelcells = excelworksheet.get_Range("A2", "C2");
                excelcells.Merge(Type.Missing);
                excelcells.Value2 = "на" + DateTime.Now.ToShortDateString();
                excelcells.RowHeight = 20;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;
                var dict = GetStocksLoad();

                if (dict != null)
                {
                    excelcells = excelworksheet.get_Range("C1", "C1");
                    foreach (var elem in dict)
                    {
                        // Спускаемся на 2 ячейку вниз и 2 ячейкт влево
                        excelcells = excelcells.get_Offset(2, -2);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = elem.StockName;
                        excelcells = excelcells.get_Offset(1, 1);
                        
                        // Обводим границы
                        if (elem.Components.Count() > 0)
                        {
                            // Получаем ячейкт для выбеления рамки под таблицу
                            var excelBorder =
                            excelworksheet.get_Range(excelcells,
                            excelcells.get_Offset(elem.Components.Count() - 1, 1));
                            excelBorder.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelBorder.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            excelBorder.HorizontalAlignment = Constants.xlCenter;
                            excelBorder.VerticalAlignment = Constants.xlCenter;

                            excelBorder.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,

                            Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
                            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                            foreach (var listElem in elem.Components)
                            {
                                excelcells.Value2 = listElem.Item1;
                                excelcells.ColumnWidth = 10;
                                excelcells.get_Offset(0, 1).Value2 = listElem.Item2;
                                excelcells = excelcells.get_Offset(1, 0);
                            }
                        }

                        excelcells = excelcells.get_Offset(0, -1);
                        excelcells.Value2 = "Итого";
                        excelcells.Font.Bold = true;
                        excelcells = excelcells.get_Offset(0, 2);
                        excelcells.Value2 = elem.TotalCount;
                        excelcells.Font.Bold = true;
                    }
                }
                
                // Сохраняем
                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Закрываем
                excel.Quit();
            }
        }
    }
}
