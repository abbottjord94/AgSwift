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
            this.SuspendLayout();
            // 
            // displayView
            // 
            this.displayView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayView.ColorBits = ((uint)(24u));
            this.displayView.DepthBits = ((uint)(0u));
            this.displayView.Location = new System.Drawing.Point(12, 52);
            this.displayView.MultisampleBits = ((uint)(0u));
            this.displayView.Name = "displayView";
            this.displayView.Size = new System.Drawing.Size(776, 386);
            this.displayView.StencilBits = ((uint)(0u));
            this.displayView.TabIndex = 0;
            // 
            // OpenGL3Dview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.displayView);
            this.Name = "OpenGL3Dview";
            this.Text = "OpenGL3Dview";
            this.Load += new System.EventHandler(this.OpenGL3Dview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenGL.GlControl displayView;
    }
}