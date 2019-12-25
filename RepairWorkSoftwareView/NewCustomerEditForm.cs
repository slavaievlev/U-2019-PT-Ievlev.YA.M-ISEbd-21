using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class NewCustomerEditForm : Form
    {
        private int? _id;

        public NewCustomerEditForm()
        {
            InitializeComponent();
        }
        
        public NewCustomerEditForm(int id)
        {
            InitializeComponent();
            this._id = id;

            CustomerForm_Load();
        }

        private void CustomerForm_Load()
        {
            if (!_id.HasValue) return;
            try
            {
                CustomerViewModel customer = ApiClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + _id.Value);
                textBoxFIOInput.Text = customer.CustomerFIO;
                textBoxMailInput.Text = customer.Mail;
                dataGridView.DataSource = customer.Messages;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIOInput.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fio = textBoxFIOInput.Text;
            string mail = textBoxMailInput.Text;
            
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            if (_id.HasValue)
            {
                ApiClient.PostRequest<CustomerBindingModel, bool>("api/Customer/UpdElement", new CustomerBindingModel
                {
                    Id = _id.Value,
                    CustomerFIO = fio,
                    Mail = mail
                });
            }
            else
            {
                ApiClient.PostRequest<CustomerBindingModel, bool>("api/Customer/AddElement", new CustomerBindingModel
                {
                    CustomerFIO = fio,
                    Mail = mail
                });
            }

            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}