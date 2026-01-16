using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Bruchrechnung
{
    class Bruch
    {
        int zaehler;
        int nenner;

        public Bruch(int zaehler, int nenner)
        {
            this.zaehler = zaehler;
            this.nenner = nenner;
        }
        
        public override string ToString()
        {
            return $"{zaehler}/{nenner}";
        }
        public int getZaehler()
        {
            return zaehler;
        }
        public int getNenner()
        {
            if (nenner == 0)
             throw new Exception();
                         
            return nenner;
        }
        public void setZaehler(int zaehler)
        {
            this.zaehler = zaehler;
        }
        public void setNenner(int nenner)
        {
            this.nenner = nenner;
        }
        public static Bruch Parse(string str)
        {
            string[] teile = str.Split('/');
            int zaehler = int.Parse(teile[0]);
            int nenner = int.Parse(teile[1]);
            return new Bruch(zaehler, nenner);
        }
        public void Kuerzen()
        {
            int kleinster = Math.Min(zaehler, nenner);
            for (int i = kleinster; i > 1; i--)
            {
                if ((zaehler % i == 0) && (nenner % i == 0))
                {
                    zaehler /= i;
                    nenner /= i;
                    break;
                }
            }
        }
        public void Add(Bruch b)
        {
            this.zaehler = this.zaehler * b.getNenner() + b.getZaehler() * this.nenner;
            this.nenner = this.nenner * b.getNenner();
            Kuerzen();
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                // Eingabe 67/69
                Console.Write("bitte bruch eingeben: ");
                string line1 = Console.ReadLine();
                
                Console.Write("bitte bruch eingeben: ");
                string line2 = Console.ReadLine();
                Bruch a = Bruch.Parse(line1);
                Bruch b = Bruch.Parse(line2);
                b.Kuerzen();
                b.Add(a);
                Console.WriteLine("gekürzter bruch:");
                Console.WriteLine(b.ToString());

                Console.WriteLine();
            }
        }
    }
}
