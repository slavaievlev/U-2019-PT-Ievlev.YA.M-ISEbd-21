using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace RepairWorkSoftwareView
{
    public partial class MainForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMainService mainService;
        private readonly IReportService reportService;

        public MainForm(IMainService mainService, IReportService reportService)
        {
            InitializeComponent();
            this.mainService = mainService;
            this.reportService = reportService;
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = mainService.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CustomersForm>();
            form.ShowDialog();
        }

        private void КомпонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<MaterialsForm>();
            form.ShowDialog();
        }

        private void ИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<WorksForm>();
            form.ShowDialog();
        }

        private void ButtonOrderAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CreateOrderForm>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonOrderInProgress_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    mainService.TakeOrderInWork(new OrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonOrderIsReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    mainService.FinishOrder(new OrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonOrderPay_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    mainService.PayOrder(new OrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<StocksForm>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<PutOnStockForm>();
            form.ShowDialog();
        }

        private void прайсИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    reportService.SaveProductPrice(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs
       e)
        {
            var form = Container.Resolve<StocksLoadForm>();
        form.ShowDialog();
        }

        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CustomersOrdersForm>();
            form.ShowDialog();
        }
    }
}
