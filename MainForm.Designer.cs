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
            this.announcesGridView = new System.Windows.Forms.DataGridView();
            this.notebooksSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabsWithDataGridViews = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.categoriesGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ownersGridView = new System.Windows.Forms.DataGridView();
            this.sellersSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.addEntityButton = new System.Windows.Forms.Button();
            this.removeEntityButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.announcesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesSource)).BeginInit();
            this.tabsWithDataGridViews.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ownersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellersSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startParsingButton
            // 
            this.startParsingButton.Location = new System.Drawing.Point(335, 27);
            this.startParsingButton.Name = "startParsingButton";
            this.startParsingButton.Size = new System.Drawing.Size(166, 34);
            this.startParsingButton.TabIndex = 0;
            this.startParsingButton.Text = "Начать парсинг";
            this.startParsingButton.UseVisualStyleBackColor = true;
            this.startParsingButton.Click += new System.EventHandler(this.StartParsingButton_Click);
            // 
            // announcesGridView
            // 
            this.announcesGridView.AllowUserToAddRows = false;
            this.announcesGridView.AllowUserToDeleteRows = false;
            this.announcesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.announcesGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.announcesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.announcesGridView.Location = new System.Drawing.Point(3, 3);
            this.announcesGridView.Name = "announcesGridView";
            this.announcesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.announcesGridView.Size = new System.Drawing.Size(614, 359);
            this.announcesGridView.TabIndex = 1;
            this.announcesGridView.Text = "dataGridView1";
            this.announcesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEditHandler);
            // 
            // tabsWithDataGridViews
            // 
            this.tabsWithDataGridViews.Controls.Add(this.tabPage1);
            this.tabsWithDataGridViews.Controls.Add(this.tabPage2);
            this.tabsWithDataGridViews.Controls.Add(this.tabPage3);
            this.tabsWithDataGridViews.Location = new System.Drawing.Point(12, 67);
            this.tabsWithDataGridViews.Name = "tabsWithDataGridViews";
            this.tabsWithDataGridViews.SelectedIndex = 0;
            this.tabsWithDataGridViews.Size = new System.Drawing.Size(628, 378);
            this.tabsWithDataGridViews.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.announcesGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 350);
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
            this.tabPage2.Size = new System.Drawing.Size(620, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Категории";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // categoriesGridView
            // 
            this.categoriesGridView.AllowUserToAddRows = false;
            this.categoriesGridView.AllowUserToDeleteRows = false;
            this.categoriesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categoriesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.categoriesGridView.Location = new System.Drawing.Point(3, 3);
            this.categoriesGridView.MultiSelect = false;
            this.categoriesGridView.Name = "categoriesGridView";
            this.categoriesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoriesGridView.Size = new System.Drawing.Size(614, 359);
            this.categoriesGridView.TabIndex = 3;
            this.categoriesGridView.Text = "dataGridView2";
            this.categoriesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEditHandler);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ownersGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(620, 350);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Продавцы";
            // 
            // ownersGridView
            // 
            this.ownersGridView.AllowUserToAddRows = false;
            this.ownersGridView.AllowUserToDeleteRows = false;
            this.ownersGridView.AllowUserToResizeRows = false;
            this.ownersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ownersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ownersGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ownersGridView.Location = new System.Drawing.Point(3, 3);
            this.ownersGridView.MultiSelect = false;
            this.ownersGridView.Name = "ownersGridView";
            this.ownersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ownersGridView.Size = new System.Drawing.Size(614, 359);
            this.ownersGridView.TabIndex = 0;
            this.ownersGridView.Text = "dataGridView1";
            this.ownersGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEditHandler);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(507, 27);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(133, 34);
            this.progressBar.TabIndex = 3;
            // 
            // addEntityButton
            // 
            this.addEntityButton.Location = new System.Drawing.Point(12, 451);
            this.addEntityButton.Name = "addEntityButton";
            this.addEntityButton.Size = new System.Drawing.Size(95, 34);
            this.addEntityButton.TabIndex = 4;
            this.addEntityButton.Text = "Добавить";
            this.addEntityButton.UseVisualStyleBackColor = true;
            this.addEntityButton.Click += new System.EventHandler(this.AddEntityButtonClickHandler);
            // 
            // removeEntityButton
            // 
            this.removeEntityButton.Location = new System.Drawing.Point(113, 451);
            this.removeEntityButton.Name = "removeEntityButton";
            this.removeEntityButton.Size = new System.Drawing.Size(95, 34);
            this.removeEntityButton.TabIndex = 4;
            this.removeEntityButton.Text = "Удалить";
            this.removeEntityButton.UseVisualStyleBackColor = true;
            this.removeEntityButton.Click += new System.EventHandler(this.RemoveEntityButtonClickHandler);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStripActionClickHandler);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem2.Tag = "wipe";
            this.toolStripMenuItem2.Text = "Очистить";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveReportButtonClickHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 498);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.removeEntityButton);
            this.Controls.Add(this.addEntityButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabsWithDataGridViews);
            this.Controls.Add(this.startParsingButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.announcesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesSource)).EndInit();
            this.tabsWithDataGridViews.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ownersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellersSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startParsingButton;
        private System.Windows.Forms.DataGridView announcesGridView;
        private System.Windows.Forms.BindingSource notebooksSource;
        private System.Windows.Forms.BindingSource categoriesSource;
        private System.Windows.Forms.TabControl tabsWithDataGridViews;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView categoriesGridView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView ownersGridView;
        private System.Windows.Forms.BindingSource sellersSource;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button addEntityButton;
        private System.Windows.Forms.Button removeEntityButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button1;
    }
}

