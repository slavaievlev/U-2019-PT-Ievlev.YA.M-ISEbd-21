namespace RepairWorkSoftwareView
{
    partial class StockForm
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
            this.textBoxNameInscription = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBoxMaterialInscription = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNameInscription
            // 
            this.textBoxNameInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNameInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNameInscription.Location = new System.Drawing.Point(12, 12);
            this.textBoxNameInscription.Name = "textBoxNameInscription";
            this.textBoxNameInscription.Size = new System.Drawing.Size(100, 15);
            this.textBoxNameInscription.TabIndex = 0;
            this.textBoxNameInscription.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(118, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(288, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 62);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(444, 201);
            this.dataGridView.TabIndex = 2;
            // 
            // textBoxMaterialInscription
            // 
            this.textBoxMaterialInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMaterialInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMaterialInscription.Location = new System.Drawing.Point(12, 41);
            this.textBoxMaterialInscription.Name = "textBoxMaterialInscription";
            this.textBoxMaterialInscription.Size = new System.Drawing.Size(100, 15);
            this.textBoxMaterialInscription.TabIndex = 3;
            this.textBoxMaterialInscription.Text = "Материалы:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(246, 269);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 31);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(354, 269);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(102, 31);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 312);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxMaterialInscription);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxNameInscription);
            this.Name = "StockForm";
            this.Text = "FormStock";
            this.Load += new System.EventHandler(this.StockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameInscription;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxMaterialInscription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
    }
}