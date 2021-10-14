using System;
using System.Collections.Generic;

namespace SwiftAg_CS
{
    public class Graph
    {
        private Dictionary<int, Point> points;
        private List<Point> sorted_points;

        //Current implementation allows equivalent edges to live at different locations in dictionary 9/17/21 -RH
        private Dictionary<int, Edge> edges;
        private Dictionary<int, Triangle> triangles;

        //Adding coordinate minimum and maximum counters
        private double xmin, ymin = Double.NaN;
        private double xmax, ymax = 0;

        public Graph()
        {
            points = new Dictionary<int, Point>();
            edges = new Dictionary<int, Edge>();
            triangles = new Dictionary<int, Triangle>();
            sorted_points = new List<Point>();
        }

        public Graph(Graph _g)
        {
            points = _g.points;
            edges = _g.edges;
            triangles = _g.triangles;
        }

        public void addPoint(Point _p)
        {
            int h = _p.GetHashCode();
            if(!points.ContainsKey(h))
            {
                if(_p.get_x() > xmax)
                {
                    xmax = _p.get_x();
                }
                if (_p.get_y() > ymax)
                {
                    ymax = _p.get_y();
                }
                if (_p.get_x() < xmin || Double.IsNaN(xmin))
                {
                    xmin = _p.get_x();
                }
                if (_p.get_y() < ymin || Double.IsNaN(ymin))
                {
                    ymin = _p.get_y();
                }
                points.Add(h, _p);
            }
        }

        private void selectionSortPoints()
        {
            List<Point> pointsList = new List<Point>();
            foreach(KeyValuePair<int, Point> kp in getPoints())
            {
                pointsList.Add(kp.Value);
            }
            sorted_points.Clear();
            double min_y = Double.NaN;
            double min_x = 0;
            Point min_point;

            while (pointsList.Count > 0)
            {
                min_point = pointsList[0];
                foreach (Point _p in pointsList)
                {
                    min_y = Double.NaN;
                    min_x = 0;
                    min_point = _p;
                    if (_p.get_y() < min_y || Double.IsNaN(min_y))
                    {
                        min_y = _p.get_y();
                        min_x = _p.get_x();
                        min_point = _p;
                    }
                    else if(_p.get_y() == min_y)
                    {
                        if(min_x > _p.get_x())
                        {
                            min_y = _p.get_y();
                            min_x = _p.get_x();
                            min_point = _p;
                        }
                    }
                }
                sorted_points.Add(min_point);
                pointsList.Remove(min_point);
            }
        }

