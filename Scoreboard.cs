/*!!!!!!!!!!
Hører til Yatzy
SPILLET ER STADIG UNDER UDVIKLING OG VIRKER IKKE ENDNU
!!!!!!!!!!*/

namespace Terningespil;

public class Scoreboard
{
    public int Enner { get; set; }
    public int Toere { get; set; }
    public int Treere { get; set; }
    public int Firere { get; set; }
    public int Femere { get; set; }
    public int Seksere { get; set; }
    public int EtPar { get; set; }
    public int ToPar { get; set; }
    public int TreEns { get; set; }
    public int FireEns { get; set; }
    public int LilleStraight { get; set; }
    public int StorStraight { get; set; }
    public int FuldtHus { get; set; }
    public int Chance { get; set; }
    public int Yatzy { get; set; }

    public string VisScorecard()
    {
        return $@"
    Øvre del:
    Énner: {Enner}
    To’ere: {Toere}
    Tre’ere: {Treere}
    Fir’ere: {Firere}
    Fem’ere: {Femere}
    Seks’ere: {Seksere}

    Nedre del:
    Ét par: {EtPar}
    To par: {ToPar}
    Tre ens: {TreEns}
    Fire ens: {FireEns}
    Lille straight: {LilleStraight}
    Stor straight: {StorStraight}
    Fuldt hus: {FuldtHus}
    Chance: {Chance}
    Yatzy: {Yatzy}
    ";
    }
}


    /*5 terninger, 15 runder
    Enere (5)
    Toere (10)
    Treere (15)
    Firere (20)
    Femmere (25)
    Seksere (30)
    Delsum
    Bonus (50 ved 63+ i delsum)
    1 par (12)
    2 par (22)
    3 ens (18)
    4 ens (24)
    Lille straight 1-2-3-4-5 (15)
    Stor straight 2-3-4-5-6 (20)
    Fuldt hus 3+2 ens (28)
    Chance (30)
    Yatzy 5 ens (50)
    Sum                
    */

    /*6 terninger, 18 runder
    Enere (6)
    Toere (12)
    Treere (18)
    Firere (24)
    Femmere (30)
    Seksere (36)
    Delsum
    Bonus (50 ved 84+ i delsum)
    1 par (12)
    2 par (22)
    3 par (30)
    3 ens (18)
    4 ens (24)
    2 x 3 ens (33)
    Lille straight 1-2-3-4-5 (15)
    Stor straight 2-3-4-5-6 (20)
    Royal straight 1-2-3-4-5-6 (30)
    Fuldt hus 3+2 ens (28)
    Chance (36)
    Yatzy 5 ens (50)
    Sum
    */  