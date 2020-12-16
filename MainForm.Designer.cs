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
            this.notebooksSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.announcementsGrid = new System.Windows.Forms.DataGridView();
            this.createReportButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.announcementsGrid)).BeginInit();
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(184, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(133, 34);
            this.progressBar.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 386);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.announcementsGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Объявления";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // announcementsGrid
            // 
            this.announcementsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.announcementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.announcementsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.announcementsGrid.Location = new System.Drawing.Point(3, 3);
            this.announcementsGrid.Name = "announcementsGrid";
            this.announcementsGrid.ReadOnly = true;
            this.announcementsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.announcementsGrid.Size = new System.Drawing.Size(614, 352);
            this.announcementsGrid.TabIndex = 0;
            this.announcementsGrid.Text = "dataGridView1";
            this.announcementsGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.announcementsGrid_RowEnter);
            this.announcementsGrid.SelectionChanged += new System.EventHandler(this.announcementsGrid_SelectionChanged);
            // 
            // createReportButton
            // 
            this.createReportButton.Location = new System.Drawing.Point(506, 12);
            this.createReportButton.Name = "createReportButton";
            this.createReportButton.Size = new System.Drawing.Size(127, 34);
            this.createReportButton.TabIndex = 5;
            this.createReportButton.Text = "Отчет";
            this.createReportButton.UseVisualStyleBackColor = true;
            this.createReportButton.Visible = false;
            this.createReportButton.Click += new System.EventHandler(this.createReportButtonClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Общий отчёт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createReportButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startParsingButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.DataBindingInitial);
            ((System.ComponentModel.ISupportInitialize)(this.notebooksSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.announcementsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startParsingButton;
        private System.Windows.Forms.BindingSource notebooksSource;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView announcementsGrid;
        private System.Windows.Forms.Button createReportButton;
        private System.Windows.Forms.Button button1;
    }
}

