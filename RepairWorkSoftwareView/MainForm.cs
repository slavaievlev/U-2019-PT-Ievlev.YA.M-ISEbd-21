using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = ApiClient.GetRequest<List<OrderViewModel>>("api/Main/GetList");
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
            var form = new CustomersForm();
            form.ShowDialog();
        }

        private void КомпонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MaterialsForm();
            form.ShowDialog();
        }

        private void ИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new WorksForm();
            form.ShowDialog();
        }

        private void ButtonOrderAdd_Click(object sender, EventArgs e)
        {
            var form = new CreateOrderForm();
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
                    ApiClient.PostRequest<OrderBindingModel, bool>("api/Main/TakeOrderInWork", new OrderBindingModel
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
                    ApiClient.PostRequest<OrderBindingModel, bool>("api/Main/FinishOrder", new OrderBindingModel
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
                    ApiClient.PostRequest<OrderBindingModel, bool>("api/Main/PayOrder", new OrderBindingModel
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
            var form = new StocksForm();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PutOnStockForm();
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
                    ApiClient.PostRequest<ReportBindingModel, bool>("api/Report/SaveProductPrice", new ReportBindingModel
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

        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new StocksLoadForm();
            form.ShowDialog();
        }

        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CustomersOrdersForm();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ApiClient.PostRequest<int?, bool>("api/Main/StartWork", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ImplementersForm();
            form.ShowDialog();
        }

        private void письмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MailsForm();
            form.ShowDialog();
        }
    }
}
