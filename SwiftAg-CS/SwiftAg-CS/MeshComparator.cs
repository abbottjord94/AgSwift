using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftAg_CS
{
    class MeshComparator
    {
        private Graph existing_graph;
        private Graph proposed_graph;

        private double cut_amount, fill_amount = 0;

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

        }

        public double getCut()
        {
            return cut_amount;
        }

        public double getFill()
        {
            return fill_amount;
        }
    }
}
