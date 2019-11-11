using System;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class MaterialEditForm : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public MaterialEditForm()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameInput.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (id.HasValue)
                {
                    ApiClient.PostRequest<MaterialBindingModel, bool>("api/Material/UpdElement", new MaterialBindingModel
                    {
                        Id = id.Value,
                        MaterialName = textBoxNameInput.Text
                    });
                }
                else
                {
                    ApiClient.PostRequest<MaterialBindingModel, bool>("api/Material/AddElement", new MaterialBindingModel
                    {
                        MaterialName = textBoxNameInput.Text
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

        private void MaterialEditForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    MaterialViewModel view = ApiClient.GetRequest<MaterialViewModel>("api/Material/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxNameInput.Text = view.MaterialName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
