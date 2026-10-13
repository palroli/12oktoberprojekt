namespace oktoberprojektC_
{
    internal class Program
    {
        class Konyv
        {
            public string Cim;
            public string Szerzo;
            public int Ev;
            public int Oldal;
            public int Ar;

            public Konyv(string c, string sz, int e, int o, int a)
            {
                Cim = c;
                Szerzo = sz;
                Ev = e;
                Oldal = o;
                Ar = a;
            }
        }
        static void Main(string[] args)
        {
            List<Konyv> konyvek = new List<Konyv>();

            StreamReader be = new StreamReader("konyvek.txt");

            while (!be.EndOfStream)
            {
                string[] sor = be.ReadLine().Split(';');

                konyvek.Add(new Konyv(
                    sor[1],
                    sor[2],
                    int.Parse(sor[3]),
                    int.Parse(sor[4]),
                    int.Parse(sor[5])
                ));
            }

            be.Close();

            int osszeg = 0;

            foreach (var konyv in konyvek)
            {
                osszeg = osszeg + konyv.Ar;
            }

            double atlag = (double)osszeg / konyvek.Count;

            
            Console.WriteLine("A könyvek átlagára: " + atlag + " Ft");



            Konyv leghosszabb = konyvek[0];

            foreach (var konyv in konyvek)
            {
                if (konyv.Oldal > leghosszabb.Oldal)
                {
                    leghosszabb = konyv;
                }
            }
           
            Console.WriteLine("A leghosszabb könyv: " + leghosszabb.Cim);
            Console.WriteLine("Oldalszám: " + leghosszabb.Oldal);



            
         
            Console.WriteLine("1950 után megjelent könyvek:");

            foreach (var konyv in konyvek)
            {
                if (konyv.Ev > 1950)
                {
                    Console.WriteLine(konyv.Cim + " - " + konyv.Ev);
                }
            }


            int db = 0;

            foreach (var konyv in konyvek)
            {
                if (konyv.Ev < 1950)
                {
                    db++;
                }
            }
           
            Console.WriteLine("1950 előtt megjelent könyvek száma: " + db);
        }
    }
}
    

