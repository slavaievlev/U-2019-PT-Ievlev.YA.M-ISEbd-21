namespace RepairWorkSoftwareView
{
    partial class MaterialsForm
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
            this.buttonMaterialUpdate = new System.Windows.Forms.Button();
            this.buttonMaterialDelete = new System.Windows.Forms.Button();
            this.buttonMaterialEdit = new System.Windows.Forms.Button();
            this.buttonMaterialAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMaterialUpdate
            // 
            this.buttonMaterialUpdate.Location = new System.Drawing.Point(634, 182);
            this.buttonMaterialUpdate.Name = "buttonMaterialUpdate";
            this.buttonMaterialUpdate.Size = new System.Drawing.Size(131, 43);
            this.buttonMaterialUpdate.TabIndex = 8;
            this.buttonMaterialUpdate.Text = "Обновить";
            this.buttonMaterialUpdate.UseVisualStyleBackColor = true;
            this.buttonMaterialUpdate.Click += new System.EventHandler(this.ButtonMaterialUpdate_Click);
            // 
            // buttonMaterialDelete
            // 
            this.buttonMaterialDelete.Location = new System.Drawing.Point(634, 133);
            this.buttonMaterialDelete.Name = "buttonMaterialDelete";
            this.buttonMaterialDelete.Size = new System.Drawing.Size(131, 43);
            this.buttonMaterialDelete.TabIndex = 7;
            this.buttonMaterialDelete.Text = "Удалить";
            this.buttonMaterialDelete.UseVisualStyleBackColor = true;
            this.buttonMaterialDelete.Click += new System.EventHandler(this.ButtonMaterialDelete_Click);
            // 
            // buttonMaterialEdit
            // 
            this.buttonMaterialEdit.Location = new System.Drawing.Point(634, 84);
            this.buttonMaterialEdit.Name = "buttonMaterialEdit";
            this.buttonMaterialEdit.Size = new System.Drawing.Size(131, 43);
            this.buttonMaterialEdit.TabIndex = 6;
            this.buttonMaterialEdit.Text = "Изменить";
            this.buttonMaterialEdit.UseVisualStyleBackColor = true;
            this.buttonMaterialEdit.Click += new System.EventHandler(this.ButtonMaterialEdit_Click);
            // 
            // buttonMaterialAdd
            // 
            this.buttonMaterialAdd.Location = new System.Drawing.Point(634, 35);
            this.buttonMaterialAdd.Name = "buttonMaterialAdd";
            this.buttonMaterialAdd.Size = new System.Drawing.Size(131, 43);
            this.buttonMaterialAdd.TabIndex = 5;
            this.buttonMaterialAdd.Text = "Добавить";
            this.buttonMaterialAdd.UseVisualStyleBackColor = true;
            this.buttonMaterialAdd.Click += new System.EventHandler(this.ButtonMaterialAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(576, 426);
            this.dataGridView.TabIndex = 9;
            // 
            // MaterialsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonMaterialUpdate);
            this.Controls.Add(this.buttonMaterialDelete);
            this.Controls.Add(this.buttonMaterialEdit);
            this.Controls.Add(this.buttonMaterialAdd);
            this.Name = "MaterialsForm";
            this.Text = "Материалы";
            this.Load += new System.EventHandler(this.MaterialsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMaterialUpdate;
        private System.Windows.Forms.Button buttonMaterialDelete;
        private System.Windows.Forms.Button buttonMaterialEdit;
        private System.Windows.Forms.Button buttonMaterialAdd;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}