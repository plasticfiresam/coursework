namespace coursework
{
    partial class AnnounceAddForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.announceNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.announceLinkTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.announcePriceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ownersComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ownersSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ownersSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название объявления";
            // 
            // announceNameTextBox
            // 
            this.announceNameTextBox.Location = new System.Drawing.Point(13, 32);
            this.announceNameTextBox.Multiline = true;
            this.announceNameTextBox.Name = "announceNameTextBox";
            this.announceNameTextBox.Size = new System.Drawing.Size(193, 53);
            this.announceNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ссылка на объявление";
            // 
            // announceLinkTextBox
            // 
            this.announceLinkTextBox.Location = new System.Drawing.Point(13, 111);
            this.announceLinkTextBox.Multiline = true;
            this.announceLinkTextBox.Name = "announceLinkTextBox";
            this.announceLinkTextBox.Size = new System.Drawing.Size(193, 23);
            this.announceLinkTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Стоимость";
            // 
            // announcePriceTextBox
            // 
            this.announcePriceTextBox.Location = new System.Drawing.Point(13, 160);
            this.announcePriceTextBox.Name = "announcePriceTextBox";
            this.announcePriceTextBox.Size = new System.Drawing.Size(193, 23);
            this.announcePriceTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Категория";
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Location = new System.Drawing.Point(13, 209);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(193, 23);
            this.categoriesComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Продавец";
            // 
            // ownersComboBox
            // 
            this.ownersComboBox.FormattingEnabled = true;
            this.ownersComboBox.Location = new System.Drawing.Point(13, 258);
            this.ownersComboBox.Name = "ownersComboBox";
            this.ownersComboBox.Size = new System.Drawing.Size(193, 23);
            this.ownersComboBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AdditionButtonClickHandler);
            // 
            // AnnounceAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 344);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ownersComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.categoriesComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.announcePriceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.announceLinkTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.announceNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AnnounceAddForm";
            this.Text = "Добавление объявления";
            this.Load += new System.EventHandler(this.AnnounceAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ownersSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox announceNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox announceLinkTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox announcePriceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categoriesComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ownersComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource ownersSource;
        private System.Windows.Forms.BindingSource categoriesSource;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}