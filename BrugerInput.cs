namespace Terningespil;

public class BrugerInput
{      
    //Vælg et tal   
    public static int ValgtTal(string prompt, int min, int max)
    {
        Console.Write(prompt);
        while(true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int valg) && valg >= min && valg <= max)
                return valg;
            Console.WriteLine("\n" +
                $"Ugyldigt input. Vælg et tal mellem {min} og {max}:");
        }
    }
    
    //Vælg ja eller nej
    public static string JaEllerNej(string prompt)
    {
        Console.Write(prompt);
        while(true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "j" || input == "n")
                return input;
            Console.WriteLine("\n" +
                "Ugyldigt input. Tast j for ja eller n for nej:");
        }
    }

    //Vælg at lukke programmet

    //IKKE FÆRDIG IMPLEMENTERET - VIRKER IKKE!!!!

    // public static bool EscapeLuk = false;
    // public static void TjekInput()
    // {
    //     var valgtTast = Console.ReadKey(true).Key;
    //     if(valgtTast == ConsoleKey.Escape)
    //     {
    //         Console.WriteLine("Der er trykket på Esc, programmet lukker");
    //         EscapeLuk = true;
    //         return;
    //     }
    // }
}