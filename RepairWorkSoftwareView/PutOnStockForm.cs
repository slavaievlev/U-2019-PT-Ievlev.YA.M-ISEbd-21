using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class PutOnStockForm : Form
    {
        public PutOnStockForm()
        {
            InitializeComponent();
        }
        private void FormPutOnStock_Load(object sender, EventArgs e)
        {
            try
            {
                List<MaterialViewModel> materialList = ApiClient.GetRequest<List<MaterialViewModel>>("api/Material/GetList");
                if (materialList != null)
                {
                    comboBoxMaterial.DisplayMember = "MaterialName";
                    comboBoxMaterial.ValueMember = "Id";
                    comboBoxMaterial.DataSource = materialList;
                    comboBoxMaterial.SelectedItem = null;
                }
                List<StockViewModel> stockList = ApiClient.GetRequest<List<StockViewModel>>("api/Stock/GetList");
                if (stockList != null)
                {
                    comboBoxStock.DisplayMember = "StockName";
                    comboBoxStock.ValueMember = "Id";
                    comboBoxStock.DataSource = stockList;
                    comboBoxStock.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCountInscription.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxMaterial.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStock.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                ApiClient.PostRequest<StockMaterialBindingModel, bool>("api/Main/PutMaterialOnStock", new StockMaterialBindingModel
                {
                    MaterialId = Convert.ToInt32(comboBoxMaterial.SelectedValue),
                    StockId = Convert.ToInt32(comboBoxStock.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
