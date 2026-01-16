using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Bruchrechnung
{
    internal class Bruchrechnung
    {
        Bruch b1;
        Bruch b2;

        public override Bruchrechnung Pares(string line)
        {
            if (line.Contains('+'))
            {
            string[] parts = line.Split('+');
            this.b1 = parts[0];
            this.b2 = parts[1];

            }
            
        }
    }
}
