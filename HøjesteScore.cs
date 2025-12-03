namespace Terningespil;

public class HøjesteScore
{
    public void SpilStart()
    {
        Console.WriteLine("\n" +
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
            // Vælg antal spillere            
            int antalSpillere = BrugerInput.ValgtTal("Vælg hvor mange spillere (2-6) og tryk enter:\n", 2, 6);
            Spiller[] spillere = new Spiller[antalSpillere];
            List<string> valgteNavne = new List<string>();

            for (int s = 0; s < antalSpillere; s++)
            {
                string spillerType = BrugerInput.JaEllerNej("\n" +
                    $"Er spiller {s + 1} en computer? Tast j/n og tryk enter:\n");
                bool erComputer = spillerType == "j";
                if (erComputer)
                {
                    spillere[s] = new Spiller($"Computer {s + 1}", true);
                    valgteNavne.Add($"Computer {s + 1}");
                }
                else
                {
                    Console.WriteLine("\n" +
                        $"Indtast navn for spiller {s + 1} og tryk enter:");
                    string navn = Console.ReadLine();
                    string testNavn = navn.ToLower();
                    string[] forbudteOrd = {"computer", "ai", "pc"};
                            
                    while(valgteNavne.Contains(testNavn))
                    {
                        Console.WriteLine("\n" +
                            $"Navnet er allerede taget, prøv igen med et nyt navn:");
                        navn = Console.ReadLine();
                        testNavn = navn.ToLower();
                    }
                    while(forbudteOrd.Contains(testNavn))
                    {
                        Console.WriteLine("\n" +
                            $"Navnet er ikke tilladt, prøv igen med et nyt navn:");
                        navn = Console.ReadLine();
                        testNavn = navn.ToLower();
                    }
                    spillere[s] = new Spiller(navn, false);
                    valgteNavne.Add(testNavn);
                }
            }

            //Vælg type af terninger
            int typeTerning = BrugerInput.ValgtTal("\n" +
                "Vælg hvilken type af terninger der skal bruges og tryk enter:\n" +
                "Tast 1 for en sekssidet terning\n" +
                "Tast 2 for en tolvsidet terning\n" +
                "Tast 3 for en tyvesidet terning\n", 1, 3);
            int sider = typeTerning == 1 ? 6 : typeTerning == 2 ? 12 : 20;

            //Vælg antal terninger
            int antalTerninger = BrugerInput.ValgtTal("\n" +
                "Vælg hvor mange terninger der skal bruge (1-6 stk.) og tryk enter:\n", 1, 6);

            if (antalTerninger == 1)
            {
                Console.WriteLine("\n" +
                $"Spillet vil starte med {antalTerninger} styk {sider}-sidet terning");
            }
            else
            {     
                Console.WriteLine("\n" +
                $"Spillet vil starte med {antalTerninger} styk {sider}-sidet terninger");
            }
            
            Console.WriteLine("Tryk på enter for at starte runde 1:");
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
                        Console.WriteLine("\n" +
                            $"{s.Navn} har fået {kast} points denne runde\n" +
                            $"{s.Navn} har samlet {s.TotalScore} points");
                    }
                    else
                    {
                        Console.WriteLine($"{s.Navn}, tryk enter for at se din totale score:");
                        Console.ReadLine();
                        Console.WriteLine($"{s.Navn} har fået en samlet score på {s.TotalScore}");
                    }
                    Console.WriteLine("Tryk enter for at fortsætte:");
                    Console.ReadLine();
                } 
                Console.WriteLine($"Runde {i} er slut\n" +
                    "Tryk enter for at fortsætte:");
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
            string nytSpil = BrugerInput.JaEllerNej("\n" +
                "Ønskes der et spil til? Tast j/n og tryk enter:\n");
            køreSpillet = nytSpil;
            Console.Clear();
        }
        Console.WriteLine("Tak for spillet!\n" +
        "Tryk på enter for at vende tilbage til menuen:");
        Console.ReadLine();
    }
}