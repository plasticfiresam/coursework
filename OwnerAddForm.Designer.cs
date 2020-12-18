namespace coursework
{
    partial class OwnerAddForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.ownerUrlTextBox = new System.Windows.Forms.TextBox();
            this.ownerUrlTextBoxLabel = new System.Windows.Forms.Label();
            this.ownerNameTextBoxLabel = new System.Windows.Forms.Label();
            this.ownerNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OwnerAddHandler);
            // 
            // ownerUrlTextBox
            // 
            this.ownerUrlTextBox.Location = new System.Drawing.Point(12, 31);
            this.ownerUrlTextBox.Name = "ownerUrlTextBox";
            this.ownerUrlTextBox.Size = new System.Drawing.Size(291, 23);
            this.ownerUrlTextBox.TabIndex = 1;
            // 
            // ownerUrlTextBoxLabel
            // 
            this.ownerUrlTextBoxLabel.AutoSize = true;
            this.ownerUrlTextBoxLabel.Location = new System.Drawing.Point(13, 13);
            this.ownerUrlTextBoxLabel.Name = "ownerUrlTextBoxLabel";
            this.ownerUrlTextBoxLabel.Size = new System.Drawing.Size(174, 15);
            this.ownerUrlTextBoxLabel.TabIndex = 2;
            this.ownerUrlTextBoxLabel.Text = "Ссылка на страницу продавца";
            // 
            // ownerNameTextBoxLabel
            // 
            this.ownerNameTextBoxLabel.AutoSize = true;
            this.ownerNameTextBoxLabel.Location = new System.Drawing.Point(12, 61);
            this.ownerNameTextBoxLabel.Name = "ownerNameTextBoxLabel";
            this.ownerNameTextBoxLabel.Size = new System.Drawing.Size(114, 15);
            this.ownerNameTextBoxLabel.TabIndex = 3;
            this.ownerNameTextBoxLabel.Text = "Название продавца";
            // 
            // ownerNameTextBox
            // 
            this.ownerNameTextBox.Location = new System.Drawing.Point(12, 80);
            this.ownerNameTextBox.Name = "ownerNameTextBox";
            this.ownerNameTextBox.Size = new System.Drawing.Size(291, 23);
            this.ownerNameTextBox.TabIndex = 4;
            // 
            // OwnerAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 169);
            this.Controls.Add(this.ownerNameTextBox);
            this.Controls.Add(this.ownerNameTextBoxLabel);
            this.Controls.Add(this.ownerUrlTextBoxLabel);
            this.Controls.Add(this.ownerUrlTextBox);
            this.Controls.Add(this.button1);
            this.Name = "OwnerAddForm";
            this.Text = "Добавление продавца";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ownerUrlTextBox;
        private System.Windows.Forms.Label ownerUrlTextBoxLabel;
        private System.Windows.Forms.Label ownerNameTextBoxLabel;
        private System.Windows.Forms.TextBox ownerNameTextBox;
    }
}