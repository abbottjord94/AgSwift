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
        private bool selectionMode = false;
        private bool entryMode = false;
        private int prevX, prevY = 0;
        private int centerX, centerY;
        private PointClickable prev_point = null;
        private bool has_prev_point = false;
        private List<PointClickable> pointClickables = new List<PointClickable>();
        private List<EdgeClickable> edgeClickables = new List<EdgeClickable>();
        private Pen p = new Pen(Color.Green, 1);
        private Pen selected_pen = new Pen(Color.Red, 1);
        public AgSwift_MainWindow()
        {
            InitializeComponent();
            existing_graph = new Graph();
            proposed_graph = new Graph();
            centerX = drawingSurface.Width / 2;
            centerY = drawingSurface.Height / 2;
            blueprintComboBox.SelectedIndex = 0;

            centerLabel.Text = "Center: (" + centerX.ToString() + ", " + centerY.ToString() + ")";
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
            
            Dictionary<int, SwiftAg_CS.Point> pts = graph.getPoints();
            Dictionary<int, SwiftAg_CS.Triangle> triangles = graph.getTriangles();
            /*
            foreach(KeyValuePair<int, SwiftAg_CS.Point> pt in pts)
            {
                g.DrawEllipse(p, new Rectangle((int)(centerX + pt.Value.get_x() * zoomFactor), (int)(centerY + pt.Value.get_y() * zoomFactor), 3,3));
            }
            */

            foreach(PointClickable _p in pointClickables)
            {
                if (_p.getSelected())
                {
                    
                    g.DrawEllipse(selected_pen, new Rectangle((int)(centerX + _p.get_x() * zoomFactor) - 3, (int)(centerY + _p.get_y() * zoomFactor) - 3, 6, 6));
                }
                else
                {
                    g.DrawEllipse(p, new Rectangle((int)(centerX + _p.get_x() * zoomFactor) - 1, (int)(centerY + _p.get_y() * zoomFactor) - 1, 3, 3));
                }
            }

            foreach(EdgeClickable _e in edgeClickables)
            {
                System.Drawing.Point pt1 = new System.Drawing.Point((int)(centerX + _e.get_a().get_x() * zoomFactor), (int)(centerY + _e.get_a().get_y() * zoomFactor));
                System.Drawing.Point pt2 = new System.Drawing.Point((int)(centerX + _e.get_b().get_x() * zoomFactor), (int)(centerY + _e.get_b().get_y() * zoomFactor));
                if (_e.getSelected())
                {
                    g.DrawLine(selected_pen, pt1, pt2);
                }
                else
                {
                    g.DrawLine(p, pt1, pt2);
                }
            }

/*            foreach (KeyValuePair<int, SwiftAg_CS.Triangle> triangle in triangles)
            {
                System.Drawing.Point pt1 = new System.Drawing.Point((int)(centerX + triangle.Value.get_a().get_x() * zoomFactor), (int)(centerY + triangle.Value.get_a().get_y() * zoomFactor));
                System.Drawing.Point pt2 = new System.Drawing.Point((int)(centerX + triangle.Value.get_b().get_x() * zoomFactor), (int)(centerY + triangle.Value.get_b().get_y() * zoomFactor));
                System.Drawing.Point pt3 = new System.Drawing.Point((int)(centerX + triangle.Value.get_c().get_x() * zoomFactor), (int)(centerY + triangle.Value.get_c().get_y() * zoomFactor));
                g.DrawLine(p, pt1, pt2);
                g.DrawLine(p, pt2, pt3);
                g.DrawLine(p, pt1, pt3);
            }*/
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
            drawingSurface.Refresh();
        }

        private void drawingSurface_Pan(object sender, MouseEventArgs e)
        {
            if(draggingState)
            {
                int dx = (prevX - e.X);
                int dy = (prevY - e.Y);

                centerX += -dx;
                centerY += -dy;

                prevX = e.X;
                prevY = e.Y;

                centerLabel.Text = "Center: (" + centerX.ToString() + ", " + centerY.ToString() + ")";
                drawingSurface.Refresh();
            }
        }
        private void drawingSurface_MiddleMouseClickDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                stateLabel.Text = "State: Dragging";
                draggingState = true;
                prevX = e.X;
                prevY = e.Y;
            }
        }

        private void drawingSurface_MiddleMouseClickUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                stateLabel.Text = "State: Not Dragging";
                draggingState = false;
            }

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
            drawingSurface.Refresh();
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

            //Selection Mode
            if(selectionMode)
            {

            }
            //Entry Mode
            else if (entryMode)
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
                        if (mouseEvent.Button == MouseButtons.Left)
                        {
                            double x = mouseEvent.X;
                            double y = mouseEvent.Y;
                            try
                            {
                                double elevation = Double.Parse(elevationEntryBox.Text);
                                PointClickable new_point = new PointClickable((x - centerX) / zoomFactor, (y - centerY) / zoomFactor, elevation);
                                pointClickables.Add(new_point);
                                pointList.Items.Add(new_point.get_elevation().ToString());

                                if (has_prev_point)
                                {
                                    EdgeClickable new_edge = new EdgeClickable(prev_point, new_point);
                                    edgeClickables.Add(new_edge);
                                    prev_point = new_point;
                                    has_prev_point = true;
                                } else
                                {
                                    prev_point = new_point;
                                    has_prev_point = true;
                                }

                                //Method 2: Jordan's Bowyer-Watson triangulation function
                                //graph.addPointToTriangulation(new_point);
                                //Method 3: O(N^3) triangulation
                                graph.addPoint(new_point);
/*                                if (graph.pointCount() > 2)
                                {
                                    graph.bowyerWatsonTriangulation();
                                }*/
                                //graph.triangulate();
                                drawingSurface.Refresh();

                                pointsLabel.Text = "Points: " + graph.pointCount().ToString();
                                edgesLabel.Text = "Edges: " + graph.edgeCount().ToString();
                                trianglesLabel.Text = "Triangles: " + graph.triangleCount().ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                        else if(mouseEvent.Button == MouseButtons.Right)
                        {
                            has_prev_point = false;
                            prev_point = null;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select an Interaction Mode");
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

        private void pointList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectionMode)
            {
                int idx = pointList.SelectedIndex;
                foreach (PointClickable _p in pointClickables)
                {
                    _p.setSelected(false);
                }
                pointClickables[idx].setSelected(true);
                drawingSurface.Refresh();
            }
        }

        private void modeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modeSelectComboBox.SelectedIndex == 0)
            {
                entryMode = false;
                selectionMode = true;
            }
            else if (modeSelectComboBox.SelectedIndex == 1) 
            {
                entryMode = true;
                selectionMode = false;
            }
            else
            {
                entryMode = false;
                selectionMode = false;
            }
        }

        private void blueprintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingSurface.Refresh();
        }

        private void calculateCutFill_Click(object sender, EventArgs e)
        {
            String msg;
            double cut, fill;
            existing_graph.bowyerWatsonTriangulation();
            proposed_graph.bowyerWatsonTriangulation();
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
