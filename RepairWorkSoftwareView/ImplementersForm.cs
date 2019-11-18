using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class ImplementersForm : Form
    {
        public ImplementersForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var editWindow = new ImplementerEditForm();
            if (editWindow.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                List<ImplementerViewModel> list = ApiClient.GetRequest<List<ImplementerViewModel>>("api/Implementer/GetList");
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var editWindow = new ImplementerEditForm();
                editWindow.ImplementerId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (editWindow.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int implementerId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);   
                ApiClient.PostRequest<ImplementerViewModel, bool>("api/Implementer/DelElement", new ImplementerViewModel
                {
                    Id = implementerId
                });
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}