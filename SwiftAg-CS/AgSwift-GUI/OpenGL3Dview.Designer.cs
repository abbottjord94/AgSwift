namespace AgSwift_GUI
{
    partial class OpenGL3Dview
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
            this.displayView = new OpenGL.GlControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.proposed_radioButton = new System.Windows.Forms.RadioButton();
            this.existing_radioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayView
            // 
            this.displayView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayView.ColorBits = ((uint)(24u));
            this.displayView.DepthBits = ((uint)(0u));
            this.displayView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayView.Location = new System.Drawing.Point(3, 82);
            this.displayView.MultisampleBits = ((uint)(0u));
            this.displayView.Name = "displayView";
            this.displayView.Size = new System.Drawing.Size(1130, 711);
            this.displayView.StencilBits = ((uint)(0u));
            this.displayView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.displayView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1136, 796);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.proposed_radioButton);
            this.panel1.Controls.Add(this.existing_radioButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 73);
            this.panel1.TabIndex = 1;
            // 
            // proposed_radioButton
            // 
            this.proposed_radioButton.AutoSize = true;
            this.proposed_radioButton.Checked = true;
            this.proposed_radioButton.Location = new System.Drawing.Point(100, 29);
            this.proposed_radioButton.Name = "proposed_radioButton";
            this.proposed_radioButton.Size = new System.Drawing.Size(70, 17);
            this.proposed_radioButton.TabIndex = 1;
            this.proposed_radioButton.TabStop = true;
            this.proposed_radioButton.Text = "Proposed";
            this.proposed_radioButton.UseVisualStyleBackColor = true;
            this.proposed_radioButton.CheckedChanged += new System.EventHandler(this.proposed_radioButton_CheckedChanged);
            // 
            // existing_radioButton
            // 
            this.existing_radioButton.AutoSize = true;
            this.existing_radioButton.Location = new System.Drawing.Point(9, 29);
            this.existing_radioButton.Name = "existing_radioButton";
            this.existing_radioButton.Size = new System.Drawing.Size(61, 17);
            this.existing_radioButton.TabIndex = 0;
            this.existing_radioButton.Text = "Existing";
            this.existing_radioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.existing_radioButton.UseVisualStyleBackColor = true;
            this.existing_radioButton.CheckedChanged += new System.EventHandler(this.existing_radioButton_CheckedChanged);
            // 
            // OpenGL3Dview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 796);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OpenGL3Dview";
            this.Text = "OpenGL3Dview";
            this.Load += new System.EventHandler(this.OpenGL3Dview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenGL.GlControl displayView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton proposed_radioButton;
        private System.Windows.Forms.RadioButton existing_radioButton;
    }
}