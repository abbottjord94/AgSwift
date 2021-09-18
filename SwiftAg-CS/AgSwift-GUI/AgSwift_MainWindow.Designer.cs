namespace AgSwift_GUI
{
    partial class AgSwift_MainWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawingSurface = new System.Windows.Forms.PictureBox();
            this.pointList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoGeneratePointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangulate_button = new System.Windows.Forms.Button();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.edgesLabel = new System.Windows.Forms.Label();
            this.trianglesLabel = new System.Windows.Forms.Label();
            this.elevationEntryBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bowyer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 658);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.drawingSurface, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pointList, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1193, 634);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // drawingSurface
            // 
            this.drawingSurface.BackColor = System.Drawing.SystemColors.MenuText;
            this.drawingSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingSurface.Location = new System.Drawing.Point(3, 3);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(1048, 628);
            this.drawingSurface.TabIndex = 1;
            this.drawingSurface.TabStop = false;
            this.drawingSurface.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pointList
            // 
            this.pointList.Dock = System.Windows.Forms.DockStyle.Right;
            this.pointList.FormattingEnabled = true;
            this.pointList.Location = new System.Drawing.Point(1070, 3);
            this.pointList.Name = "pointList";
            this.pointList.Size = new System.Drawing.Size(120, 628);
            this.pointList.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.testingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1193, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newProjectToolStripMenuItem.Text = "New Project...";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project...";
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.clearGraphToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // clearGraphToolStripMenuItem
            // 
            this.clearGraphToolStripMenuItem.Name = "clearGraphToolStripMenuItem";
            this.clearGraphToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.clearGraphToolStripMenuItem.Text = "Clear Graph";
            this.clearGraphToolStripMenuItem.Click += new System.EventHandler(this.clearGraphStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoGeneratePointsToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // autoGeneratePointsToolStripMenuItem
            // 
            this.autoGeneratePointsToolStripMenuItem.Name = "autoGeneratePointsToolStripMenuItem";
            this.autoGeneratePointsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.autoGeneratePointsToolStripMenuItem.Text = "Generate Points";
            this.autoGeneratePointsToolStripMenuItem.Click += new System.EventHandler(this.generatePointsStripMenuItem_Click);
            // 
            // triangulate_button
            // 
            this.triangulate_button.Location = new System.Drawing.Point(12, 666);
            this.triangulate_button.Name = "triangulate_button";
            this.triangulate_button.Size = new System.Drawing.Size(75, 23);
            this.triangulate_button.TabIndex = 1;
            this.triangulate_button.Text = "Triangulate";
            this.triangulate_button.UseVisualStyleBackColor = true;
            this.triangulate_button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(843, 672);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(48, 13);
            this.pointsLabel.TabIndex = 2;
            this.pointsLabel.Text = "Points: 0";
            // 
            // edgesLabel
            // 
            this.edgesLabel.AutoSize = true;
            this.edgesLabel.Location = new System.Drawing.Point(788, 672);
            this.edgesLabel.Name = "edgesLabel";
            this.edgesLabel.Size = new System.Drawing.Size(49, 13);
            this.edgesLabel.TabIndex = 3;
            this.edgesLabel.Text = "Edges: 0";
            this.edgesLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // trianglesLabel
            // 
            this.trianglesLabel.AutoSize = true;
            this.trianglesLabel.Location = new System.Drawing.Point(720, 672);
            this.trianglesLabel.Name = "trianglesLabel";
            this.trianglesLabel.Size = new System.Drawing.Size(62, 13);
            this.trianglesLabel.TabIndex = 4;
            this.trianglesLabel.Text = "Triangles: 0";
            // 
            // elevationEntryBox
            // 
            this.elevationEntryBox.Location = new System.Drawing.Point(954, 668);
            this.elevationEntryBox.Name = "elevationEntryBox";
            this.elevationEntryBox.Size = new System.Drawing.Size(100, 20);
            this.elevationEntryBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(897, 672);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Elevation";
            // 
            // bowyer
            // 
            this.bowyer.Location = new System.Drawing.Point(93, 666);
            this.bowyer.Name = "bowyer";
            this.bowyer.Size = new System.Drawing.Size(94, 23);
            this.bowyer.TabIndex = 7;
            this.bowyer.Text = "Bowyer";
            this.bowyer.UseVisualStyleBackColor = true;
            this.bowyer.Click += new System.EventHandler(this.bowyer_Click);
            // 
            // AgSwift_MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1216, 698);
            this.Controls.Add(this.bowyer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.elevationEntryBox);
            this.Controls.Add(this.trianglesLabel);
            this.Controls.Add(this.edgesLabel);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.triangulate_button);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AgSwift_MainWindow";
            this.Text = "AgSwift";
            this.Load += new System.EventHandler(this.AgSwift_MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox drawingSurface;
        private System.Windows.Forms.ListBox pointList;
        private System.Windows.Forms.Button triangulate_button;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label edgesLabel;
        private System.Windows.Forms.Label trianglesLabel;
        private System.Windows.Forms.TextBox elevationEntryBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bowyer;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoGeneratePointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearGraphToolStripMenuItem;
    }
}

