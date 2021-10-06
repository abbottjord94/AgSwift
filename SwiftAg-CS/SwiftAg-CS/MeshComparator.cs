using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftAg_CS
{
    public class MeshComparator
    {
        private Graph existing_graph;
        private Graph proposed_graph;

        private double cut_amount, fill_amount = 0;

        private bool error = false;
        private string err_msg = "";

        public MeshComparator()
        {

        }

        public MeshComparator(Graph _existing, Graph _proposed)
        {
            existing_graph = _existing;
            proposed_graph = _proposed;
        }

        public void CalculateCutFill()
        {
            double existing_min_x = Double.NaN, existing_max_x = 0, existing_min_y = Double.NaN, existing_max_y = 0;
            double proposed_min_x = Double.NaN, proposed_max_x = 0, proposed_min_y = Double.NaN, proposed_max_y = 0;
            
            Dictionary<int, Point> existing_points = existing_graph.getPoints();
            Dictionary<int, Point> proposed_points = proposed_graph.getPoints();

            //Verify that the existing map fully overlaps the proposed map

            foreach(KeyValuePair<int, Point> kp1 in existing_points)
            {
                if(kp1.Value.get_x() < existing_min_x || Double.IsNaN(existing_min_x))
                {
                    existing_min_x = kp1.Value.get_x();
                }
                if (kp1.Value.get_x() > existing_max_x)
                {
                    existing_max_x = kp1.Value.get_x();
                }
                if (kp1.Value.get_y() < existing_min_y || Double.IsNaN(existing_min_y))
                {
                    existing_min_y = kp1.Value.get_y();
                }
                if (kp1.Value.get_y() > existing_max_y)
                {
                    existing_max_y = kp1.Value.get_y();
                }
            }

            foreach (KeyValuePair<int, Point> kp1 in proposed_points)
            {
                if (kp1.Value.get_x() < proposed_min_x || Double.IsNaN(proposed_min_x))
                {
                    proposed_min_x = kp1.Value.get_x();
                }
                if (kp1.Value.get_x() > proposed_max_x)
                {
                    proposed_max_x = kp1.Value.get_x();
                }
                if (kp1.Value.get_y() < proposed_min_y || Double.IsNaN(proposed_min_y))
                {
                    proposed_min_y = kp1.Value.get_y();
                }
                if (kp1.Value.get_y() > proposed_max_y)
                {
                    proposed_max_y = kp1.Value.get_y();
                }
            }

            if (proposed_min_x < existing_min_x || proposed_max_x > existing_max_x || proposed_min_y < existing_min_y || proposed_max_y > existing_max_y)
            {
                error = true;
                err_msg = "Existing map must completely overlap proposed map.";
            }

            //If it does, we can calculate the volumes.

            else
            {
                double step = 1;
                Dictionary<int, Triangle> existing_triangles = existing_graph.getTriangles();
                Dictionary<int, Triangle> proposed_triangles = proposed_graph.getTriangles();

                //Primary loop

                for (double i = proposed_min_x; i < proposed_max_x; i += step)
                {
                    //Create the scan edge and lists of intersection points
                    //The scan edge has a constant X-value, and runs between the top and bottom of the proposed map boundaries

                    Point temp_a = new Point(i, proposed_min_y, 0);
                    Point temp_b = new Point(i, proposed_max_y, 0);
                    Edge scan_edge = new Edge(temp_a, temp_b);
                    List<Point> existing_intersection_points = new List<Point>();
                    List<Point> proposed_intersection_points = new List<Point>();

                    double sectionAreaCut = 0;
                    double sectionAreaFill = 0;

                    //Now we find the intersection points from every triangle in each map.
                    //Starting with the existing map:

                    foreach (KeyValuePair<int, Triangle> e_triangle in existing_triangles)
                    {
                        List<Edge> tri_edges = e_triangle.Value.getEdges();
                        foreach (Edge t_edge in tri_edges)
                        {
                            if (t_edge.intersects(scan_edge))
                            {
                                Point tri_int_point = t_edge.getIntersectionPoint(scan_edge);
                                tri_int_point.set_elevation(e_triangle.Value.getHeightAtPoint(tri_int_point));
                                List<Point> duplicates = existing_intersection_points.FindAll(e => e == tri_int_point);
                                if(duplicates.Count == 0) existing_intersection_points.Add(tri_int_point);
                            }
                        }
                    }

                    //And then the proposed map:
                    foreach (KeyValuePair<int, Triangle> p_triangle in proposed_triangles)
                    {
                        List<Edge> tri_edges = p_triangle.Value.getEdges();
                        foreach (Edge t_edge in tri_edges)
                        {
                            if (t_edge.intersects(scan_edge))
                            {
                                Point tri_int_point = t_edge.getIntersectionPoint(scan_edge);
                                tri_int_point.set_elevation(p_triangle.Value.getHeightAtPoint(tri_int_point));
                                List<Point> duplicates = proposed_intersection_points.FindAll(e => e == tri_int_point);
                                if (duplicates.Count == 0) proposed_intersection_points.Add(tri_int_point);
                            }
                        }
                    }

                    //Check that we intersected both graphs
                    if (existing_intersection_points.Count > 1 && proposed_intersection_points.Count > 1)
                    {

                        //Now sort the points along the Y-axis.

/*                        existing_intersection_points.Sort(delegate(Point _x, Point _y) {
                            if (_x.get_y() > _y.get_y()) return 1;
                            else if (_x.get_y() == _y.get_y()) return 0;
                            else return -1;
                        });
                        proposed_intersection_points.Sort(delegate (Point _x, Point _y) {
                            if (_x.get_y() > _y.get_y()) return 1;
                            else if (_x.get_y() == _y.get_y()) return 0;
                            else return -1;
                        });*/

                        List<Point> sorted_existing_intersection_points = selectionSortPoints(existing_intersection_points);
                        List<Point> sorted_proposed_intersection_points = selectionSortPoints(proposed_intersection_points);

                        //At this point we can create imaginary edges between each point in both lists, so that we can measure the distances along every point between each line.
                        //Multiplied by the minimum distance between the lines, this will give us a total area between the curves.
                        //Further multiplying this by the step value will give us an approximate volume
                        //For areas where the existing line is above the proposed line, the difference should be added to the Cut value
                        //For areas where the existing line is below the proposed line, the difference show be added to the Fill value

                        List<Edge> existing_curve = new List<Edge>();
                        List<Edge> proposed_curve = new List<Edge>();

                        int existing_point_count = sorted_existing_intersection_points.Count;
                        int proposed_point_count = sorted_proposed_intersection_points.Count;

                        for (int j = 0; j < existing_point_count - 1; j++)
                        {
                            Edge temp_edge = new Edge(sorted_existing_intersection_points[j], sorted_existing_intersection_points[j + 1]);
                            existing_curve.Add(temp_edge);
                        }
                        for (int j = 0; j < proposed_point_count - 1; j++)
                        {
                            Edge temp_edge = new Edge(sorted_proposed_intersection_points[j], sorted_proposed_intersection_points[j + 1]);
                            proposed_curve.Add(temp_edge);
                        }

                        //Determine the range of the curve (i.e., ensure that we only scan between the two curves)
                        double range_min = 0;
                        double range_max = 0;
                        if (sorted_existing_intersection_points[0].get_y() >= sorted_proposed_intersection_points[0].get_y())
                        {
                            range_min = sorted_existing_intersection_points[0].get_y();
                        }
                        else
                        {
                            range_min = sorted_proposed_intersection_points[0].get_y();
                        }

                        if (sorted_existing_intersection_points[existing_point_count - 1].get_y() <= sorted_proposed_intersection_points[proposed_point_count - 1].get_y())
                        {
                            range_max = sorted_existing_intersection_points[existing_point_count - 1].get_y();
                        }
                        else
                        {
                            range_max = sorted_proposed_intersection_points[proposed_point_count - 1].get_y();
                        }

                        int existing_index = 0;
                        int proposed_index = 0;

                        for (double k = range_min; k < range_max; k += step)
                        {
                            if (k > existing_curve[existing_index].get_b().get_y()) existing_index++;
                            if (k > proposed_curve[proposed_index].get_b().get_y()) proposed_index++;

                            //double existing_slope = (existing_curve[existing_index].get_b().get_elevation() - existing_curve[existing_index].get_a().get_elevation()) / (existing_curve[existing_index].get_b().get_y() - existing_curve[existing_index].get_a().get_y());
                            //double proposed_slope = (proposed_curve[proposed_index].get_b().get_elevation() - proposed_curve[proposed_index].get_a().get_elevation()) / (proposed_curve[proposed_index].get_b().get_y() - proposed_curve[proposed_index].get_a().get_y());

                            //double existing_height = existing_curve[existing_index].get_a().get_elevation() + ((k - existing_curve[existing_index].get_a().get_y()) * existing_slope);
                            //double proposed_height = proposed_curve[proposed_index].get_a().get_elevation() + ((k - proposed_curve[proposed_index].get_a().get_y()) * proposed_slope);

                            Point existing_tp = new Point(i, k, 0);
                            Point proposed_tp = new Point(i, k, 0);

                            double existing_height = interpolateHeight(existing_curve[existing_index], existing_tp);
                            double proposed_height = interpolateHeight(proposed_curve[proposed_index], proposed_tp);

                            double diff = Math.Abs(existing_height - proposed_height);

                            //Set to 3 significant digits for now (not sure if it needs to be more accurate than that)
                            if (diff > 0.001)
                            {

                                if (existing_height > proposed_height)
                                {
                                    sectionAreaCut += (existing_height - proposed_height) * step; //This should result in an approximate area under the curve (can be improved)
                                }
                                else if (existing_height < proposed_height)
                                {
                                    sectionAreaFill += (proposed_height - existing_height) * step;
                                }
                            }

                        }

                        cut_amount += sectionAreaCut * step;
                        fill_amount += sectionAreaFill * step;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public double getCut()
        {
            return cut_amount;
        }

        public double getFill()
        {
            return fill_amount;
        }

        public bool getError()
        {
            return error;
        }

        public string getErrorMsg()
        {
            return err_msg;
        }

        private double interpolateHeight(Edge _e, Point _p)
        {
            if (_p.get_y() > _e.get_b().get_y())
            {
                return _e.get_b().get_elevation();
            }
            else if (_p.get_y() < _e.get_a().get_y())
            {
                return _e.get_a().get_elevation();
            }
            else
            {
                double h = 0;
                double dy_total = _e.get_b().get_y() - _e.get_a().get_y();
                if (Double.IsInfinity(1 / dy_total))
                {
                    return _e.get_a().get_elevation();
                }
                else
                {
                    double dy_a = _p.get_y() - _e.get_a().get_y();
                    double dy_b = _e.get_b().get_y() - _p.get_y();
                    double da_frac = dy_a / dy_total;
                    double db_frac = dy_b / dy_total;
                    h = (_e.get_a().get_elevation() * da_frac) + (_e.get_b().get_elevation() * db_frac);
                    return h;
                }
            }
        }

        //Shitty selection sort
        private List<Point> selectionSortPoints(List<Point> _points)
        {
            List<Point> ret_points = new List<Point>();
            List<Point> points = _points;
            while (points.Count > 0) {
                Point min_point = points[0];
                double min = Double.NaN;
                foreach (Point _p in points)
                {
                    if (_p.get_y() < min || Double.IsNaN(min))
                    {
                        min = _p.get_y();
                        min_point = _p;
                    }
                }
                ret_points.Add(min_point);
                points.Remove(min_point);
            }
            
            return ret_points;
        }

        //Shitty non-working insertion sort
        //TO DO: Debug and fix this (or not)
        private List<Point> sortPoints(List<Point> points)
        {
            List<Point> sorted_points = new List<Point>();
            double min_y = Double.NaN;

            //Iterate through all Dictionary points
            foreach (Point kp in points)
            {
                //If we find a value lower than the smallest Y-value found in the list, insert the new value to the front and set the new minimum Y value.
                if (kp.get_y() < min_y || Double.IsNaN(min_y))
                {
                    min_y = kp.get_y();
                    sorted_points.Insert(0, kp);
                }

                //Otherwise, we need to find where in the list the new point should go.
                else
                {
                    int index = 0;
                    //By the end of this loop, index should be set to the index of the list where the point should be stored.
                    foreach (Point p in sorted_points)
                    {
                        index = 0;
                        if (p.get_y() > kp.get_y())
                        {
                            index = sorted_points.IndexOf(p);
                            break;
                        }
                        //If the Y-values are equal, sort by the X coordinate instead.
                        else if (p.get_y() == kp.get_y())
                        {
                            if (p.get_x() < kp.get_x())
                            {
                                index = sorted_points.IndexOf(p);
                                break;
                            }
                            else
                            {
                                index = sorted_points.IndexOf(p) + 1;
                                break;
                            }
                        }
                        else continue;
                    }
                    sorted_points.Insert(index, kp);

                }
            }
            return sorted_points;
        }
    }
}
