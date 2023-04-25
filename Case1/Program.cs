using System;

namespace BilVærksted
{

    class Program
    {
        static void Main(string[] args)
        {
            bool Loop;
            Loop = false;


            string BilMærke = "a";
            String BilModel = "a";
            string BilÅrgangString;
            int BilÅrgang = 0;
            int SidsteSyn = 0;


            int Date1 = DateTime.Now.Year;

            do
            {

                while (Loop == false)
                {
                    Console.Clear();
                    Console.WriteLine("Bilværksted\n\n");
                    Console.Write("Hvad er bilens mærke?   ");
                    BilMærke = Console.ReadLine().ToLower();
                    Console.Write("Hvad er bilens model?   ");
                    BilModel = Console.ReadLine().ToLower();
                    Console.Write("Hvad er bilens produktionsår?  ");
                    BilÅrgangString = Console.ReadLine();

                    if (int.TryParse(BilÅrgangString, out _) && BilÅrgangString.Length == 4)
                    {
                        BilÅrgang = Convert.ToInt16(BilÅrgangString);
                    }
                    if (BilÅrgang <= Date1)
                    {
                        Loop = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDet er ikke en gyldig årgang, tryk på en tast for at prøve igen.");
                        Console.ReadKey();
                    }
                }

                if (BilMærke == "fiat" && BilModel == "punto" && BilÅrgang < 2010)
                {
                    Console.WriteLine("Bilen har følgende fabriksfejl \"udstødning\" og skal derfor tilbagekaldes");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (BilMærke == "alfa romeo" && BilModel == "giulia" && BilÅrgang < 2019)
                {
                    Console.WriteLine("Bilen har følgende fabriksfejl \"Styretøj\" og skal derfor tilbagekaldes");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                int Syn1 = Date1 - BilÅrgang;
                Loop = false;

                if (Syn1 <= 5)
                {
                    Console.WriteLine("Bilen skal ikke til syn");
                    Console.ReadKey();
                    Environment.Exit(0);
                }


                while (Loop == false)
                {
                    Console.Clear();
                    Console.Write("Hvornår har bilen sidst været til syn?  ");
                    string SidsteSynString = Console.ReadLine();

                    if (int.TryParse(SidsteSynString, out _) && SidsteSynString.Length == 4)
                    {
                        SidsteSyn = Convert.ToInt16(SidsteSynString);
                    }
                    if (SidsteSyn <= BilÅrgang || SidsteSyn > Date1)
                    {
                        Console.Write("Ikke en mulig syns dato");
                        Console.ReadKey();
                    }
                    else
                    {
                        Loop = true;
                    }
                }

                int Syn2 = Date1 - SidsteSyn;

                if (Syn2 <= 2)
                {
                    Console.WriteLine("Bilen skal ikke til syn");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Bilen skal til syn");
                    Console.ReadKey();
                    Environment.Exit(0);
                }


            } while (Loop == false);

        }
    }
}