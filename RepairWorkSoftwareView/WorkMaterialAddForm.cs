using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class WorkMaterialAddForm : Form
    {
        public WorkMaterialViewModel Model { set { model = value; } get { return model; } }

        private WorkMaterialViewModel model;

        public WorkMaterialAddForm()
        {
            InitializeComponent();
        }

        private void WorkMaterialAddForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<MaterialViewModel> list = ApiClient.GetRequest<List<MaterialViewModel>>("api/Material/GetList");
                if (list != null)
                {
                    comboBoxMaterial.DisplayMember = "MaterialName";
                    comboBoxMaterial.ValueMember = "Id";
                    comboBoxMaterial.DataSource = list;
                    comboBoxMaterial.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (model != null)
            {
                comboBoxMaterial.Enabled = false;
                comboBoxMaterial.SelectedValue = model.MaterialId;
                textBoxCountInput.Text = model.Count.ToString();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCountInput.Text))
            {
                MessageBox.Show("Заполните поле \"Количество\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxMaterial.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (model == null)
                {
                    model = new WorkMaterialViewModel
                    {
                        MaterialId = Convert.ToInt32(comboBoxMaterial.SelectedValue),
                        MaterialName = comboBoxMaterial.Text,
                        Count = Convert.ToInt32(textBoxCountInput.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCountInput.Text);
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
