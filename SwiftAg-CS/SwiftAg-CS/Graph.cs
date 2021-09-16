using System;
using System.Collections.Generic;

namespace SwiftAg_CS
{
    public class Graph
    {
        private Dictionary<int, Point> points;
        private Dictionary<int, Edge> edges;
        private Dictionary<int, Triangle> triangles;

        public Graph()
        {
            points = new Dictionary<int, Point>();
            edges = new Dictionary<int, Edge>();
            triangles = new Dictionary<int, Triangle>();
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
                points.Add(h, _p);
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
                if (kp.Value.equivalent(_t)) return true;
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

        public void selfContainedBowyerWatsonTriangulation()
        {
            edges.Clear();
            triangles.Clear();

            /*            for (int i = 0; i < 20; i++)
                        {
                            int x_max = 1000;
                            int y_max = 600;
                            int x_val = rnd.Next() % x_max;
                            int y_val = rnd.Next() % y_max;
                            Point randGenPoint = new Point(x_val, y_val, 0);
                            points.Add(randGenPoint.GetHashCode(), randGenPoint);
                        }*/

            Point supertri_p1 = new Point(0, 0, 0);
            Point supertri_p2 = new Point(500, 1000, 0);
            Point supertri_p3 = new Point(1000, 0, 0);

            Triangle superTriangle = new Triangle(supertri_p1,supertri_p2,supertri_p3);
            addTriangle(superTriangle);
            //addEdgesOfTriangle(superTriangle);

            foreach (KeyValuePair<int, Point> pointHashPair in points)
            {
                Point p = pointHashPair.Value;
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
                List<Edge> polygon = new List<Edge>();
                foreach (Triangle badTri in badTriangles)
                {
                    List<Edge> badtri_edges = badTri.getEdges();
                    foreach (Edge badEdge in badtri_edges)
                    {
                        if (polygon.Contains(badEdge))
                        {
                            polygon.Remove(badEdge);
                            edges.Remove(badEdge.GetHashCode());
                            triangles.Remove(badTri.GetHashCode());
                        }
                        else
                        {
                            polygon.Add(badEdge);
                        }
                    }
                }
                foreach (Edge polyEdge in polygon)
                {
                    Triangle newTri = new Triangle(p, polyEdge);
                    addTriangle(newTri);
                    // addEdgesOfTriangle(newTri);
                }
            }
            //TODO: clean up supertriangle
            Dictionary<int, Triangle> tris_copy = new Dictionary<int, Triangle>(triangles);
            foreach(KeyValuePair<int, Triangle> t in triangles)
            {
                if(t.Value.containsPoint(supertri_p1) || t.Value.containsPoint(supertri_p2) || t.Value.containsPoint(supertri_p3))
                {
                    tris_copy.Remove(t.Key);
                }
            }

            triangles = new Dictionary<int, Triangle>(tris_copy);
            // removeTriangle(superTriangle);
        }

        private void addEdgesOfTriangle(Triangle _t)
        {
            foreach(Edge e in _t.getEdges())
            {
                addEdge(e);
            }
        }

        public void addPointToTriangulation(Point _p)
        {
            addPoint(_p);
            switch(pointCount())
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    List<Point> pts = new List<Point>();
                    foreach(KeyValuePair<int, Point> kp in points)
                    {
                        pts.Add(kp.Value);
                    }
                    Triangle new_tri = new Triangle(pts[0], pts[1], pts[2]);
                    addTriangle(new_tri);
                    break;
                default:
                    List<Triangle> bad_tris = new List<Triangle>();
                    foreach(KeyValuePair<int, Triangle> kp in triangles)
                    {
                        if(!delaunayTest(kp.Value)) {
                            bad_tris.Add(kp.Value);
                        }
                    }
                    if(bad_tris.Count == 0)
                    {
                        foreach(KeyValuePair<int, Point> kp1 in points)
                        {
                            foreach(KeyValuePair<int, Point> kp2 in points)
                            {
                                if(kp1.Value != kp2.Value && kp2.Value != _p && kp1.Value != _p)
                                {
                                    Triangle test_tri = new Triangle(kp1.Value, kp2.Value, _p);
                                    if (delaunayTest(test_tri) && !containsTriangle(test_tri))
                                    {
                                        addTriangle(test_tri);
                                    }
                                }
                            }
                        }
                    } 
                    else
                    {
                        if(bad_tris.Count == 1)
                        {
                            Point pt1 = bad_tris[0].get_a();
                            Point pt2 = bad_tris[0].get_b();
                            Point pt3 = bad_tris[0].get_c();
                            Triangle tri1 = new Triangle(pt1, pt2, pt3);
                            Triangle tri2 = new Triangle(_p, pt2, pt3);
                            Triangle tri3 = new Triangle(pt1, _p, pt3);
                            Triangle tri4 = new Triangle(pt1, pt2, _p);
                            removeTriangle(bad_tris[0]);
                            if(!containsTriangle(tri1) && !tri1.collinear())
                            {
                                addTriangle(tri1);
                            }
                            if(!containsTriangle(tri2) && !tri2.collinear())
                            {
                                addTriangle(tri2);
                            }
                            if(!containsTriangle(tri3) && !tri3.collinear())
                            {
                                addTriangle(tri3);
                            }
                            if(!containsTriangle(tri4) && !tri4.collinear())
                            {
                                addTriangle(tri4);
                            }
                        }
                        else
                        {
                            Dictionary<int, Edge> polygon = new Dictionary<int, Edge>();
                            Dictionary<int, Edge> copy_polygon = new Dictionary<int, Edge>();

                            foreach (Triangle t in bad_tris)
                            {
                                polygon.Add(t.get_ab().GetHashCode(), t.get_ab());
                                polygon.Add(t.get_bc().GetHashCode(), t.get_bc());
                                polygon.Add(t.get_ca().GetHashCode(), t.get_ca());

                                removeTriangle(t);
                            }

                            copy_polygon = new Dictionary<int, Edge>(polygon);

                            foreach(KeyValuePair<int, Edge> poly_edge1 in polygon)
                            {
                                foreach(KeyValuePair<int, Edge> poly_edge2 in polygon)
                                {
                                    if(poly_edge1.Key != poly_edge2.Key && poly_edge1.Value == poly_edge2.Value)
                                    {
                                        copy_polygon.Remove(poly_edge1.Key);
                                        copy_polygon.Remove(poly_edge2.Key);
                                    }
                                }
                            }

                            foreach(KeyValuePair<int, Edge> poly_edge in copy_polygon)
                            {
                                Triangle t1 = new Triangle(_p, poly_edge.Value);
                                if(delaunayTest(t1) && !containsTriangle(t1) && !t1.collinear())
                                {
                                    addTriangle(t1);
                                }
                                
                            } 
                        }
                    }
                    break;
            }
        }

        public void triangulate()
        {
            triangles.Clear();
            edges.Clear();
            foreach(KeyValuePair<int, Point> pt1 in points)
            {
                foreach (KeyValuePair<int, Point> pt2 in points)
                {
                    foreach (KeyValuePair<int, Point> pt3 in points)
                    {
                        if( (pt1.Value != pt2.Value) && (pt2.Value != pt3.Value) && (pt3.Value != pt1.Value))
                        {
                            Triangle test_tri = new Triangle(pt1.Value, pt2.Value, pt3.Value);
                            if(delaunayTest(test_tri) && !containsTriangle(test_tri) && !test_tri.collinear())
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
