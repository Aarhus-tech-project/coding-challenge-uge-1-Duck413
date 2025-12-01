namespace Terningespil;

public class HøjesteScore
{
    public void Start()
    {
        Console.WriteLine(
            "\n" +
            "VELKOMMEN TIL HØJESTE SCORE!\n" +
            "\n" +
            "Dette spil er for 2-6 spillere, og reglerne er som følgende:\n" +
            "   - Man starter med at vælge antal spillere samt terninger der skal bruges\n" +
            "   - Hver spiller skiftes til at rulle terningerne en gang per runde\n" +
            "   - Vinderen er den med flest point efter 5 runder\n" +
            "\n" +
            "Tryk på enter for at starte spillet");
        Console.ReadLine();

        string køreSpillet = "j";
        while (køreSpillet == "j")
        {
            //Vælg antal spillere
            Console.WriteLine("Vælg hvor mange spillere (2-6) og tryk enter:");
            int antalSpillere = Convert.ToInt32(Console.ReadLine());
            while (antalSpillere < 2 || antalSpillere > 6)
            {
                Console.WriteLine("\n" +
                "Ugyldigt antal valgt. Vælg et tal mellem 2 og 6:");
                antalSpillere = Convert.ToInt32(Console.ReadLine());
            }
            Spiller[] spillere = new Spiller[antalSpillere];
            for (int s = 0; s < antalSpillere; s++)
            {
                Console.WriteLine(
                    "\n" +
                    $"Er spiller {s + 1} en computer? Tast j/n og tryk enter:");
                string svar = Console.ReadLine().ToLower();
                while (svar != "j" && svar != "n")
                {
                    Console.WriteLine("\n" +
                        "Ugyldig indtastning. Tast j for ja eller n for nej:");
                    svar = Console.ReadLine().ToLower();
                }
                bool erComputer = svar == "j";
                if (erComputer)
                {
                    spillere[s] = new Spiller($"Computer {s + 1}", true);
                }
                else
                {
                    Console.WriteLine(
                        "\n" +
                        $"Indtast navn for spiller {s + 1} og tryk enter:");
                    string? navn = Console.ReadLine();
                    spillere[s] = new Spiller(navn, false);
                }
            }

            //Vælg type af terninger
            Console.WriteLine(
                "\n" +
                "Vælg hvilken type af terninger der skal bruges og tryk enter:\n" +
                "Tast 1 for en sekssidet terning\n" +
                "Tast 2 for en tolvsidet terning\n" +
                "Tast 3 for en tyvesidet terning");
            int typeTerning = Convert.ToInt32(Console.ReadLine());
            while (typeTerning < 1 || typeTerning > 3)
            {
                Console.WriteLine("\n" +
                    "Ugyldig type valgt. Vælg 1, 2 eller 3:");
                typeTerning = Convert.ToInt32(Console.ReadLine());
            }
            int sider = typeTerning == 1 ? 6 : typeTerning == 2 ? 12 : 20;

            //Vælg antal terninger
            Console.WriteLine(
                "\n" +
                "Vælg hvor mange terninger der skal bruge (1-6 stk.) og tryk enter:");
            int antalTerninger = Convert.ToInt32(Console.ReadLine());
            while (antalTerninger < 1 || antalTerninger > 6)
            {
                Console.WriteLine("\n" +
                    "Ugyldigt antal valgt. Vælg et tal mellem 1 og 6:");
                antalTerninger = Convert.ToInt32(Console.ReadLine());
            }

            if (antalTerninger == 1)
            {
                Console.WriteLine(
                "\n" +
                $"Spillet vil starte med {antalTerninger} styk {sider}-sidet terning\n");
            }
            else
            {     
                Console.WriteLine(
                "\n" +
                $"Spillet vil starte med {antalTerninger} styk {sider}-sidet terninger\n");
            }
            
            Console.WriteLine("Tryk på enter for at starte runde 1");
            Console.ReadLine();    

            //Lav de valgte terninger og rul dem
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Runde {i}:");
                foreach (Spiller s in spillere)
                { 
                    int kast = s.KastTerninger(antalTerninger, sider);
                    if (s.ErComputer)
                    {
                        Console.WriteLine(
                            "\n" +
                            $"{s.Navn} har fået {kast} points denne runde\n" +
                            $"{s.Navn} har samlet {s.TotalScore} points");
                    }
                    else
                    {
                        Console.WriteLine($"{s.Navn}, tryk enter for at se din totale score");
                        Console.ReadLine();
                        Console.WriteLine($"{s.Navn} har fået en samlet score på {s.TotalScore}");
                    }
                    Console.WriteLine("Tryk enter for at fortsætte");
                    Console.ReadLine();
                } 
                Console.WriteLine(
                    $"Runde {i} er slut\n" +
                    "Tryk enter for at fortsætte");
                Console.ReadLine();
            }

            //Find vinderen
            int maxScore = 0;
            foreach (Spiller s in spillere)
            {
                if (s.TotalScore > maxScore) maxScore = s.TotalScore;
            }
            List<Spiller> vinder = new List<Spiller>();
            foreach (Spiller s in spillere)
            {
                if (s.TotalScore == maxScore)
                {
                    vinder.Add(s);
                }
            }

            Console.WriteLine("Spillet er slut!");
            if (vinder.Count == 1)
            {
                Console.WriteLine($"Vinderen er {vinder[0].Navn} med {maxScore} point!");
            }
            else
            {
                Console.WriteLine("Det blev uafgjort mellem:");
                foreach (Spiller s in vinder)
                {
                    Console.WriteLine($"{s.Navn} med {maxScore} point");
                }
            }
            Console.WriteLine("");

            //Afslutning
            Console.WriteLine("Ønskes der et spil til? Tast j/n og tryk enter)");
            køreSpillet = Console.ReadLine().ToLower();
            while (køreSpillet != "j" && køreSpillet != "n")
            {
                Console.WriteLine("Ugyldig indtastning. Tast j for ja eller n for nej:");
                køreSpillet = Console.ReadLine().ToLower();
            }
            Console.Clear();
        }
        Console.WriteLine("Tak for spillet!\n" +
        "Tryk på enter for at vende tilbage til menuen");
        Console.ReadLine();
    }
}