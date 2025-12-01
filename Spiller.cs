namespace Terningespil;

public class Spiller
{
    public string Navn { get; set; }
    public int TotalScore { get; set; }
    public bool ErComputer { get; set; }

    public Spiller(string navn, bool erComputer)
    {
        Navn = navn;
        ErComputer = erComputer;
        TotalScore = 0;
    }

    public int KastTerninger(int antalTerninger, int sider)
    {
        int scores = 0;
        for (int i = 0; i < antalTerninger; i++)
        {
            Terning terning = new Terning(sider);
            int kast = terning.Rul();
            Console.WriteLine($"Der blev rullet {kast}");
            scores += kast;
        }
        TotalScore += scores;
        return scores;
    }
}