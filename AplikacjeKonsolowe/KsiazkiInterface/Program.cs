namespace KsiazkiInterface;


interface IZarzadzanie
{
    void przetlumac(string jezyk); // przetlumaczy produkt na podany jezyk
}

interface ICena
{
    void Rabat(int rabat); // obniży cenę o podany procent
    double wEuro(); // zwróci cenę w euro
}

class Ksiazka : IZarzadzanie, ICena
{
    public string Tytul { get; set; }
    public string Autor { get; set; }
    public double Cena { get; set; }

    public void przetlumac(string jezyk)
    {
        Console.WriteLine($"Przetłumaczono książkę '{Tytul}' na język {jezyk}.");
    }

    public void Rabat(int rabat)
    {
        Cena -= Cena * rabat / 100;
        Console.WriteLine($"Cena książki '{Tytul}' po rabacie: {Cena} zł.");
    }

    public double wEuro()
    {
        return Cena / 4.5; // przykładowy kurs wymiany
    }
}
class Program
{
    static void Main(string[] args)
    {
        Ksiazka ksiazka1 = new Ksiazka { Tytul = "Wiedźmin", Autor = "Andrzej Sapkowski", Cena = 50 };
        ksiazka1.przetlumac("angielski");
        ksiazka1.Rabat(20);
        Console.WriteLine($"Cena książki '{ksiazka1.Tytul}' w euro: {ksiazka1.wEuro():F2} €");
    }
}
