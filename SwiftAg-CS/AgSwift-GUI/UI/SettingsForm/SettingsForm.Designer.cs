namespace AgSwift_GUI.SettingsForm
{
    partial class SettingsForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.showDebugInfoCheckbox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.pdfImporterUtilityDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectionRadiusTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maximumZoomScaleTextBox = new System.Windows.Forms.TextBox();
            this.meshComparatorStepAmountTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pointSizeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.showDebugInfoCheckbox);
            this.panel1.Controls.Add(this.browseButton);
            this.panel1.Controls.Add(this.pdfImporterUtilityDirectoryTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.selectionRadiusTextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.maximumZoomScaleTextBox);
            this.panel1.Controls.Add(this.meshComparatorStepAmountTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pointSizeTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 360);
            this.panel1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(176, 317);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(31, 317);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // showDebugInfoCheckbox
            // 
            this.showDebugInfoCheckbox.AutoSize = true;
            this.showDebugInfoCheckbox.Location = new System.Drawing.Point(15, 271);
            this.showDebugInfoCheckbox.Name = "showDebugInfoCheckbox";
            this.showDebugInfoCheckbox.Size = new System.Drawing.Size(143, 17);
            this.showDebugInfoCheckbox.TabIndex = 16;
            this.showDebugInfoCheckbox.Text = "Show Debug Information";
            this.showDebugInfoCheckbox.UseVisualStyleBackColor = true;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(186, 47);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 15;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pdfImporterUtilityDirectoryTextBox
            // 
            this.pdfImporterUtilityDirectoryTextBox.Location = new System.Drawing.Point(12, 49);
            this.pdfImporterUtilityDirectoryTextBox.Name = "pdfImporterUtilityDirectoryTextBox";
            this.pdfImporterUtilityDirectoryTextBox.Size = new System.Drawing.Size(168, 20);
            this.pdfImporterUtilityDirectoryTextBox.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "PDF Importer Utility";
            // 
            // selectionRadiusTextBox
            // 
            this.selectionRadiusTextBox.Location = new System.Drawing.Point(206, 227);
            this.selectionRadiusTextBox.Name = "selectionRadiusTextBox";
            this.selectionRadiusTextBox.Size = new System.Drawing.Size(51, 20);
            this.selectionRadiusTextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Selection Radius";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Maximum Zoom Scale";
            // 
            // maximumZoomScaleTextBox
            // 
            this.maximumZoomScaleTextBox.Location = new System.Drawing.Point(206, 188);
            this.maximumZoomScaleTextBox.Name = "maximumZoomScaleTextBox";
            this.maximumZoomScaleTextBox.Size = new System.Drawing.Size(51, 20);
            this.maximumZoomScaleTextBox.TabIndex = 9;
            // 
            // meshComparatorStepAmountTextBox
            // 
            this.meshComparatorStepAmountTextBox.Location = new System.Drawing.Point(206, 142);
            this.meshComparatorStepAmountTextBox.Name = "meshComparatorStepAmountTextBox";
            this.meshComparatorStepAmountTextBox.Size = new System.Drawing.Size(51, 20);
            this.meshComparatorStepAmountTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mesh Comparator Step Amount";
            // 
            // pointSizeTextBox
            // 
            this.pointSizeTextBox.Location = new System.Drawing.Point(206, 96);
            this.pointSizeTextBox.Name = "pointSizeTextBox";
            this.pointSizeTextBox.Size = new System.Drawing.Size(51, 20);
            this.pointSizeTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Point Size";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 360);
            this.Controls.Add(this.panel1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox showDebugInfoCheckbox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pdfImporterUtilityDirectoryTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox selectionRadiusTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox maximumZoomScaleTextBox;
        private System.Windows.Forms.TextBox meshComparatorStepAmountTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pointSizeTextBox;
        private System.Windows.Forms.Label label2;
    }
}