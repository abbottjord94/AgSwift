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

        //TODO
        public void bowyerWatsonTriangulation()
        {

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
