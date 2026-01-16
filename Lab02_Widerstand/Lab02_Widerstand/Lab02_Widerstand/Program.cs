using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_Widerstand
{
    //Lab02_Widerstand

    class Resistor // Klasse == Bauplan
    {
        // Atribute,Member Variablen
        private string lable;
        private double value; //Widerstand
        private double toleranz; //Tolleranz
        private double maxPower;

        // Methoden
        //Konstruktormethoden
        public Resistor(string lable ,double value ,double toleranz ,double maxPower)
        {
            this.lable = lable;
            this.value = value;
            this.toleranz = toleranz;
            this.maxPower = maxPower;
            
        }
        
        //Zugriffsmethoden Getter und Setter
        public double GetValue()
        {
            return value;
        }
        public  double CalculateCurrent(double voltage)
        {
            double i = voltage / this.value;
            return i;

        }
        public double CalculateVoltage(double curent)
        {
            double u = curent / this.value;
            return u;
        }
        public double Seriel(Resistor Resistor2)
        {
            double R_Ges = Resistor2.value + this.value;
            return R_Ges;
        }

        public double Parralell(Resistor Resistor2)
        {
            double R_Ges_parral = 1/(1/Resistor2.value + 1/this.value);
            return R_Ges_parral;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Resistor r1 = new Resistor("R1",100, 5, 10); // Objekt r1 vom Typ Resistor
            Resistor r2 = new Resistor("R2",200, 1, 20); // Objekt r2 ...
            double current = r1.CalculateCurrent(5);
            double Rges_ser = r1.Seriel(r2);
            double Rges_par = r1.Parralell(r2);
            
            Console.WriteLine("sind die widerstände Parralell oder seriell");
            string Imput =Console.ReadLine();
            Console.WriteLine("gib 2 wiederstände mit namen ohm ; tolleranz; max leistung ein ");
            string r3 = Console.ReadLine();
            string r4 = Console.ReadLine();
            double Rges = 0;
            Resistor R3 = r3.Split(";");
            Resistor R4 = r4.Split(";");
            if (Imput == "seriell")
            {
                Rges = R3.Seriel(R4);
                Console.WriteLine(Rges);
            }
            else if (Imput == "parralel")
            {
                Rges = R3.Parralell(R4);
                Console.WriteLine(Rges);
            }

        }
    }
}
