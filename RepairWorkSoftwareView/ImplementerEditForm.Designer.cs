using System.ComponentModel;

namespace RepairWorkSoftwareView
{
    partial class ImplementerEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.textBoxNameText = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNameText
            // 
            this.textBoxNameText.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNameText.Location = new System.Drawing.Point(198, 12);
            this.textBoxNameText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNameText.Name = "textBoxNameText";
            this.textBoxNameText.Size = new System.Drawing.Size(237, 20);
            this.textBoxNameText.TabIndex = 0;
            this.textBoxNameText.Text = "ФИО";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(198, 38);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(279, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 242);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(139, 39);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(157, 242);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(139, 39);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Отменить";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ImplementerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 294);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxNameText);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ImplementerEditForm";
            this.Text = "ImplementerEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameText;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
    }
}