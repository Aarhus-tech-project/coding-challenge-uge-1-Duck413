namespace Terningespil;

public class VælgSpil
{
    public void ProgramStart()
    {
        bool kørProgram = true;
        while (kørProgram)
        {
            Console.WriteLine("\n" +
                "VELKOMMEN TIL TERNINGESPILLET!\n" +
                "\n" +
                "I dette spil kan der vælges mellem flere forskellige terningespil\n" +
                "Man kan spille mod andre spillere eller mod computeren\n" +
                "For at forlade et spil før det er færdigt tryk på Esc\n" +
                "\n" +
                "Indtast nummeret for det valgte spil, og tryk enter:\n" +
                    "1: Højeste Score\n" +
                    "2: Yatzy (SPILLET ER STADIG UNDER UDVIKLING OG VIRKER IKKE ENDNU)\n" +
                    "0: Afslut spillet");

            int valgtSpil = BrugerInput.ValgtTal("", 0, 2);
            switch (valgtSpil)
            {
                case 1:
                    HøjesteScore spil = new HøjesteScore();
                    spil.SpilStart();
                    break;
                case 2:
                    Yatzy spil2 = new Yatzy();
                    spil2.Start();                
                    break;
                case 0:
                    kørProgram = false;
                    break;
            }
        }
        Console.WriteLine("\n" +
            "Tak for at spille Terningespillet!\n" +
            "Tryk på enter for at afslutte programmet:");
        Console.ReadLine();
    }
}