using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenGL;

namespace AgSwift_GUI
{
    public partial class OpenGL3Dview : Form
    {
        public OpenGL3Dview()
        {
            InitializeComponent();
        }

        private void OpenGL3Dview_Load(object sender, EventArgs e)
        {
            
            Gl.Viewport(-200, -250, 800, 600);
            Gl.Clear(ClearBufferMask.ColorBufferBit);
            Gl.Begin(PrimitiveType.Triangles);
            Gl.Color3(0.0f, 0.5f, 0.5f); Gl.Vertex2(0.0f, 0.0f);
            Gl.Color3(0.0f, 0.5f, 0.5f); Gl.Vertex2(0.5f, 1.0f);
            Gl.Color3(0.0f, 0.5f, 0.5f); Gl.Vertex2(1.0f, 0.0f);
            Gl.End();
        }
    }
}
