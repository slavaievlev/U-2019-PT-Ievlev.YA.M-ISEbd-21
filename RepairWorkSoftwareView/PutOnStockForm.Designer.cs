namespace RepairWorkSoftwareView
{
    partial class PutOnStockForm
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
            this.textBoxStockInscription = new System.Windows.Forms.TextBox();
            this.comboBoxStock = new System.Windows.Forms.ComboBox();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.textBoxCountInscription = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxStockInscription
            // 
            this.textBoxStockInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxStockInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockInscription.Location = new System.Drawing.Point(12, 12);
            this.textBoxStockInscription.Name = "textBoxStockInscription";
            this.textBoxStockInscription.Size = new System.Drawing.Size(100, 15);
            this.textBoxStockInscription.TabIndex = 0;
            this.textBoxStockInscription.Text = "Склад:";
            // 
            // comboBoxStock
            // 
            this.comboBoxStock.FormattingEnabled = true;
            this.comboBoxStock.Location = new System.Drawing.Point(118, 12);
            this.comboBoxStock.Name = "comboBoxStock";
            this.comboBoxStock.Size = new System.Drawing.Size(460, 24);
            this.comboBoxStock.TabIndex = 1;
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(118, 42);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(460, 24);
            this.comboBoxMaterial.TabIndex = 3;
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMaterial.Location = new System.Drawing.Point(12, 42);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(100, 15);
            this.textBoxMaterial.TabIndex = 2;
            this.textBoxMaterial.Text = "Материал:";
            // 
            // textBoxCountInscription
            // 
            this.textBoxCountInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCountInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCountInscription.Location = new System.Drawing.Point(12, 76);
            this.textBoxCountInscription.Name = "textBoxCountInscription";
            this.textBoxCountInscription.Size = new System.Drawing.Size(100, 15);
            this.textBoxCountInscription.TabIndex = 4;
            this.textBoxCountInscription.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(118, 76);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(460, 22);
            this.textBoxCount.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(273, 212);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(91, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(370, 212);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(91, 30);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PutOnStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 254);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxCountInscription);
            this.Controls.Add(this.comboBoxMaterial);
            this.Controls.Add(this.textBoxMaterial);
            this.Controls.Add(this.comboBoxStock);
            this.Controls.Add(this.textBoxStockInscription);
            this.Name = "PutOnStockForm";
            this.Text = "PutOnStockForm";
            this.Load += new System.EventHandler(this.FormPutOnStock_Load);
            this.Click += new System.EventHandler(this.FormPutOnStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStockInscription;
        private System.Windows.Forms.ComboBox comboBoxStock;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.TextBox textBoxMaterial;
        private System.Windows.Forms.TextBox textBoxCountInscription;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
    }
}