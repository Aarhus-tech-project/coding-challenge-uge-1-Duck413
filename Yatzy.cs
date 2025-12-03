/*!!!!!!!!!!
SPILLET ER STADIG UNDER UDVIKLING OG VIRKER IKKE ENDNU
!!!!!!!!!!*/

namespace Terningespil;

public class Yatzy
{
    public void Start()
    {
        Console.WriteLine(
            "\n" +
            "VELKOMMEN TIL YATZY!\n" +
            "\n" +
            "Spillet kan spilles op til 6 personer, og man kan vælge om man vil spille med 5 eller 6 terninger\n" +
            "Reglerne er som følgende:\n" +
            "   -Man slår tre gange pr. tur, og man må selv vælge om man gemmer nogle terninger\n" +
            "   -Efter tre slag skal man vælge en kategori at score i, eller at strege ud\n" +
            "   -Hver kategori kan kun vælges én gang pr. spiller\n" +
            "   -Spillet slutter når alle kategorier er udfyldt\n" +
            "   -Man får altid 50 points for Yatzy, uanset hvilket antal øjne man har\n" +
            "\n" +
            "Tryk på enter for at starte spillet");
        Console.ReadLine();
        
        string køreSpillet = "j";
        while (køreSpillet == "j")
        {
            //Vælg antal spillere og sæt dem og deres scores op
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
                    $"Indtast navn for spiller {s + 1} og tryk enter:");
                string? navn = Console.ReadLine();
                spillere[s] = new Spiller(navn, false);
            }
        
            //Vælg antal terninger og sæt sider til 6
            Console.WriteLine(
                "\n" +
                "Vælg Yatzy version: 5 eller 6 terninger (tast 5 eller 6 og tryk enter):");
            int antalTerninger = Convert.ToInt32(Console.ReadLine());
            while (antalTerninger < 5 || antalTerninger > 6)
            {
                Console.WriteLine("\n" +
                    "Ugyldigt antal valgt. Vælg 5 eller 6 og tryk enter:");
                antalTerninger = Convert.ToInt32(Console.ReadLine());
            }
            int sider = 6;

            //Opsæt scoreboard afhængig af antal terninger
            foreach (Spiller spiller in spillere)
            {
                Scoreboard scoreboard = new Scoreboard();
            }   

            //Lav de valgte terninger og rul dem
            if (antalTerninger == 5)
            {
                for (int i = 1; i < 16; i++)
                {
                    Console.WriteLine($"Runde {i}:");
                    foreach (Spiller s in spillere)
                    { 
                        int kast = s.KastTerninger(antalTerninger, sider);
                    
                        Console.WriteLine("Tryk enter for at fortsætte");
                        Console.ReadLine();
                    } 
                    Console.WriteLine(
                        $"Runde {i} er slut\n" +
                        "Tryk enter for at fortsætte");
                    Console.ReadLine();
                }
            }
            else
            {
                for (int i = 1; i < 19; i++)
                {
                    Console.WriteLine($"Runde {i}:");
                    foreach (Spiller s in spillere)
                    { 
                        int kast = s.KastTerninger(antalTerninger, sider);
    
                        Console.WriteLine("Tryk enter for at fortsætte");
                        Console.ReadLine();
                    } 
                    Console.WriteLine(
                        $"Runde {i} er slut\n" +
                        "Tryk enter for at fortsætte");
                    Console.ReadLine();
                }
            }

            //Find vinderen

            
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