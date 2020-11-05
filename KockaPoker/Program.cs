using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker
{
    class Program
    {
        static void Ellenorzes()
        {
            StreamReader sr = new StreamReader("teszteles.txt");
            while (!sr.EndOfStream)
            {
                string[] a = sr.ReadLine().Split(',');
                List<int> sz = a.Select(x => int.Parse(x)).ToList();
                //Dobas d=new Dobas(Convert.ToINt32(a[0]));
                Dobas d = new Dobas(sz[0], sz[1], sz[2], sz[3], sz[4]);

                d.Kiiras();
            }
            sr.Close();
        }

        static void Main(string[] args)
        {
            Dobas gep = new Dobas();
            Dobas ember = new Dobas();

            gep.EgyDobas();
            ember.EgyDobas();

            gep.Kiiras();
            ember.Kiiras();
            //Ellenorzes();
            

            Console.ReadKey();
        }
    }
}
