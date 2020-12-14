namespace coursework
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startParsingButton = new System.Windows.Forms.Button();
            this.notebooksGridView = new System.Windows.Forms.DataGridView();
            this.notebooksSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.categoriesGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sellersGridView = new System.Windows.Forms.DataGridView();
            this.sellersSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.addEntityButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellersSource)).BeginInit();
            this.SuspendLayout();
            // 
            // startParsingButton
            // 
            this.startParsingButton.Location = new System.Drawing.Point(12, 12);
            this.startParsingButton.Name = "startParsingButton";
            this.startParsingButton.Size = new System.Drawing.Size(166, 34);
            this.startParsingButton.TabIndex = 0;
            this.startParsingButton.Text = "Начать парсинг";
            this.startParsingButton.UseVisualStyleBackColor = true;
            this.startParsingButton.Click += new System.EventHandler(this.StartParsingButton_Click);
            // 
            // notebooksGridView
            // 
            this.notebooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.notebooksGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.notebooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.notebooksGridView.Location = new System.Drawing.Point(3, 3);
            this.notebooksGridView.Name = "notebooksGridView";
            this.notebooksGridView.Size = new System.Drawing.Size(614, 359);
            this.notebooksGridView.TabIndex = 1;
            this.notebooksGridView.Text = "dataGridView1";
            this.notebooksGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEditHandler);
            this.notebooksGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewRowDeletionHandler);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 393);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.notebooksGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Товары";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.categoriesGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(620, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Категории";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // categoriesGridView
            // 
            this.categoriesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categoriesGridView.Location = new System.Drawing.Point(3, 3);
            this.categoriesGridView.Name = "categoriesGridView";
            this.categoriesGridView.Size = new System.Drawing.Size(614, 359);
            this.categoriesGridView.TabIndex = 3;
            this.categoriesGridView.Text = "dataGridView2";
            this.categoriesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEditHandler);
            this.categoriesGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewRowDeletionHandler);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.sellersGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(620, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Продавцы";
            // 
            // sellersGridView
            // 
            this.sellersGridView.AllowUserToAddRows = false;
            this.sellersGridView.AllowUserToResizeRows = false;
            this.sellersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sellersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sellersGridView.Location = new System.Drawing.Point(3, 3);
            this.sellersGridView.Name = "sellersGridView";
            this.sellersGridView.Size = new System.Drawing.Size(614, 359);
            this.sellersGridView.TabIndex = 0;
            this.sellersGridView.Text = "dataGridView1";
            this.sellersGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEditHandler);
            this.sellersGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewRowDeletionHandler);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(184, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(133, 34);
            this.progressBar.TabIndex = 3;
            // 
            // addEntityButton
            // 
            this.addEntityButton.Location = new System.Drawing.Point(538, 12);
            this.addEntityButton.Name = "addEntityButton";
            this.addEntityButton.Size = new System.Drawing.Size(95, 34);
            this.addEntityButton.TabIndex = 4;
            this.addEntityButton.Text = "Добавить";
            this.addEntityButton.UseVisualStyleBackColor = true;
            this.addEntityButton.Visible = false;
            this.addEntityButton.Click += new System.EventHandler(this.AddEntityButtonClickHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.addEntityButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.startParsingButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notebooksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sellersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellersSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startParsingButton;
        private System.Windows.Forms.DataGridView notebooksGridView;
        private System.Windows.Forms.BindingSource notebooksSource;
        private System.Windows.Forms.BindingSource categoriesSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView categoriesGridView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView sellersGridView;
        private System.Windows.Forms.BindingSource sellersSource;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button addEntityButton;
    }
}

