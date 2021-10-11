namespace AgSwift_GUI
{
    partial class ImportPdfForm
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
            this.imagePreviewBox = new System.Windows.Forms.PictureBox();
            this.nextPage_button = new System.Windows.Forms.Button();
            this.prevPage_button = new System.Windows.Forms.Button();
            this.filename_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.import_button = new System.Windows.Forms.Button();
            this.PdfImporterLabel = new System.Windows.Forms.Label();
            this.pdfImporterBrowseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imagePreviewBox
            // 
            this.imagePreviewBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.imagePreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imagePreviewBox.Location = new System.Drawing.Point(12, 73);
            this.imagePreviewBox.Name = "imagePreviewBox";
            this.imagePreviewBox.Size = new System.Drawing.Size(412, 275);
            this.imagePreviewBox.TabIndex = 0;
            this.imagePreviewBox.TabStop = false;
            // 
            // nextPage_button
            // 
            this.nextPage_button.Location = new System.Drawing.Point(349, 354);
            this.nextPage_button.Name = "nextPage_button";
            this.nextPage_button.Size = new System.Drawing.Size(75, 23);
            this.nextPage_button.TabIndex = 1;
            this.nextPage_button.Text = "Next";
            this.nextPage_button.UseVisualStyleBackColor = true;
            this.nextPage_button.Click += new System.EventHandler(this.nextPage_button_Click);
            // 
            // prevPage_button
            // 
            this.prevPage_button.Location = new System.Drawing.Point(12, 354);
            this.prevPage_button.Name = "prevPage_button";
            this.prevPage_button.Size = new System.Drawing.Size(75, 23);
            this.prevPage_button.TabIndex = 2;
            this.prevPage_button.Text = "Previous";
            this.prevPage_button.UseVisualStyleBackColor = true;
            this.prevPage_button.Click += new System.EventHandler(this.prevPage_button_Click);
            // 
            // filename_Label
            // 
            this.filename_Label.AutoSize = true;
            this.filename_Label.Location = new System.Drawing.Point(12, 9);
            this.filename_Label.Name = "filename_Label";
            this.filename_Label.Size = new System.Drawing.Size(57, 13);
            this.filename_Label.TabIndex = 3;
            this.filename_Label.Text = "File Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image Preview:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(349, 381);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(75, 23);
            this.import_button.TabIndex = 5;
            this.import_button.Text = "Import";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // PdfImporterLabel
            // 
            this.PdfImporterLabel.AutoSize = true;
            this.PdfImporterLabel.Location = new System.Drawing.Point(12, 32);
            this.PdfImporterLabel.Name = "PdfImporterLabel";
            this.PdfImporterLabel.Size = new System.Drawing.Size(72, 13);
            this.PdfImporterLabel.TabIndex = 6;
            this.PdfImporterLabel.Text = "PDF Importer:";
            // 
            // pdfImporterBrowseButton
            // 
            this.pdfImporterBrowseButton.Location = new System.Drawing.Point(349, 27);
            this.pdfImporterBrowseButton.Name = "pdfImporterBrowseButton";
            this.pdfImporterBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.pdfImporterBrowseButton.TabIndex = 7;
            this.pdfImporterBrowseButton.Text = "Browse...";
            this.pdfImporterBrowseButton.UseVisualStyleBackColor = true;
            this.pdfImporterBrowseButton.Click += new System.EventHandler(this.pdfImporterBrowseButton_Click);
            // 
            // ImportPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 416);
            this.Controls.Add(this.pdfImporterBrowseButton);
            this.Controls.Add(this.PdfImporterLabel);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filename_Label);
            this.Controls.Add(this.prevPage_button);
            this.Controls.Add(this.nextPage_button);
            this.Controls.Add(this.imagePreviewBox);
            this.Name = "ImportPdfForm";
            this.Text = "ImportPdfForm";
            this.Load += new System.EventHandler(this.ImportPdfForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePreviewBox;
        private System.Windows.Forms.Button nextPage_button;
        private System.Windows.Forms.Button prevPage_button;
        private System.Windows.Forms.Label filename_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.Label PdfImporterLabel;
        private System.Windows.Forms.Button pdfImporterBrowseButton;
    }
}