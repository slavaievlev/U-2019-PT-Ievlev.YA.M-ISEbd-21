using System;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class CustomerEditForm : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public CustomerEditForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sernder, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel view = ApiClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxFIOInput.Text = view.CustomerFIO;
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttomSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIOInput.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (id.HasValue)
                {
                    ApiClient.PostRequest<CustomerBindingModel, bool>("api/Customer/UpdElement", new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerFIO = textBoxFIOInput.Text
                    });
                }
                else
                {
                    ApiClient.PostRequest<CustomerBindingModel, bool>("api/Customer/AddElement", new CustomerBindingModel
                    {
                        CustomerFIO = textBoxFIOInput.Text
                    });
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
