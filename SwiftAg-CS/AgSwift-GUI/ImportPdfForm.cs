using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace AgSwift_GUI
{
    public partial class ImportPdfForm : Form
    {
        private AgSwift_MainWindow mainWindow;
        private string filename;
        private string pdfimporter_path = null;
        private int pageNumber = 1;
        private Image previewImage;
        public ImportPdfForm(string _filename, AgSwift_MainWindow _mainWindow)
        {
            InitializeComponent();
            filename = _filename;
            mainWindow = _mainWindow;
        }

        private void ImportPdfForm_Load(object sender, EventArgs e)
        {
            string fn = Path.GetFileName(filename);
            filename_Label.Text = "File Name: " + fn + " Page: " + pageNumber.ToString() ;
        }

        private Image getImage()
        {
            Process importer_process = Process.Start(pdfimporter_path, filename + " " + pageNumber.ToString());
            while(true)
            {
                if (importer_process.HasExited) break;
            }
            try
            {
                string imageFileName = Path.GetFullPath(Path.GetFileName(filename) + "-Page-" + pageNumber.ToString() + ".tiff");
                Image img = Image.FromFile(imageFileName);
                
                return img;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pdfImporterBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                pdfimporter_path = dialog.FileName;
                PdfImporterLabel.Text = Path.GetFileName(pdfimporter_path);
            }
        }

        private void nextPage_button_Click(object sender, EventArgs e)
        {
            if(pdfimporter_path == null)
            {
                MessageBox.Show("Please Select a PDF Importer to continue");
            }
            else
            {
                pageNumber += 1;
                previewImage = getImage();
                imagePreviewBox.BackgroundImageLayout = ImageLayout.Stretch;
                imagePreviewBox.BackgroundImage = previewImage;
                filename_Label.Text = "File Name: " + Path.GetFileName(filename) + " Page: " + pageNumber.ToString();
            }
        }

        private void prevPage_button_Click(object sender, EventArgs e)
        {
            if (pdfimporter_path == null)
            {
                MessageBox.Show("Please Select a PDF Importer to continue");
            }
            else
            {
                
                pageNumber -= 1;
                previewImage = getImage();
                imagePreviewBox.BackgroundImageLayout = ImageLayout.Stretch;
                imagePreviewBox.BackgroundImage = previewImage;
                filename_Label.Text = "File Name: " + Path.GetFileName(filename) + " Page: " + pageNumber.ToString();
            }
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            mainWindow.addImageFromImportForm(previewImage);
            this.Close();
        }
    }
}
