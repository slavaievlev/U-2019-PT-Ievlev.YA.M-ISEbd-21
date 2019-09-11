namespace RepairWorkSoftwareView
{
    partial class ImplementersEditForm
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
            this.textBoxFIOInscription = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxFIOInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxFIOInscription
            // 
            this.textBoxFIOInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFIOInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFIOInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFIOInscription.Location = new System.Drawing.Point(82, 74);
            this.textBoxFIOInscription.Name = "textBoxFIOInscription";
            this.textBoxFIOInscription.Size = new System.Drawing.Size(57, 23);
            this.textBoxFIOInscription.TabIndex = 7;
            this.textBoxFIOInscription.Text = "ФИО:";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(359, 118);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 42);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(233, 118);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 42);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttomSave_Click);
            // 
            // textBoxFIOInput
            // 
            this.textBoxFIOInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFIOInput.Location = new System.Drawing.Point(145, 71);
            this.textBoxFIOInput.Name = "textBoxFIOInput";
            this.textBoxFIOInput.Size = new System.Drawing.Size(399, 30);
            this.textBoxFIOInput.TabIndex = 4;
            // 
            // ImplementersEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 186);
            this.Controls.Add(this.textBoxFIOInscription);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxFIOInput);
            this.Name = "ImplementersEditForm";
            this.Text = "ImplementersEditForm";
            this.Load += new System.EventHandler(this.ImplementerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFIOInscription;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxFIOInput;
    }
}