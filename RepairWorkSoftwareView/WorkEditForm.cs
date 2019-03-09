using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
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
using Unity;

namespace RepairWorkSoftwareView
{
    public partial class WorkEditForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IWorkService service;

        private int? id;

        private List<MaterialWorkViewModel> workMaterials;

        public WorkEditForm(IWorkService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void WorkEditForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WorkViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxNameInput.Text = view.WorkName;
                        textBoxPriceInput.Text = view.Price.ToString();
                        workMaterials = view.WorkMaterials;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                workMaterials = new List<MaterialWorkViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (workMaterials != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = workMaterials;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<WorkMaterialAddForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.WorkId = id.Value;
                    }
                    workMaterials.Add(form.Model);
                }
                LoadData();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<WorkMaterialAddForm>();
                form.Model = workMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    workMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        workMaterials.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameInput.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPriceInput.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (workMaterials == null || workMaterials.Count == 0)
            {
                MessageBox.Show("Заполните материалы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<MaterialWorkBindingModel> workMaterialBM = new List<MaterialWorkBindingModel>();
                for (int i = 0; i < workMaterials.Count; i++)
                {
                    workMaterialBM.Add(new MaterialWorkBindingModel
                    {
                        Id = workMaterials[i].Id,
                        WorkId = workMaterials[i].WorkId,
                        MaterialId = workMaterials[i].MaterialId,
                        Count = workMaterials[i].Count
                    });
                }

                if (id.HasValue)
                {
                    service.UpdElement(new WorkBindingModel
                    {
                        Id = id.Value,
                        WorkName = textBoxNameInput.Text,
                        Price = Convert.ToInt32(textBoxPriceInput.Text),
                        WorkMaterials = workMaterialBM
                    });
                }
                else
                {
                    service.AddElement(new WorkBindingModel
                    {
                        WorkName = textBoxNameInput.Text,
                        Price = Convert.ToInt32(textBoxPriceInput.Text),
                        WorkMaterials = workMaterialBM
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
