﻿using System;
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

        public bool addConnection(Edge _e)
        {
            bool added = false;
            if (!connections.Contains(_e))
            {
                connections.Add(_e);
                added = true;
            }
            return added;
        }

        public double distance(Point _p)
        {
            return Math.Sqrt(Math.Pow(_p.get_x() - x, 2) + Math.Pow(_p.get_y() - y, 2));
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

    }
}
