namespace Terningespil;

public class Terning
{
    public int Sider {get; private set;}
    private static Random rand = new Random();

    public Terning(int sider)
    {
        Sider = sider;
    }
    public int Rul()
    {
        return rand.Next(1, Sider + 1);
    }
}