        private void sortPoints()
        {
            sorted_points.Clear();
            double min_y = Double.NaN;

            //Iterate through all Dictionary points
            foreach(KeyValuePair<int, Point> kp in points)
            {
                //If we find a value lower than the smallest Y-value found in the list, insert the new value to the front and set the new minimum Y value.
                if (kp.Value.get_y() < min_y || Double.IsNaN(min_y))
                {
                    min_y = kp.Value.get_y();
                    sorted_points.Insert(0, kp.Value);
                }

                //Otherwise, we need to find where in the list the new point should go.
                else
                {
                    int index = 0;
                    //By the end of this loop, index should be set to the index of the list where the point should be stored.
                    foreach(Point p in sorted_points)
                    {
                        if (p.get_y() > kp.Value.get_y())
                        {
                            index = sorted_points.IndexOf(p);
                            break;
                        }
                        //If the Y-values are equal, sort by the X coordinate instead.
                        else if(p.get_y() == kp.Value.get_y())
                        {
                            if(p.get_x() < kp.Value.get_x())
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
                    sorted_points.Insert(index, kp.Value);

                }
            }
        }

        public bool containsPoint(Point _p)
        {
            if (points.ContainsKey(_p.GetHashCode())) return true;
            else return false;
        }

        public void removePoint(Point _p)
        {
            int h = _p.GetHashCode();
            if(points.ContainsKey(h))
            {
                points.Remove(h);
            }
        }

        public void addEdge(Edge _e)
        {
            int h = _e.GetHashCode();
            if (!edges.ContainsKey(h))
            {
                edges.Add(h, _e);
            }
        }

        public bool containsEdge(Edge _e)
        {
            if (edges.ContainsKey(_e.GetHashCode())) return true;
            else return false;
        }

        public void removeEdge(Edge _e)
        {
            int h = _e.GetHashCode();
            if(edges.ContainsKey(h))
            {
                edges.Remove(h);
            }
        }

        public void addTriangle(Triangle _t)
        {
            int h = _t.GetHashCode();
            if (!triangles.ContainsKey(h))
            {
                triangles.Add(h, _t);
            }
        }

        public bool containsTriangle(Triangle _t)
        {
            foreach(KeyValuePair<int, Triangle> kp in triangles)
            {
                if(kp.Value.equivalent(_t))
                {
                    return true;
                }
            }
            return false;
        }

        public void removeTriangle(Triangle _t)
        {
            int h = _t.GetHashCode();
            if(triangles.ContainsKey(h))
            {
                triangles.Remove(h);
            }
        }

        public int pointCount()
        {
            return points.Count;
        }

        public int edgeCount()
        {
            return edges.Count;
        }

        public int triangleCount()
        {
            return triangles.Count;
        }

        public Dictionary<int, Point> getPoints()
        {
            return points;
        }
        public Dictionary<int, Edge> getEdges()
        {
            return edges;
        }
        public Dictionary<int, Triangle> getTriangles()
        {
            return triangles;
        }

        public bool delaunayTest(Triangle _t) 
        {
            Tuple<Point, double> cc = _t.circumcircle();
            foreach(KeyValuePair<int, Point> kp in points)
            {
                if(kp.Value.distance(cc.Item1) < cc.Item2)
                {
                    return false;
                }
            }
            return true;
        }

        public void clearGraph()
        {
            points.Clear();
            edges.Clear();
            triangles.Clear();
            xmin = Double.NaN;
            ymin = Double.NaN;
            xmax = 0;
            ymax = 0;
        }

        public void generateRandomPoints(int _numPoints, int _max_x, int _max_y)
        {
            Random rnd = new Random();
            for (int i = 0; i < _numPoints; i++)
            {
                int x_val = rnd.Next() % _max_x;
                int y_val = rnd.Next() % _max_y;
                Point randGenPoint = new Point(x_val, y_val, 0);
                if (!points.ContainsKey(randGenPoint.GetHashCode())) addPoint(randGenPoint);
            }
        }

        private List<Edge> generatePolygon(List<Triangle> badTriangles)
        {
            List<Edge> polygon = new List<Edge>();
            
            //Adding all edges to the polygon
            foreach (Triangle t in badTriangles)
            {
                polygon.Add(t.get_ab());
                polygon.Add(t.get_bc());
                polygon.Add(t.get_ca());
            }

            //Delete any edges that repeat and return
            List<Edge> ret_poly = new List<Edge>();
            foreach(Edge e1 in polygon)
            {
                bool found = false;
                foreach(Edge e2 in polygon)
                {
                    if(polygon.IndexOf(e1) != polygon.IndexOf(e2) && e1 == e2)
                    {
                        found = true;
                    }
                }
                if(!found)
                {
                    ret_poly.Add(e1);
                }
            }

            return ret_poly;

        }

        public void bowyerWatsonTriangulation()
        {
            triangles.Clear();
            edges.Clear();
            selectionSortPoints();
            //Calculate maximum difference between x and y coordinates in point set
            double dmax;
            double dx = xmax - xmin;
            double dy = ymax - ymin;
            if(dy > dx)
            {
                dmax = dy - dx;
            } else
            {
                dmax = dx - dy;
            }

            //Calculate midpoints of x and y coordinates in point set
            double xmid = (xmax + xmin) / 2;
            double ymid = (ymax + ymin) / 2;

            //Creating supertriangle and adding their points to the triangulation
            Point supTriPoint_a = new Point(xmid - 2 * dmax, ymid - dmax, 0);
            Point supTriPoint_b = new Point(xmid, ymid + 2 * dmax, 0);
            Point supTriPoint_c = new Point(xmid + 2 * dmax, ymid - dmax, 0);

            Triangle superTriangle = new Triangle(supTriPoint_a, supTriPoint_b, supTriPoint_c);
            addTriangle(superTriangle);

            points.Clear(); //lmao

            foreach (Point p in sorted_points)
            {
                if (p == supTriPoint_a || p == supTriPoint_b || p == supTriPoint_c) continue;
                addPoint(p); //lmao
                List<Triangle> badTriangles = new List<Triangle>();
                foreach (KeyValuePair<int, Triangle> triangleHashPair in triangles)
                {
                    Triangle t = triangleHashPair.Value;
                    Tuple<Point, double> centerAndRadius = t.circumcircle();
                    if (p.distance(centerAndRadius.Item1) < centerAndRadius.Item2)
                    {
                        badTriangles.Add(t);
                    }
                }
                List<Edge> polygon = generatePolygon(badTriangles);
                foreach(Triangle badTri in badTriangles)
                {
                    removeTriangle(badTri);
                }
                foreach (Edge polyEdge in polygon)
                {
                    Triangle newTri = new Triangle(p, polyEdge);
                    if (!containsTriangle(newTri))
                    {
                        addTriangle(newTri);
                    }
                    
                }
            }

            List<Triangle> supTriConnections = new List<Triangle>();
            foreach(KeyValuePair<int, Triangle> t in triangles)
            {
                if(t.Value.containsPoint(supTriPoint_a) || t.Value.containsPoint(supTriPoint_b) || t.Value.containsPoint(supTriPoint_c))
                {
                    supTriConnections.Add(t.Value);
                }
            }

            foreach(Triangle t in supTriConnections)
            {
                if(containsTriangle(t))
                {
                    removeTriangle(t);
                }
            }

            removeTriangle(superTriangle);
        }

        private void addEdgesOfTriangle(Triangle _t)
        {
            foreach(Edge e in _t.getEdges())
            {
                addEdge(e);
            }
        }

        public void triangulate()
        {
            foreach(KeyValuePair<int, Point> pt1 in points)
            {
                foreach (KeyValuePair<int, Point> pt2 in points)
                {
                    foreach (KeyValuePair<int, Point> pt3 in points)
                    {
                        if( (pt1.Value != pt2.Value) && (pt2.Value != pt3.Value) && (pt3.Value != pt1.Value))
                        {
                            Triangle test_tri = new Triangle(pt1.Value, pt2.Value, pt3.Value);
                            if(delaunayTest(test_tri) && !containsTriangle(test_tri))
                            {
                                addTriangle(test_tri);
                            }
                        }
                    }
                }
            }

            foreach(KeyValuePair<int, Triangle> t in triangles)
            {
                addEdge(t.Value.get_ab());
                addEdge(t.Value.get_bc());
                addEdge(t.Value.get_ca());
            }
        }
    }
}
