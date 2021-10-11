using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SwiftAg_CS;

namespace AgSwift_GUI
{
    public partial class AgSwift_MainWindow : Form
    {
        //Existing and Proposed Graphs
        private Graph existing_graph, proposed_graph;

        //Sets the zoom factor for the drawing surface. Bounded between 1-16
        private int zoomFactor = 1;

        //Determines whether the mouse is being dragged
        private bool draggingState = false;

        //Booleans for the entry and selection modes. These are set by the "Interaction Mode" combo box at the top
        private bool selectionMode = false;
        private bool entryMode = false;

        //Stores the previous X and Y values for the mouse, to determine the dx and dy for panning
        private int prevX, prevY = 0;

        //Stores the X and Y values for the center of the drawing surface
        private int centerX, centerY;

        //Stores whether or not there is a previous point, so that an EdgeClickable can be created (comparing prev_point to null returns an exception)
        private PointClickable prev_point = null;
        private bool has_prev_point = false;

        //Lists to store references to pointClickables and edgeClickables that appear on the drawing surface.

        Dictionary<string, List<PointClickable>> pointClickables = new Dictionary<string, List<PointClickable>>();
        Dictionary<string, List<EdgeClickable>> edgeClickables = new Dictionary<string, List<EdgeClickable>>();

        //Pens used to determine the color of items drawn on the drawing surface
        private Pen p = new Pen(Color.Green, 1);
        private Pen selected_pen = new Pen(Color.Red, 1);
        private Pen yellow_pen = new Pen(Color.Yellow, 1);

        //Stores the maximum radius for point selection
        private double selectionRadius = 10;

        //Stores X and Y mouse coordinates for drawing edges (might be a better way to do this)
        private double mouseX, mouseY;

        //Constructor (Runs at the start of the program)
        public AgSwift_MainWindow()
        {
            InitializeComponent();
            existing_graph = new Graph();
            proposed_graph = new Graph();
            centerX = drawingSurface.Width / 2;
            centerY = drawingSurface.Height / 2;
            blueprintComboBox.SelectedIndex = 0;

            pointClickables["Existing"] = new List<PointClickable>();
            edgeClickables["Existing"] = new List<EdgeClickable>();

            pointClickables["Proposed"] = new List<PointClickable>();
            edgeClickables["Proposed"] = new List<EdgeClickable>();

            centerLabel.Text = "Center: (" + centerX.ToString() + ", " + centerY.ToString() + ")";
        }

        //Drawing Surface Paint Method
        //This runs every time drawingSurface.Refresh() is called.
        private void drawingSurface_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (blueprintComboBox.SelectedItem.ToString() == "Existing" || blueprintComboBox.SelectedItem.ToString() == "Proposed")
            {
                foreach (PointClickable _p in pointClickables[blueprintComboBox.SelectedItem.ToString()])
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

                foreach (EdgeClickable _e in edgeClickables[blueprintComboBox.SelectedItem.ToString()])
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

                if (has_prev_point)
                {
                    System.Drawing.Point prev_pt1 = new System.Drawing.Point((int)(centerX + prev_point.get_x() * zoomFactor), (int)(centerY + prev_point.get_y() * zoomFactor));
                    System.Drawing.Point prev_pt2 = new System.Drawing.Point((int)mouseX, (int)mouseY);
                    g.DrawLine(p, prev_pt1, prev_pt2);
                }
            }
        }

