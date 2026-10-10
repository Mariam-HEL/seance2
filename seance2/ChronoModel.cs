using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seance2
{
    internal class ChronoModel
    {
        public int Secondes { get; private set; }
        public void Incrementer()
        {
            Secondes++;
        }
        public void Reinitialiser()
        {
            Secondes = 0;
        }
    }
}
