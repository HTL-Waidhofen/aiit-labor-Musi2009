using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Strommessung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabeWiederstand;
            string eingabeSpannung;
            string stop;
            float rechenSpannung = 0;
            float rechenWiederstand = 0;
            float rechenStrom;
            do
            {
                



                Console.WriteLine("Wenn sie das programm stoppen wollen dan geben sie entweder 'end' oder 'q' ein");
                stop = Console.ReadLine();
                Console.WriteLine("Gieb einen ohm wert ein(anz;Ohm,anz;kOhm,anz;MOhm)");
                eingabeWiederstand = Console.ReadLine();
                string[] eingabeWiederstand_split = eingabeWiederstand.Split(';');

                Console.WriteLine("Gib einen Volt wert ein (V,kV,mV)");
                eingabeSpannung = Console.ReadLine();
                string[] eingabeSpannung_split = eingabeSpannung.Split(';');

                if (eingabeWiederstand_split[1] == "Ohm")
                {
                     rechenWiederstand = float.Parse(eingabeWiederstand_split[0]);
                   

                }

                else if (eingabeWiederstand_split[1] == "kOhm")
                {
                     rechenWiederstand = float.Parse(eingabeWiederstand_split[0]);
                    rechenWiederstand = rechenWiederstand * 1000;
                    
                }

                 else if (eingabeWiederstand_split[1] == "MOhm")
                {
                     rechenWiederstand = float.Parse(eingabeWiederstand_split[0]);
                    rechenWiederstand = rechenWiederstand * 1000000;
                   
                }
                else
                {
                    Console.WriteLine("Eingabe Fehler");
                }


                if (eingabeSpannung_split[1] == "V")
                {
                    rechenSpannung = float.Parse(eingabeSpannung_split[0]);

                }

                else if (eingabeSpannung_split[1] == "kV")
                {
                     rechenSpannung = float.Parse(eingabeSpannung_split[0]);
                    rechenSpannung=rechenSpannung * 1000;
                    
                }

                else if (eingabeSpannung_split[1] == "mV")
                {
                     rechenSpannung = float.Parse(eingabeSpannung_split[0]);
                    rechenSpannung = rechenSpannung / 1000;
                    
                }
                else
                {
                    Console.WriteLine("Eingabe Fehler");
                }


                rechenStrom = rechenSpannung / rechenWiederstand;
                Console.WriteLine($" Der strom ist {0}A" ,rechenStrom);

            } while (stop != "end" && stop != "q");
            Console.ReadKey();
        }
    }
}