        //Runs when the main window is finished loading. Event handlers go here.
        private void AgSwift_MainWindow_Load(object sender, EventArgs e)
        {
            drawingSurface.Resize += new System.EventHandler(this.drawingSurface_Resize);
            drawingSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingSurface_Paint);
            drawingSurface.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MouseWheel);
            drawingSurface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MiddleMouseClickDown);
            drawingSurface.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MiddleMouseClickUp);
            drawingSurface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_Pan);
            drawingSurface.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.drawingSurface_KeyDown);
        }
        
        //Runs when a key is pressed on the drawing surface
        private void drawingSurface_KeyDown(object sender, PreviewKeyDownEventArgs ke)
        {
            if(selectionMode && ke.KeyCode == Keys.Delete)
            {
                List<PointClickable> points = new List<PointClickable>();
                foreach(PointClickable _p in pointClickables[blueprintComboBox.SelectedItem.ToString()])
                {
                    if(_p.getSelected())
                    {
                        foreach(EdgeClickable e in edgeClickables[blueprintComboBox.SelectedItem.ToString()])
                        {
                            if(e.containsPoint(_p))
                            {
                                e.setSelected(true);
                            }
                        }
                    }
                    else
                    {
                        points.Add(_p);
                    }
                }

                List<EdgeClickable> edges = new List<EdgeClickable>();
                foreach (EdgeClickable _e in edgeClickables[blueprintComboBox.SelectedItem.ToString()])
                {
                    
                    if(!_e.getSelected())
                    {
                        edges.Add(_e);
                    }
                }
                pointClickables[blueprintComboBox.SelectedItem.ToString()] = points;
                edgeClickables[blueprintComboBox.SelectedItem.ToString()] = edges;
                drawingSurface.Refresh();
            }
        }

        //Runs when the drawing surface is resized (given by the drawingSurface.Resize event handler)
        private void drawingSurface_Resize(object sender, EventArgs e)
        {
            centerX = drawingSurface.Width / 2;
            centerY = drawingSurface.Height / 2;

            centerLabel.Text = "Center: (" + centerX.ToString() + ", " + centerY.ToString() + ")";
            drawingSurface.Refresh();
        }

        //Function for panning across the drawing surface
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
            else
            {
                mouseX = e.X;
                mouseY = e.Y;
                drawingSurface.Refresh();
            }
        }

        //Sets the draggingState variable when the middle mouse button event handler is triggered
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

        //Ensures that the draggingState is set to false when the user stops holding the middle mouse button
        private void drawingSurface_MiddleMouseClickUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                stateLabel.Text = "State: Not Dragging";
                draggingState = false;
            }

        }

        //Function for handling the scroll wheel event handler. This changes the drawing surface zoom factor
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

        //Handles mouse clicks to the drawing surface.
        private void drawingSurface_Click_1(object sender, EventArgs e)
        {
            drawingSurface.Focus();
            //Selection Mode
            if (selectionMode)
            {
                if (blueprintComboBox.SelectedItem.ToString() == "[SELECT]")
                {
                    MessageBox.Show("Please Select a Blueprint");
                }
                else {
                    MouseEventArgs me = (MouseEventArgs)e;
                    if (me.Button == MouseButtons.Left)
                    {
                        SwiftAg_CS.Point test_point = new SwiftAg_CS.Point((me.X - centerX) / zoomFactor, (me.Y - centerY) / zoomFactor, 0);
                        PointClickable closest_point = null;
                        EdgeClickable closest_edge = null;
                        bool found_point = false;
                        bool found_edge = false;
                        double min_distance = Double.NaN;
                        foreach (PointClickable _p in pointClickables[blueprintComboBox.SelectedItem.ToString()])
                        {
                            if(_p.distance(test_point) < selectionRadius && (min_distance < _p.distance(test_point) || Double.IsNaN(min_distance)))
                            {
                                closest_point = _p;
                                found_point = true;
                                min_distance = _p.distance(test_point);
                            }
                        }
                        if (found_point)
                        {
                            if (closest_point.getSelected())
                            {
                                closest_point.setSelected(false);
                            }
                            else
                            {
                                closest_point.setSelected(true);
                            }
                            drawingSurface.Refresh();
                        }
                        else {
                            min_distance = Double.NaN;
                            foreach (EdgeClickable _e in edgeClickables[blueprintComboBox.SelectedItem.ToString()])
                            {
                                if (_e.distanceFromEdge(test_point) < selectionRadius && (min_distance < _e.distanceFromEdge(test_point) || Double.IsNaN(min_distance)))
                                {
                                    closest_edge = _e;
                                    found_edge = true;
                                    min_distance = _e.distanceFromEdge(test_point);
                                }
                            }
                            if(found_edge)
                            {
                                if(closest_edge.getSelected())
                                {
                                    closest_edge.setSelected(false);
                                }
                                else
                                {
                                    closest_edge.setSelected(true);
                                }
                                drawingSurface.Refresh();
                            }
                        }
                    }
                }
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
                                pointClickables[blueprintComboBox.SelectedItem.ToString()].Add(new_point);
                                pointList.Items.Add(new_point.get_elevation().ToString());

                                if (has_prev_point)
                                {
                                    EdgeClickable new_edge = new EdgeClickable(prev_point, new_point);
                                    edgeClickables[blueprintComboBox.SelectedItem.ToString()].Add(new_edge);
                                    prev_point = new_point;
                                    has_prev_point = true;
                                } else
                                {
                                    prev_point = new_point;
                                    has_prev_point = true;
                                }
                                graph.addPoint(new_point);
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
                            drawingSurface.Refresh();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select an Interaction Mode");
            }
        }

        //Clears the selected graph of all points, edges, and triangles.
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

        //Event handler for when a pointList item is selected
        private void pointList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectionMode)
            {
                int idx = pointList.SelectedIndex;
                foreach (PointClickable _p in pointClickables[blueprintComboBox.SelectedItem.ToString()])
                {
                    _p.setSelected(false);
                }
                pointClickables[blueprintComboBox.SelectedItem.ToString()][idx].setSelected(true);
                drawingSurface.Refresh();
            }
        }

        private void importPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                //Open PDF Import form here
            }
        }

        //Event handler for when the user changes their interaction mode.
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

        //Refreshes the drawing surface when the user changes the blueprint they're working on
        private void blueprintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            prev_point = null;
            has_prev_point = false;
            drawingSurface.Refresh();
        }

        //Calculates the cut and fill for the two graphs
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

        //Exits the program
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
