namespace coursework
{
    partial class CategoryAdd
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
            this.formLabelCategoryName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.formLabelCategoryCode = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formLabelCategoryName
            // 
            this.formLabelCategoryName.AutoSize = true;
            this.formLabelCategoryName.Location = new System.Drawing.Point(13, 13);
            this.formLabelCategoryName.Name = "formLabelCategoryName";
            this.formLabelCategoryName.Size = new System.Drawing.Size(59, 15);
            this.formLabelCategoryName.TabIndex = 0;
            this.formLabelCategoryName.Text = "Название";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 23);
            this.textBox1.TabIndex = 1;
            // 
            // formLabelCategoryCode
            // 
            this.formLabelCategoryCode.AutoSize = true;
            this.formLabelCategoryCode.Location = new System.Drawing.Point(13, 61);
            this.formLabelCategoryCode.Name = "formLabelCategoryCode";
            this.formLabelCategoryCode.Size = new System.Drawing.Size(27, 15);
            this.formLabelCategoryCode.TabIndex = 2;
            this.formLabelCategoryCode.Text = "Код";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 23);
            this.textBox2.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 109);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(181, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveCategoryButtonClick);
            // 
            // CategoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 226);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.formLabelCategoryCode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.formLabelCategoryName);
            this.Name = "CategoryAdd";
            this.Text = "Добавление категории";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formLabelCategoryName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label formLabelCategoryCode;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button saveButton;
    }
}