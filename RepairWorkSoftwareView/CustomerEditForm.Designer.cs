namespace RepairWorkSoftwareView
{
    partial class CustomerEditForm
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
            this.textBoxFIOInput = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxFIOInscription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxFIOInput
            // 
            this.textBoxFIOInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFIOInput.Location = new System.Drawing.Point(166, 41);
            this.textBoxFIOInput.Name = "textBoxFIOInput";
            this.textBoxFIOInput.Size = new System.Drawing.Size(399, 30);
            this.textBoxFIOInput.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(254, 88);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 42);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttomSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(380, 88);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 42);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // textBoxFIOInscription
            // 
            this.textBoxFIOInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFIOInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFIOInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFIOInscription.Location = new System.Drawing.Point(103, 44);
            this.textBoxFIOInscription.Name = "textBoxFIOInscription";
            this.textBoxFIOInscription.Size = new System.Drawing.Size(57, 23);
            this.textBoxFIOInscription.TabIndex = 3;
            this.textBoxFIOInscription.Text = "ФИО:";
            // 
            // CustomerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 142);
            this.Controls.Add(this.textBoxFIOInscription);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxFIOInput);
            this.Name = "CustomerEditForm";
            this.Text = "Редактирование клиента";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFIOInput;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxFIOInscription;
    }
}