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
        private int zoomFactor = 1;
        private bool draggingState = false;
        private int prevX, prevY = 0;
        private int centerX, centerY;
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
            drawingSurface.Resize += new System.EventHandler(this.drawingSurface_Resize);
            drawingSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            drawingSurface.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MouseWheel);
            drawingSurface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MiddleMouseClickDown);
            drawingSurface.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MiddleMouseClickUp);
            drawingSurface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_Pan);
        }

        private void drawingSurface_Resize(object sender, EventArgs e)
        {
            centerX = drawingSurface.Width / 2;
            centerY = drawingSurface.Height / 2;

            centerLabel.Text = "Center: (" + centerX.ToString() + ", " + centerY.ToString() + ")";
        }

        private void drawingSurface_Pan(object sender, MouseEventArgs e)
        {
            if(draggingState)
            {
                int dx = (prevX - e.X) / zoomFactor;
                int dy = (prevY - e.Y) / zoomFactor;

                centerX += dx;
                centerY += dy;

                prevX = e.X;
                prevY = e.Y;

                centerLabel.Text = "Center: (" + centerX.ToString() + ", " + centerY.ToString() + ")";
            }
        }
        private void drawingSurface_MiddleMouseClickDown(object sender, MouseEventArgs e)
        {
            stateLabel.Text = "State: Dragging";
            draggingState = true;
            prevX = e.X;
            prevY = e.Y;
        }

        private void drawingSurface_MiddleMouseClickUp(object sender, MouseEventArgs e)
        {
            stateLabel.Text = "State: Not Dragging";
            draggingState = false;
        }

        private void drawingSurface_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (zoomFactor >= 16)
                {
                    zoomFactor = 16;
                }
                else
                {
                    zoomFactor++;
                }
            }
            else
            {
                if (zoomFactor <= 1)
                {
                    zoomFactor = 1;
                }
                else
                {
                    zoomFactor--;
                }
            }
            zoomFactorLabel.Text = "Zoom Factor: " + zoomFactor.ToString();
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
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button != MouseButtons.Middle)
            {
                if (blueprintComboBox.SelectedItem.ToString() == "[SELECT]")
                {
                    MessageBox.Show("Please Select a Blueprint");
                }
                else
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
                    MouseEventArgs mouseEvent = (MouseEventArgs)e;
                    double x = mouseEvent.X;
                    double y = mouseEvent.Y;
                    double elevation = Double.Parse(elevationEntryBox.Text);
                    SwiftAg_CS.Point new_point = new SwiftAg_CS.Point(x, y, elevation);

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

        private void calculateCutFill_Click(object sender, EventArgs e)
        {
            String msg;
            double cut, fill;
            MeshComparator mc = new MeshComparator(existing_graph, proposed_graph);
            mc.CalculateCutFill();
            if(mc.getError())
            {
                MessageBox.Show(mc.getErrorMsg(), "Error");
            }
            else
            {
                cut = mc.getCut();
                fill = mc.getFill();
                msg = "Total Cut: \t" + cut.ToString() + "\n"
                    + "Total Fill: \t" + fill.ToString() + "\n"
                    + "Difference: \t" + Math.Abs(cut - fill) + "\n";
                MessageBox.Show(msg, "Cut/Fill Calculation");
            }

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
