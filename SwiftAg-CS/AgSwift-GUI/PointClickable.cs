using System.Collections.Generic;

namespace AgSwift_GUI
{
    public class PointClickable : SwiftAg_CS.Point
    {
        private bool selected = false;
        private List<PointClickable> connections;
        public PointClickable(double _x, double _y, double _elevation) : base(_x, _y, _elevation)
        {
            connections = new List<PointClickable>();
        }

        public bool getSelected()
        {
            return selected;
        }

        public void setSelected(bool _s)
        {
            selected = _s;
        }

        public void addConnection(PointClickable _p)
        {
            if(!connections.Contains(_p))
            {
                connections.Add(_p);
                _p.addConnection(this);
            }
        }

        public void removeConnection(PointClickable _p)
        {
            if (connections.Contains(_p))
            {
                connections.Remove(_p);
                _p.removeConnection(this);
            }
        }

        public List<PointClickable> getConnections()
        {
            return connections;
        }
    }
}
