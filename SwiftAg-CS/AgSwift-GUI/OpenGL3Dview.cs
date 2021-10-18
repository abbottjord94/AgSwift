using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwiftAg_CS;
using OpenGL;

namespace AgSwift_GUI
{
    public partial class OpenGL3Dview : Form
    {
        private AgSwift_MainWindow mainWindow;
        private Graph existing_graph, proposed_graph;
        public OpenGL3Dview(AgSwift_MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            existing_graph = mainWindow.getExistingGraph();
            proposed_graph = mainWindow.getProposedGraph();

            existing_graph.createTriangulation();
            proposed_graph.createTriangulation();

        }

        private void OpenGL3Dview_Load(object sender, EventArgs e)
        {
            OpenGL3Dview_DrawTriangulation();
        }

        private void existing_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (existing_radioButton.Checked)
            {
                proposed_radioButton.Checked = false;
                OpenGL3Dview_DrawTriangulation();
            }
        }

        private void proposed_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (proposed_radioButton.Checked)
            {
                existing_radioButton.Checked = false;
                OpenGL3Dview_DrawTriangulation();
            }
        }

        private void OpenGL3Dview_DrawTriangulation()
        {
            Gl.Viewport(0, 0, 800, 600);

            Gl.Clear(ClearBufferMask.ColorBufferBit);
            Gl.Begin(PrimitiveType.Triangles);

            if (existing_radioButton.Checked)
            {
                Gl.Color3(0.0f, 0.5f, 0.5f); Gl.Vertex2(0.0f, 0.0f);
                Gl.Color3(0.0f, 0.5f, 0.5f); Gl.Vertex2(0.0f, 1.0f);
                Gl.Color3(0.0f, 0.5f, 0.5f); Gl.Vertex2(1.0f, 0.0f);
            }
            else if(proposed_radioButton.Checked)
            {
                Gl.Color3(0.5f, 0.0f, 0.0f); Gl.Vertex2(0.5f, 1.0f);
                Gl.Color3(0.5f, 0.0f, 0.0f); Gl.Vertex2(0.0f, 2.0f);
                Gl.Color3(0.5f, 0.0f, 0.0f); Gl.Vertex2(2.0f, 0.0f);
            }
            else
            {

            }
            Gl.End();
        }
    }
}
