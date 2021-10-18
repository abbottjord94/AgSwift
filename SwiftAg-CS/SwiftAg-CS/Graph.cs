using System;
using System.Collections.Generic;

namespace SwiftAg_CS
{
    public class Graph
    {
        private Dictionary<int, Point> points;

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

        public void createTriangulation()
        {
            triangles.Clear();
            List<Vertex> vertices = new List<Vertex>();
            List<Point> graph_points = new List<Point>();
            List<Triad> triads = new List<Triad>();
            foreach(KeyValuePair<int, Point> pts in points)
            {
                Point pt = pts.Value;
                graph_points.Add(pt);
                Vertex new_vertex = new Vertex(pt.get_x(), pt.get_y());
                vertices.Add(new_vertex);
            }

            Triangulator triangulator = new Triangulator();
            triads = triangulator.Triangulation(vertices, true);
            foreach(Triad t in triads)
            {
                Triangle new_tri = new Triangle(graph_points[t.a], graph_points[t.b], graph_points[t.c]);
                addTriangle(new_tri);
            }
        }
    }
}
