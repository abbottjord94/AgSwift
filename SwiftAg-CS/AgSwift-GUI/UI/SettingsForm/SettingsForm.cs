using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgSwift_GUI.SettingsForm
{
    public partial class SettingsForm : Form
    {
        private AgSwift_GUI.Utilities.Settings settingsObject;
        private AgSwift_MainWindow mainWindow;
        public SettingsForm(Utilities.Settings _settingsObject, AgSwift_MainWindow _mainWindow)
        {
            settingsObject = _settingsObject;
            mainWindow = _mainWindow;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            pdfImporterUtilityDirectoryTextBox.Text = settingsObject.pdfImporterDir;
            pointSizeTextBox.Text = settingsObject.pointSize.ToString();
            maximumZoomScaleTextBox.Text = settingsObject.zoomScale.ToString();
            selectionRadiusTextBox.Text = settingsObject.selectionRadius.ToString();
            meshComparatorStepAmountTextBox.Text = settingsObject.stepAmount.ToString();
            showDebugInfoCheckbox.Checked = settingsObject.showDebugInfo;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Open("settings.txt", FileMode.Open);
            string fileString = String.Join("\n", new string[] { pdfImporterUtilityDirectoryTextBox.Text, 
                                                                 pointSizeTextBox.Text, 
                                                                 maximumZoomScaleTextBox.Text, 
                                                                 selectionRadiusTextBox.Text, 
                                                                 meshComparatorStepAmountTextBox.Text, 
                                                                 showDebugInfoCheckbox.Checked.ToString() 
            });
            fs.Write(Encoding.UTF8.GetBytes(fileString), 0, fileString.Length);
            fs.Close();
            mainWindow.saveSettings(settingsObject);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                pdfImporterUtilityDirectoryTextBox.Text = Path.GetFullPath(fileDialog.FileName);
            }
        }
    }
}
