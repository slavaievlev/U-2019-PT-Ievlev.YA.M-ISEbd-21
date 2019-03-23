namespace RepairWorkSoftwareView
{
    partial class CreateOrderForm
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
            this.textBoxCustomerInscription = new System.Windows.Forms.TextBox();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.comboBoxWork = new System.Windows.Forms.ComboBox();
            this.textBoxWorkInscription = new System.Windows.Forms.TextBox();
            this.textBoxCountInsrciption = new System.Windows.Forms.TextBox();
            this.textBoxCountInput = new System.Windows.Forms.TextBox();
            this.textBoxSumInput = new System.Windows.Forms.TextBox();
            this.textBoxSumInscription = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCustomerInscription
            // 
            this.textBoxCustomerInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCustomerInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCustomerInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCustomerInscription.Location = new System.Drawing.Point(12, 29);
            this.textBoxCustomerInscription.Name = "textBoxCustomerInscription";
            this.textBoxCustomerInscription.Size = new System.Drawing.Size(100, 23);
            this.textBoxCustomerInscription.TabIndex = 0;
            this.textBoxCustomerInscription.Text = "Клиент:";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(150, 26);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(395, 33);
            this.comboBoxCustomer.TabIndex = 1;
            // 
            // comboBoxWork
            // 
            this.comboBoxWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxWork.FormattingEnabled = true;
            this.comboBoxWork.Location = new System.Drawing.Point(150, 65);
            this.comboBoxWork.Name = "comboBoxWork";
            this.comboBoxWork.Size = new System.Drawing.Size(395, 33);
            this.comboBoxWork.TabIndex = 3;
            this.comboBoxWork.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWork_SelectedIndexChanged);
            // 
            // textBoxWorkInscription
            // 
            this.textBoxWorkInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxWorkInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWorkInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWorkInscription.Location = new System.Drawing.Point(12, 68);
            this.textBoxWorkInscription.Name = "textBoxWorkInscription";
            this.textBoxWorkInscription.Size = new System.Drawing.Size(100, 23);
            this.textBoxWorkInscription.TabIndex = 2;
            this.textBoxWorkInscription.Text = "Услуга:";
            // 
            // textBoxCountInsrciption
            // 
            this.textBoxCountInsrciption.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCountInsrciption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCountInsrciption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountInsrciption.Location = new System.Drawing.Point(12, 107);
            this.textBoxCountInsrciption.Name = "textBoxCountInsrciption";
            this.textBoxCountInsrciption.Size = new System.Drawing.Size(132, 23);
            this.textBoxCountInsrciption.TabIndex = 4;
            this.textBoxCountInsrciption.Text = "Количество:";
            // 
            // textBoxCountInput
            // 
            this.textBoxCountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountInput.Location = new System.Drawing.Point(150, 104);
            this.textBoxCountInput.Name = "textBoxCountInput";
            this.textBoxCountInput.Size = new System.Drawing.Size(395, 30);
            this.textBoxCountInput.TabIndex = 5;
            this.textBoxCountInput.TextChanged += new System.EventHandler(this.TextBoxCountInput_TextChanged);
            // 
            // textBoxSumInput
            // 
            this.textBoxSumInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSumInput.Location = new System.Drawing.Point(150, 140);
            this.textBoxSumInput.Name = "textBoxSumInput";
            this.textBoxSumInput.ReadOnly = true;
            this.textBoxSumInput.Size = new System.Drawing.Size(395, 30);
            this.textBoxSumInput.TabIndex = 7;
            // 
            // textBoxSumInscription
            // 
            this.textBoxSumInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSumInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSumInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSumInscription.Location = new System.Drawing.Point(12, 143);
            this.textBoxSumInscription.Name = "textBoxSumInscription";
            this.textBoxSumInscription.Size = new System.Drawing.Size(100, 23);
            this.textBoxSumInscription.TabIndex = 6;
            this.textBoxSumInscription.Text = "Сумма:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(309, 192);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(115, 40);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(430, 192);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(115, 40);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Отмена";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 244);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSumInput);
            this.Controls.Add(this.textBoxSumInscription);
            this.Controls.Add(this.textBoxCountInput);
            this.Controls.Add(this.textBoxCountInsrciption);
            this.Controls.Add(this.comboBoxWork);
            this.Controls.Add(this.textBoxWorkInscription);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.textBoxCustomerInscription);
            this.Name = "CreateOrderForm";
            this.Text = "Создание заказа";
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCustomerInscription;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.ComboBox comboBoxWork;
        private System.Windows.Forms.TextBox textBoxWorkInscription;
        private System.Windows.Forms.TextBox textBoxCountInsrciption;
        private System.Windows.Forms.TextBox textBoxCountInput;
        private System.Windows.Forms.TextBox textBoxSumInput;
        private System.Windows.Forms.TextBox textBoxSumInscription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
    }
}