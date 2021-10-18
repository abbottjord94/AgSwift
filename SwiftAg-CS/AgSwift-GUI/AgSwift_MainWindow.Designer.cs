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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationEntryBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawingSurface = new System.Windows.Forms.PictureBox();
            this.pointList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.threeDView = new System.Windows.Forms.Button();
            this.calculateCutFill = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.modeSelectComboBox = new System.Windows.Forms.ComboBox();
            this.blueprintLabel = new System.Windows.Forms.Label();
            this.blueprintComboBox = new System.Windows.Forms.ComboBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.centerLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.zoomFactorLabel = new System.Windows.Forms.Label();
            this.edgesLabel = new System.Windows.Forms.Label();
            this.trianglesLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.importPDFToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // importPDFToolStripMenuItem
            // 
            this.importPDFToolStripMenuItem.Name = "importPDFToolStripMenuItem";
            this.importPDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importPDFToolStripMenuItem.Text = "Import PDF";
            this.importPDFToolStripMenuItem.Click += new System.EventHandler(this.importPDFToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearGraphToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearGraphToolStripMenuItem
            // 
            this.clearGraphToolStripMenuItem.Name = "clearGraphToolStripMenuItem";
            this.clearGraphToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.clearGraphToolStripMenuItem.Text = "Clear Graph";
            this.clearGraphToolStripMenuItem.Click += new System.EventHandler(this.clearGraphToolStripMenuItem_Click_1);
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
            // elevationEntryBox
            // 
            this.elevationEntryBox.Location = new System.Drawing.Point(464, 24);
            this.elevationEntryBox.Name = "elevationEntryBox";
            this.elevationEntryBox.Size = new System.Drawing.Size(70, 20);
            this.elevationEntryBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Elevation";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.drawingSurface, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pointList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bottomPanel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1248, 638);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // drawingSurface
            // 
            this.drawingSurface.BackColor = System.Drawing.SystemColors.MenuText;
            this.drawingSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingSurface.Location = new System.Drawing.Point(3, 66);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(1117, 536);
            this.drawingSurface.TabIndex = 13;
            this.drawingSurface.TabStop = false;
            this.drawingSurface.Click += new System.EventHandler(this.drawingSurface_Click_1);
            // 
            // pointList
            // 
            this.pointList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointList.FormattingEnabled = true;
            this.pointList.Location = new System.Drawing.Point(1126, 66);
            this.pointList.Name = "pointList";
            this.pointList.Size = new System.Drawing.Size(119, 536);
            this.pointList.TabIndex = 14;
            this.pointList.SelectedIndexChanged += new System.EventHandler(this.pointList_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1117, 57);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.threeDView);
            this.panel1.Controls.Add(this.calculateCutFill);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(561, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 51);
            this.panel1.TabIndex = 0;
            // 
            // threeDView
            // 
            this.threeDView.Location = new System.Drawing.Point(92, 9);
            this.threeDView.Name = "threeDView";
            this.threeDView.Size = new System.Drawing.Size(65, 36);
            this.threeDView.TabIndex = 1;
            this.threeDView.Text = "3D View";
            this.threeDView.UseVisualStyleBackColor = true;
            this.threeDView.Click += new System.EventHandler(this.threeDView_Click);
            // 
            // calculateCutFill
            // 
            this.calculateCutFill.Location = new System.Drawing.Point(13, 9);
            this.calculateCutFill.Name = "calculateCutFill";
            this.calculateCutFill.Size = new System.Drawing.Size(73, 37);
            this.calculateCutFill.TabIndex = 0;
            this.calculateCutFill.Text = "Calculate Cut/Fill";
            this.calculateCutFill.UseVisualStyleBackColor = true;
            this.calculateCutFill.Click += new System.EventHandler(this.calculateCutFill_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.modeSelectComboBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.elevationEntryBox);
            this.panel2.Controls.Add(this.blueprintLabel);
            this.panel2.Controls.Add(this.blueprintComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 51);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Interaction Mode:";
            // 
            // modeSelectComboBox
            // 
            this.modeSelectComboBox.FormattingEnabled = true;
            this.modeSelectComboBox.Items.AddRange(new object[] {
            "Selection",
            "Entry"});
            this.modeSelectComboBox.Location = new System.Drawing.Point(149, 24);
            this.modeSelectComboBox.Name = "modeSelectComboBox";
            this.modeSelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.modeSelectComboBox.TabIndex = 26;
            this.modeSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.modeSelectComboBox_SelectedIndexChanged);
            // 
            // blueprintLabel
            // 
            this.blueprintLabel.AutoSize = true;
            this.blueprintLabel.Location = new System.Drawing.Point(7, 8);
            this.blueprintLabel.Name = "blueprintLabel";
            this.blueprintLabel.Size = new System.Drawing.Size(51, 13);
            this.blueprintLabel.TabIndex = 25;
            this.blueprintLabel.Text = "Blueprint:";
            // 
            // blueprintComboBox
            // 
            this.blueprintComboBox.FormattingEnabled = true;
            this.blueprintComboBox.Items.AddRange(new object[] {
            "[SELECT]",
            "Existing",
            "Proposed"});
            this.blueprintComboBox.Location = new System.Drawing.Point(7, 24);
            this.blueprintComboBox.Name = "blueprintComboBox";
            this.blueprintComboBox.Size = new System.Drawing.Size(121, 21);
            this.blueprintComboBox.TabIndex = 20;
            this.blueprintComboBox.SelectedIndexChanged += new System.EventHandler(this.blueprintComboBox_SelectedIndexChanged);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.centerLabel);
            this.bottomPanel.Controls.Add(this.stateLabel);
            this.bottomPanel.Controls.Add(this.zoomFactorLabel);
            this.bottomPanel.Controls.Add(this.edgesLabel);
            this.bottomPanel.Controls.Add(this.trianglesLabel);
            this.bottomPanel.Controls.Add(this.pointsLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 608);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1117, 27);
            this.bottomPanel.TabIndex = 25;
            // 
            // centerLabel
            // 
            this.centerLabel.AutoSize = true;
            this.centerLabel.Location = new System.Drawing.Point(229, 8);
            this.centerLabel.Name = "centerLabel";
            this.centerLabel.Size = new System.Drawing.Size(44, 13);
            this.centerLabel.TabIndex = 2;
            this.centerLabel.Text = "Center: ";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(109, 8);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(101, 13);
            this.stateLabel.TabIndex = 1;
            this.stateLabel.Text = "State: Not Dragging";
            // 
            // zoomFactorLabel
            // 
            this.zoomFactorLabel.AutoSize = true;
            this.zoomFactorLabel.Location = new System.Drawing.Point(10, 8);
            this.zoomFactorLabel.Name = "zoomFactorLabel";
            this.zoomFactorLabel.Size = new System.Drawing.Size(79, 13);
            this.zoomFactorLabel.TabIndex = 0;
            this.zoomFactorLabel.Text = "Zoom Factor: 1";
            // 
            // edgesLabel
            // 
            this.edgesLabel.AutoSize = true;
            this.edgesLabel.Location = new System.Drawing.Point(934, 8);
            this.edgesLabel.Name = "edgesLabel";
            this.edgesLabel.Size = new System.Drawing.Size(49, 13);
            this.edgesLabel.TabIndex = 22;
            this.edgesLabel.Text = "Edges: 0";
            // 
            // trianglesLabel
            // 
            this.trianglesLabel.AutoSize = true;
            this.trianglesLabel.Location = new System.Drawing.Point(868, 8);
            this.trianglesLabel.Name = "trianglesLabel";
            this.trianglesLabel.Size = new System.Drawing.Size(62, 13);
            this.trianglesLabel.TabIndex = 23;
            this.trianglesLabel.Text = "Triangles: 0";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(989, 8);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(48, 13);
            this.pointsLabel.TabIndex = 21;
            this.pointsLabel.Text = "Points: 0";
            // 
            // AgSwift_MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1248, 662);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AgSwift_MainWindow";
            this.Text = "AgSwift";
            this.Load += new System.EventHandler(this.AgSwift_MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox elevationEntryBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox drawingSurface;
        private System.Windows.Forms.ListBox pointList;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label blueprintLabel;
        private System.Windows.Forms.ComboBox blueprintComboBox;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label trianglesLabel;
        private System.Windows.Forms.Label edgesLabel;
        private System.Windows.Forms.Button threeDView;
        private System.Windows.Forms.Button calculateCutFill;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label zoomFactorLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label centerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modeSelectComboBox;
    }
}

