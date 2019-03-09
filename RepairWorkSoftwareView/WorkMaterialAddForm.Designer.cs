namespace RepairWorkSoftwareView
{
    partial class WorkMaterialAddForm
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
            this.textBoxCountInscription = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxCountInput = new System.Windows.Forms.TextBox();
            this.textBoxMaterialInscription = new System.Windows.Forms.TextBox();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxCountInscription
            // 
            this.textBoxCountInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCountInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCountInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountInscription.Location = new System.Drawing.Point(41, 89);
            this.textBoxCountInscription.Name = "textBoxCountInscription";
            this.textBoxCountInscription.Size = new System.Drawing.Size(119, 23);
            this.textBoxCountInscription.TabIndex = 11;
            this.textBoxCountInscription.Text = "Количество:";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(380, 133);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 42);
            this.buttonBack.TabIndex = 10;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(254, 133);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 42);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxCountInput
            // 
            this.textBoxCountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountInput.Location = new System.Drawing.Point(166, 86);
            this.textBoxCountInput.Name = "textBoxCountInput";
            this.textBoxCountInput.Size = new System.Drawing.Size(399, 30);
            this.textBoxCountInput.TabIndex = 8;
            // 
            // textBoxMaterialInscription
            // 
            this.textBoxMaterialInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMaterialInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMaterialInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaterialInscription.Location = new System.Drawing.Point(59, 46);
            this.textBoxMaterialInscription.Name = "textBoxMaterialInscription";
            this.textBoxMaterialInscription.Size = new System.Drawing.Size(101, 23);
            this.textBoxMaterialInscription.TabIndex = 13;
            this.textBoxMaterialInscription.Text = "Материал:";
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(166, 43);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(399, 33);
            this.comboBoxMaterial.TabIndex = 14;
            // 
            // WorkMaterialAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 187);
            this.Controls.Add(this.comboBoxMaterial);
            this.Controls.Add(this.textBoxMaterialInscription);
            this.Controls.Add(this.textBoxCountInscription);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCountInput);
            this.Name = "WorkMaterialAddForm";
            this.Text = "MaterialAddForm";
            this.Load += new System.EventHandler(this.WorkMaterialAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCountInscription;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCountInput;
        private System.Windows.Forms.TextBox textBoxMaterialInscription;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
    }
}