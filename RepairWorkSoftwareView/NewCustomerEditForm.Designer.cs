using System.ComponentModel;

namespace RepairWorkSoftwareView
{
    partial class NewCustomerEditForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxMailInput = new System.Windows.Forms.TextBox();
            this.textBoxFIOInscription = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxFIOInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 72);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(843, 309);
            this.dataGridView.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox1.Location = new System.Drawing.Point(433, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 23);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Почта:";
            // 
            // textBoxMailInput
            // 
            this.textBoxMailInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBoxMailInput.Location = new System.Drawing.Point(525, 19);
            this.textBoxMailInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMailInput.Name = "textBoxMailInput";
            this.textBoxMailInput.Size = new System.Drawing.Size(330, 30);
            this.textBoxMailInput.TabIndex = 11;
            // 
            // textBoxFIOInscription
            // 
            this.textBoxFIOInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFIOInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFIOInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBoxFIOInscription.Location = new System.Drawing.Point(12, 22);
            this.textBoxFIOInscription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFIOInscription.Name = "textBoxFIOInscription";
            this.textBoxFIOInscription.Size = new System.Drawing.Size(57, 23);
            this.textBoxFIOInscription.TabIndex = 10;
            this.textBoxFIOInscription.Text = "ФИО:";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(138, 388);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 52);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 388);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 52);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxFIOInput
            // 
            this.textBoxFIOInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBoxFIOInput.Location = new System.Drawing.Point(75, 19);
            this.textBoxFIOInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFIOInput.Name = "textBoxFIOInput";
            this.textBoxFIOInput.Size = new System.Drawing.Size(330, 30);
            this.textBoxFIOInput.TabIndex = 7;
            // 
            // NewCustomerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 452);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxMailInput);
            this.Controls.Add(this.textBoxFIOInscription);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxFIOInput);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewCustomerEditForm";
            this.Text = "NewCustomerEditForm";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFIOInput;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxFIOInscription;
        private System.Windows.Forms.TextBox textBoxMailInput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}