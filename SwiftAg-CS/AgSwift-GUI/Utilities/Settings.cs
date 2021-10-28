using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgSwift_GUI.Utilities
{
    public class Settings
    {
        public string pdfImporterDir;
        public int pointSize, zoomScale, selectionRadius;
        public double stepAmount;
        public bool showDebugInfo;

        public Settings()
        {

        }

        public void loadSettings(string settingsFileDir)
        {
            try
            {
                string settingsFilePath = Path.GetFullPath(settingsFileDir);
                FileStream fs = File.Open(settingsFilePath, FileMode.Open);
                byte[] fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, (int)fs.Length);
                string[] fileLines = Encoding.UTF8.GetString(fileBytes).Split('\n');

                pdfImporterDir = fileLines[0];
                pointSize = Convert.ToInt32(fileLines[1]);
                zoomScale = Convert.ToInt32(fileLines[2]);
                selectionRadius = Convert.ToInt32(fileLines[3]);
                stepAmount = Double.Parse(fileLines[4]);
                showDebugInfo = Convert.ToBoolean(fileLines[5]);

                fs.Close();
            }
            catch(Exception e)
            {

            }

        }
    }
}
