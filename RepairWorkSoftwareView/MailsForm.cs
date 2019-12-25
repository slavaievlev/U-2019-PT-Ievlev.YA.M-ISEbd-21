using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class MailsForm : Form
    {
        public MailsForm()
        {
            InitializeComponent();
            FormMails_Load();
        }

        private void FormMails_Load()
        {
            try
            {
                List<MessageInfoViewModel> list =
                    ApiClient.GetRequest<List<MessageInfoViewModel>>("api/MessageInfo/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}