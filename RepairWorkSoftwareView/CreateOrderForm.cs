using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> customerList = ApiClient.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if (customerList != null)
                {
                    comboBoxCustomer.DisplayMember = "CustomerFIO";
                    comboBoxCustomer.ValueMember = "Id";
                    comboBoxCustomer.DataSource = customerList;
                    comboBoxCustomer.SelectedItem = null;
                }

                List<WorkViewModel> workList = ApiClient.GetRequest<List<WorkViewModel>>("api/Work/GetList");
                if (customerList != null)
                {
                    comboBoxWork.DisplayMember = "WorkName";
                    comboBoxWork.ValueMember = "Id";
                    comboBoxWork.DataSource = workList;
                    comboBoxWork.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCountInput.Text))
            {
                MessageBox.Show("Заполните поле \"Количество\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCustomer.SelectedValue == null)
            {
                MessageBox.Show("Заполните поле \"Клиент\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxWork.SelectedValue == null)
            {
                MessageBox.Show("Заполните поле \"Изделие\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ApiClient.PostRequest<OrderBindingModel, bool>("api/Main/CreateOrder" , new OrderBindingModel
                {
                    CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    WorkId = Convert.ToInt32(comboBoxWork.SelectedValue),
                    Count = Convert.ToInt32(textBoxCountInput.Text),
                    Sum = Convert.ToInt32(textBoxSumInput.Text)
                });

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

        private void CalcSum()
        {
            if (comboBoxWork.SelectedValue != null &&
                !string.IsNullOrEmpty(textBoxCountInput.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxWork.SelectedValue);
                    WorkViewModel work = ApiClient.GetRequest<WorkViewModel>("api/Work/Get/" + id);
                    int count = Convert.ToInt32(textBoxCountInput.Text);
                    //textBoxSumInput.Text = (count * work.Price).ToString();
                    int result = Convert.ToInt32(count * work.Price);
                    textBoxSumInput.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCountInput_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
