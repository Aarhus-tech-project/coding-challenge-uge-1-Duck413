namespace Terningespil;

public class VælgSpil
{
    public void Start()
    {
        bool kørProgram = true;
        while (kørProgram)
        {
            Console.WriteLine(
                "\n" +
                "VELKOMMEN TIL TERNINGESPILLET!\n" +
                "\n" +
                "I dette spil kan der vælges mellem flere forskellige terningespil.\n" +
                "Man kan spille mod andre spillere eller mod computeren.\n" +
                "\n" +
                "Indtast nummeret for det valgte spil, og tryk enter:\n" +
                    "1: Højeste Score\n" +
                    "2: Yatzy (spillet er stadig under udvikling)\n" +
                    "0: Afslut spillet");
            int valgtSpil = Convert.ToInt32(Console.ReadLine());
            while (valgtSpil < 0 || valgtSpil > 2)
            {
                Console.WriteLine("\n" +
                "Ugyldigt spil valgt. Vælg et tal mellem 1 og 2:");
                valgtSpil = Convert.ToInt32(Console.ReadLine());
            }
            
            switch (valgtSpil)
            {
                case 1:
                    HøjesteScore spil = new HøjesteScore();
                    spil.Start();
                    break;
                case 2:
                    Yatzy spil2 = new Yatzy();
                    spil2.Start();                
                    break;
                case 0:
                    kørProgram = false;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg. Vælg et tal mellem 0 og 2:");
                    break;
            }
        }
        Console.WriteLine("\n" +
            "Tak for at spille Terningespillet!\n" +
            "Tryk på enter for at afslutte programmet");
        Console.ReadLine();
    }
}