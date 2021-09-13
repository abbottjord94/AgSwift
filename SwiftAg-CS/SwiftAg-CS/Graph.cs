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
            if (triangles.ContainsKey(_t.GetHashCode())) return true;
            else return false;
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
            points.Clear();
            edges.Clear();
            triangles.Clear();

            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                int x_max = 50;
                int y_max = 50;
                int x_val = rnd.Next() % x_max;
                int y_val = rnd.Next() % y_max;
                Point randGenPoint = new Point(x_val, y_val, 0);
                points.Add(randGenPoint.GetHashCode(), randGenPoint);
            }
            Triangle superTriangle = new Triangle(new Point(0, 0, 0), new Point(0, 100, 0), new Point(100, 0, 0));
            addTriangle(superTriangle);
            addEdgesOfTriangle(superTriangle);

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
                    foreach (Edge badEdge in badTri.getEdges())
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
                    addEdgesOfTriangle(newTri);
                }
            }
            //TODO: clean up supertriangle
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
                        if( (pt1.Key != pt2.Key) && (pt2.Key != pt3.Key) && (pt3.Key != pt1.Key))
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
