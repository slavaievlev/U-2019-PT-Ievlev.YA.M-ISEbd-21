namespace RepairWorkSoftwareView
{
    partial class CustomersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCustomerAdd = new System.Windows.Forms.Button();
            this.buttonCustomerEdit = new System.Windows.Forms.Button();
            this.buttonCustomerDelete = new System.Windows.Forms.Button();
            this.buttonCustomerUpdate = new System.Windows.Forms.Button();
            this.customerServiceListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerServiceListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(576, 426);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCustomerAdd
            // 
            this.buttonCustomerAdd.Location = new System.Drawing.Point(630, 36);
            this.buttonCustomerAdd.Name = "buttonCustomerAdd";
            this.buttonCustomerAdd.Size = new System.Drawing.Size(131, 43);
            this.buttonCustomerAdd.TabIndex = 1;
            this.buttonCustomerAdd.Text = "Добавить";
            this.buttonCustomerAdd.UseVisualStyleBackColor = true;
            this.buttonCustomerAdd.Click += new System.EventHandler(this.ButtonCustomerAdd_Click);
            // 
            // buttonCustomerEdit
            // 
            this.buttonCustomerEdit.Location = new System.Drawing.Point(630, 85);
            this.buttonCustomerEdit.Name = "buttonCustomerEdit";
            this.buttonCustomerEdit.Size = new System.Drawing.Size(131, 43);
            this.buttonCustomerEdit.TabIndex = 2;
            this.buttonCustomerEdit.Text = "Изменить";
            this.buttonCustomerEdit.UseVisualStyleBackColor = true;
            this.buttonCustomerEdit.Click += new System.EventHandler(this.ButtonCustomerEdit_Click);
            // 
            // buttonCustomerDelete
            // 
            this.buttonCustomerDelete.Location = new System.Drawing.Point(630, 134);
            this.buttonCustomerDelete.Name = "buttonCustomerDelete";
            this.buttonCustomerDelete.Size = new System.Drawing.Size(131, 43);
            this.buttonCustomerDelete.TabIndex = 3;
            this.buttonCustomerDelete.Text = "Удалить";
            this.buttonCustomerDelete.UseVisualStyleBackColor = true;
            this.buttonCustomerDelete.Click += new System.EventHandler(this.ButtonCustomerDelete_Click);
            // 
            // buttonCustomerUpdate
            // 
            this.buttonCustomerUpdate.Location = new System.Drawing.Point(630, 183);
            this.buttonCustomerUpdate.Name = "buttonCustomerUpdate";
            this.buttonCustomerUpdate.Size = new System.Drawing.Size(131, 43);
            this.buttonCustomerUpdate.TabIndex = 4;
            this.buttonCustomerUpdate.Text = "Обновить";
            this.buttonCustomerUpdate.UseVisualStyleBackColor = true;
            this.buttonCustomerUpdate.Click += new System.EventHandler(this.ButtonCustomerUpdate_Click);
            // 
            // customerServiceListBindingSource
            // 
            this.customerServiceListBindingSource.DataSource = typeof(RepairWorkSoftwareServiceImplementList.CustomerServiceList);
            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCustomerUpdate);
            this.Controls.Add(this.buttonCustomerDelete);
            this.Controls.Add(this.buttonCustomerEdit);
            this.Controls.Add(this.buttonCustomerAdd);
            this.Controls.Add(this.dataGridView);
            this.Name = "CustomersForm";
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.CustomersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerServiceListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCustomerAdd;
        private System.Windows.Forms.Button buttonCustomerEdit;
        private System.Windows.Forms.Button buttonCustomerDelete;
        private System.Windows.Forms.Button buttonCustomerUpdate;
        private System.Windows.Forms.BindingSource customerServiceListBindingSource;
    }
}