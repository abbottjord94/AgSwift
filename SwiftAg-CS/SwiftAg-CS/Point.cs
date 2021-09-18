using System;
using System.Collections.Generic;

namespace SwiftAg_CS
{
    public class Point
    {
        private double x;
        private double y;
        private double elevation;
        private List<Edge> connections;

        public Point(double _x, double _y, double _elevation)
        {
            x = _x;
            y = _y;
            elevation = _elevation;
            connections = new List<Edge>();
        }

        public void set_x(double _x)
        {
            x = _x;
        }

        public void set_y(double _y)
        {
            y = _y;
        }

        public void set_elevation(double _elevation)
        {
            elevation = _elevation;
        }

        public double get_x()
        {
            return x;
        }

        public double get_y()
        {
            return y;
        }

        public double get_elevation()
        {
            return elevation;
        }

        public List<Edge> get_connections()
        {
            return connections;
        }

        public void addConnection(Edge _e)
        {
            if (!connections.Contains(_e))
            {
                connections.Add(_e);
            }

            //This implementation causes errors, likely as a result of Edges existing in the graph with no way to remove the unique objects when deleting a point
            //Fixing equivalent edge bug in graph edge dictionary will go long way to resolve this
            /*foreach(Edge connection in connections)
            {
                if (connection == _e) return;
            }
            connections.Add(_e);*/
        }

        public double distance(Point _p)
        {
            return Math.Sqrt(Math.Pow(_p.get_x() - x, 2) + Math.Pow(_p.get_y() - y, 2));
        }

        public bool closerToOriginThan(Point _p)
        {
            //Calculates the distance from point (0,0) and checks if the calling point is closer
            //in cases of equidistance, the point with the lowest x value is treated as closer
            // in cases of equidistance and equal x values, the lowest y value is treated as closer
            //Helpful in creating uniform storage order in sorted lists, edge objects, triangle objects, ets.
            //THIS IS A HACK TO SOLVE THE IDENTICAL EDGES WITH DIFFERNET HASHING PROBLEM. TODO: FIND BETTER ANSWER - RH
            bool retval= false;
            Point origin = new Point(0, 0, 0);
            if (this.distance(origin) > _p.distance(origin)) retval = true;
            else if (this.distance(origin) < _p.distance(origin)) retval = false;
            else if (this.distance(origin) == _p.distance(origin)){
                if (this.get_x() < _p.get_x()) retval = true;
                else if (this.get_x() > _p.get_x()) retval = false;
                else if (this.get_x() == _p.get_x())
                {
                    if (this.get_y() < _p.get_y()) retval = true;
                    else if (this.get_y() > _p.get_y()) retval = false;
                    else throw new ArgumentException("Identical Point Error");
                }
            }
            return retval;
        }

        public static bool operator==(Point _a, Point _b)
        {
            if (_a.get_x() == _b.get_x() && _a.get_y() == _b.get_y()) return true;
            else return false;
        }

        public static bool operator!=(Point _a, Point _b)
        {
            if (_a.get_x() == _b.get_x() && _a.get_y() == _b.get_y()) return false;
            else return true;
        }

        //TODO: Write a cleanup function to call when deleting a point. May need to be on graph

    }
}
