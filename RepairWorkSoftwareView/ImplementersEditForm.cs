using RepairWorkSoftwareDAL.BindingModel;
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

namespace RepairWorkSoftwareView
{
    public partial class ImplementersEditForm : Form
    {
        public ImplementersEditForm()
        {
            InitializeComponent();
        }

        public int Id { set { id = value; } }

        private int? id;

        private void ImplementerForm_Load(object sernder, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ImplementerViewModel view = APIClient.GetRequest<ImplementerViewModel>("api/Implementer/Get/" + id);
                    if (view != null)
                    {
                        textBoxFIOInput.Text = view.ImplementerFIO;
                    }
                }
                catch (Exception ex)
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
                    APIClient.PostRequest<ImplementerBindingModel, bool>("api/Implementer/UpdElement",
                        new ImplementerBindingModel
                        {
                            Id = id.Value,
                            ImplementerFIO = textBoxFIOInput.Text
                        });
                }
                else
                {
                    APIClient.PostRequest<ImplementerBindingModel, bool>("api/Implementer/AddElement",
                        new ImplementerBindingModel
                        {
                            ImplementerFIO = textBoxFIOInput.Text
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
