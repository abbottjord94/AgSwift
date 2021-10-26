namespace AgSwift_GUI
{
    public class EdgeClickable : SwiftAg_CS.Edge
    {
        PointClickable _pc_a, _pc_b;
        private bool selected = false;
        public EdgeClickable(PointClickable _a, PointClickable _b) : base(_a, _b)
        {
            _pc_a = _a;
            _pc_b = _b;
            _a.addConnection(_b);
            _b.addConnection(_a);
        }

        ~EdgeClickable()
        {
            _pc_a.removeConnection(_pc_b);
            _pc_b.removeConnection(_pc_a);
        }

        public bool getSelected()
        {
            return selected;
        }

        public void setSelected(bool _s)
        {
            selected = _s;
        }

        public void deleteEdge()
        {
            _pc_a.removeConnection(_pc_b);
            _pc_b.removeConnection(_pc_a);
        }
    }
}
