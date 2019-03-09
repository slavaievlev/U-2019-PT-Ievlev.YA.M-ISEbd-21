namespace RepairWorkSoftwareView
{
    partial class WorkEditForm
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
            this.textBoxNameInput = new System.Windows.Forms.TextBox();
            this.textBoxPriceInput = new System.Windows.Forms.TextBox();
            this.textBoxPriceInscription = new System.Windows.Forms.TextBox();
            this.groupBoxMaterials = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.groupBoxMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNameInscription
            // 
            this.textBoxNameInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNameInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNameInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameInscription.Location = new System.Drawing.Point(26, 12);
            this.textBoxNameInscription.Name = "textBoxNameInscription";
            this.textBoxNameInscription.Size = new System.Drawing.Size(100, 23);
            this.textBoxNameInscription.TabIndex = 0;
            this.textBoxNameInscription.Text = "Название:";
            // 
            // textBoxNameInput
            // 
            this.textBoxNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameInput.Location = new System.Drawing.Point(132, 9);
            this.textBoxNameInput.Name = "textBoxNameInput";
            this.textBoxNameInput.Size = new System.Drawing.Size(326, 30);
            this.textBoxNameInput.TabIndex = 1;
            // 
            // textBoxPriceInput
            // 
            this.textBoxPriceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPriceInput.Location = new System.Drawing.Point(132, 45);
            this.textBoxPriceInput.Name = "textBoxPriceInput";
            this.textBoxPriceInput.Size = new System.Drawing.Size(326, 30);
            this.textBoxPriceInput.TabIndex = 3;
            // 
            // textBoxPriceInscription
            // 
            this.textBoxPriceInscription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPriceInscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPriceInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPriceInscription.Location = new System.Drawing.Point(26, 48);
            this.textBoxPriceInscription.Name = "textBoxPriceInscription";
            this.textBoxPriceInscription.Size = new System.Drawing.Size(100, 23);
            this.textBoxPriceInscription.TabIndex = 2;
            this.textBoxPriceInscription.Text = "Цена:";
            // 
            // groupBoxMaterials
            // 
            this.groupBoxMaterials.Controls.Add(this.buttonUpdate);
            this.groupBoxMaterials.Controls.Add(this.buttonDelete);
            this.groupBoxMaterials.Controls.Add(this.buttonEdit);
            this.groupBoxMaterials.Controls.Add(this.buttonAdd);
            this.groupBoxMaterials.Controls.Add(this.dataGridView);
            this.groupBoxMaterials.Location = new System.Drawing.Point(26, 105);
            this.groupBoxMaterials.Name = "groupBoxMaterials";
            this.groupBoxMaterials.Size = new System.Drawing.Size(762, 269);
            this.groupBoxMaterials.TabIndex = 4;
            this.groupBoxMaterials.TabStop = false;
            this.groupBoxMaterials.Text = "Материалы";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(523, 242);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(581, 35);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(126, 42);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(581, 83);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(126, 42);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(581, 131);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(126, 42);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(581, 179);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(126, 42);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(490, 396);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 42);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(622, 396);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(126, 42);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Отменить";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // WorkEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxMaterials);
            this.Controls.Add(this.textBoxPriceInput);
            this.Controls.Add(this.textBoxPriceInscription);
            this.Controls.Add(this.textBoxNameInput);
            this.Controls.Add(this.textBoxNameInscription);
            this.Name = "WorkEditForm";
            this.Text = "WorkForm";
            this.Load += new System.EventHandler(this.WorkEditForm_Load);
            this.groupBoxMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameInscription;
        private System.Windows.Forms.TextBox textBoxNameInput;
        private System.Windows.Forms.TextBox textBoxPriceInput;
        private System.Windows.Forms.TextBox textBoxPriceInscription;
        private System.Windows.Forms.GroupBox groupBoxMaterials;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
    }
}