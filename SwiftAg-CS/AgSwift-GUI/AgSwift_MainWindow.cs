using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SwiftAg_CS;

namespace AgSwift_GUI
{
    public partial class AgSwift_MainWindow : Form
    {
        private Graph existing_graph, proposed_graph;
        public AgSwift_MainWindow()
        {
            InitializeComponent();
            existing_graph = new Graph();
            proposed_graph = new Graph();
            blueprintComboBox.SelectedIndex = 0;
        }

        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graph graph;
            if(blueprintComboBox.SelectedItem.ToString() == "Existing")
            {
                graph = existing_graph;
            }
            else if(blueprintComboBox.SelectedItem.ToString() == "Proposed")
            {
                graph = proposed_graph;
            }
            else
            {
                graph = existing_graph;
            }
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
            //graph.selfContainedBowyerWatsonTriangulation();
            //graph.triangulate();
            drawingSurface.Refresh();

           // pointsLabel.Text = "Points: " + graph.pointCount().ToString();
            //edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
           // trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
        }

        private void AgSwift_MainWindow_Load(object sender, EventArgs e)
        {
            drawingSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bowyer_Click(object sender, EventArgs e)
        {

        }

        private void clearGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drawingSurface_Click(object sender, EventArgs e)
        {

        }

        private void bowyer_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drawingSurface_Click_1(object sender, EventArgs e)
        {
            if (blueprintComboBox.SelectedItem.ToString() == "[SELECT]")
            {
                MessageBox.Show("Please Select a Blueprint");
            }
            else
            {
                Graph graph;
                if(blueprintComboBox.SelectedItem.ToString() == "Existing")
                {
                    graph = existing_graph;
                }
                else if(blueprintComboBox.SelectedItem.ToString() == "Proposed")
                {
                    graph = proposed_graph;
                }
                else
                {
                    graph = existing_graph;
                }
                MouseEventArgs mouseEvent = (MouseEventArgs)e;
                double x = mouseEvent.X;
                double y = mouseEvent.Y;
                SwiftAg_CS.Point new_point = new SwiftAg_CS.Point(x, y, 0);

                //Method 2: Jordan's Bowyer-Watson triangulation function
                //graph.addPointToTriangulation(new_point);
                //Method 3: O(N^3) triangulation
                graph.addPoint(new_point);
                if (graph.pointCount() > 2)
                {
                    graph.bowyerWatsonTriangulation();
                }
                //graph.triangulate();
                drawingSurface.Refresh();

                pointsLabel.Text = "Points: " + graph.pointCount().ToString();
                edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
                trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
            }
        }

        private void bowyer_Click_2(object sender, EventArgs e)
        {

        }

        private void bowyer_Click_3(object sender, EventArgs e)
        {
            if (blueprintComboBox.SelectedItem.ToString() == "[SELECT]")
            {
                MessageBox.Show("Please Select a Blueprint");
            }
            else
            {
                Graph graph;
                if(blueprintComboBox.SelectedItem.ToString() == "Existing")
                {
                    graph = existing_graph;
                }
                else if(blueprintComboBox.SelectedItem.ToString() == "Proposed")
                {
                    graph = proposed_graph;
                }
                else
                {
                    graph = existing_graph;
                }

                graph.bowyerWatsonTriangulation();
                drawingSurface.Refresh();

                pointsLabel.Text = "Points: " + graph.pointCount().ToString();
                edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
                trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
            }
        }

        private void clearGraphToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Graph graph;
            if (blueprintComboBox.SelectedItem.ToString() == "Existing")
            {
                graph = existing_graph;
            }
            else if (blueprintComboBox.SelectedItem.ToString() == "Proposed")
            {
                graph = proposed_graph;
            }
            else
            {
                graph = existing_graph;
            }
            graph.clearGraph();
            drawingSurface.Refresh();

            pointsLabel.Text = "Points: " + graph.pointCount().ToString();
            edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
            trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
        }

        private void blueprintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingSurface.Refresh();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
