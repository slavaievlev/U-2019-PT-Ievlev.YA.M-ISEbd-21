using System;
using System.Windows.Forms;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareView
{
    public partial class ImplementerEditForm : Form
    {
        private int? _implementerId;
        
        public int? ImplementerId
        {
            get =>_implementerId;
            set
            {
                _implementerId = value;
                if (_implementerId.HasValue)
                {
                    textBoxName.Text = ApiClient.GetRequest<ImplementerViewModel>("api/Implementer/GetElement/" + 
                                                                                  _implementerId.Value).Fio;
                }
            }
        }

        public ImplementerEditForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string fio = textBoxName.Text;
            ImplementerBindingModel model;
            if (_implementerId.HasValue)
            {
                model = new ImplementerBindingModel
                {
                    Fio = fio,
                    Id = _implementerId.Value
                };
                
                ApiClient.PostRequest<ImplementerBindingModel, bool>("api/Implementer/UpdElement", model);
            }
            else
            {
                model = new ImplementerBindingModel
                {
                    Fio = fio
                };
                
                ApiClient.PostRequest<ImplementerBindingModel, bool>("api/Implementer/AddElement", model);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}