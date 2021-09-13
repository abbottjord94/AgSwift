using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SwiftAg_CS;

namespace AgSwift_GUI
{
    public partial class AgSwift_MainWindow : Form
    {
        private Graph graph;
        public AgSwift_MainWindow()
        {
            InitializeComponent();
            graph = new Graph();
        }

        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green, 1);
            Dictionary<int, SwiftAg_CS.Point> pts = graph.getPoints();
            Dictionary<int, SwiftAg_CS.Triangle> triangles = graph.getTriangles();
            foreach(KeyValuePair<int, SwiftAg_CS.Point> pt in pts)
            {
                g.DrawEllipse(p, new Rectangle((int)pt.Value.get_x(), (int)pt.Value.get_y(),3,3));
            }
            foreach (KeyValuePair<int, SwiftAg_CS.Triangle> triangle in triangles)
            {
                System.Drawing.Point pt1 = new System.Drawing.Point((int)triangle.Value.get_a().get_x(), (int)triangle.Value.get_a().get_y());
                System.Drawing.Point pt2 = new System.Drawing.Point((int)triangle.Value.get_b().get_x(), (int)triangle.Value.get_b().get_y());
                System.Drawing.Point pt3 = new System.Drawing.Point((int)triangle.Value.get_c().get_x(), (int)triangle.Value.get_c().get_y());
                g.DrawLine(p, pt1, pt2);
                g.DrawLine(p, pt2, pt3);
                g.DrawLine(p, pt1, pt3);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Method 1: Riley's Bowyer-Watson triangulation function
            graph.selfContainedBowyerWatsonTriangulation();
            drawingSurface.Refresh();

            pointsLabel.Text = "Points: " + graph.pointCount().ToString();
            edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
            trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
        }

        private void AgSwift_MainWindow_Load(object sender, EventArgs e)
        {
            drawingSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            double x = mouseEvent.X;
            double y = mouseEvent.Y;
            SwiftAg_CS.Point new_point = new SwiftAg_CS.Point(x, y, 0);

            //Method 2: Jordan's Bowyer-Watson triangulation function
            //graph.addPointToTriangulation(new_point);
            //graph.addPoint(new_point);
            //Method 3: O(N^3) triangulation
            graph.addPoint(new_point);
            //graph.triangulate();
            drawingSurface.Refresh();

            pointsLabel.Text = "Points: " + graph.pointCount().ToString();
            edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
            trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
