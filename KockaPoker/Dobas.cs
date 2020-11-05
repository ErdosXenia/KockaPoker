using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker
{
    class Dobas
    {
        int[] kockak = new int[5];

        public Dobas()
        {

        }

        /*public Dobas(int k1, int k2, int k3, int k4, int k5)
        {
            kockak[0] = k1;
            kockak[1] = k2;
            kockak[2] = k3;
            kockak[3] = k4;
            kockak[4] = k5;
        }*/

        public void EgyDobas()
        {
            Random rnd = new Random();
            for (int i = 0; i < kockak.Length; i++)
            {
                kockak[i] = rnd.Next(1, 7);
            }
        }

        public void Kiiras()
        {
            foreach (var k in kockak)
            {
                Console.Write($"{k} ");
            }
        }

        public string Erteke()
        {
            Dictionary<int, int> eredmeny = new Dictionary<int, int>();

            for (int i = 0; i <= 6; i++)
            {
                eredmeny.Add(i, 0);
            }
            foreach (var k in kockak)
            {
                eredmeny[k]++;
            }

            /*A divtionary lekérdezzük az 1 value-nál nagyobb elemeiket.
             * Első eset: egy elem marad(value értékét nézzük):
             *      - 5 -> nagypóker
             *      - 4 -> póker
             *      - 3 -> drill
             *      - 2 -> pár
             *   Key érték mondja neg hogy hanyas, pl.: 4 póker
             * Második eset: két elem marad:
             *      - 3 és 2 -> full
             *      - 2 és 2 -> 2 pár
             * Harmadik eset: nem marad egy sem:
             *      - Ha Key: 6 == 0 -> Kissor
             *      - Ha Key: 1 == 0 -> Nagysor
             * Negyedik eset: szemét
             */

            var result = (from e in eredmeny
                         orderby e.Value descending 
                         where e.Value > 1
                         select new { Szam = e.Key, db = e.Value }).ToList();

            //result.Sort((a, b) => a.Szam.CompareTo(b.Szam)); --> le lehet így rövidíteni a kódot*

            Console.WriteLine();

            int darab = result.Count;

            if (darab == 1)
            {
                string[] egyes = new string[] { "", "", "Pár", "Drill", "Póker", "Nagypóker" };
                return $"{result[0].Szam} {egyes[result[0].db]}";

                /*switch (result[0].db)
                {
                    case 5:
                        return $"{result[0].Szam} Nagypóker";

                    case 4:
                        return $"{result[0].Szam} Póker";

                    case 3:
                        return $"{result[0].Szam} Drill";

                    case 2:
                        return $"{result[0].Szam} Pár";

                }*/
            }
            
            else if (darab == 2)
            {
                if (result[0].db == 3 && result[1].db == 2)
                {
                    return $"{result[0].Szam}-{result[1].Szam} Full";
                }
                else//*ez ide nem kell ha azt beírjuk
                {
                    if (result[0].Szam > result[1].Szam)
                    {
                        return $"{result[0].Szam}-{result[1].Szam} Pár";
                    }
                    else
                    {
                        return $"{result[1].Szam}-{result[0].Szam} Pár";
                    }
                }
            }
           
            else
            {
                if (eredmeny[6] == 0)
                {
                    return "Kissor";
                }
                else if (eredmeny[1] == 0)
                {
                    return "Nagysor";
                }
            }

            return "Szemét";
        }
    }
}
