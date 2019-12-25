using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void ButtonCustomerAdd_Click(object sender, EventArgs e)
        {
            var form = new NewCustomerEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonCustomerEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                var form = new NewCustomerEditForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonCustomerDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        ApiClient.PostRequest<CustomerBindingModel, bool>("api/Customer/DelElement", new CustomerBindingModel
                        {
                            Id = id
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void ButtonCustomerUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CustomerViewModel> list = ApiClient.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
