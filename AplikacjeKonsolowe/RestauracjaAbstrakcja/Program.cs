using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauracjaAbstrakcja;

interface IDanie
{
    double czasOczekiwania();
    double iloscKalorii();
}

abstract class Dania : IDanie
{
    public string Nazwa { get; }
    public List<string> ListaAlergenow { get; }

    protected Dania(string nazwa, List<string> listaAlergenow)
    {
        Nazwa = nazwa;
        ListaAlergenow = listaAlergenow ?? new List<string>();
    }

    public abstract double czasOczekiwania();
    public abstract double iloscKalorii();

    public string OpisAlergenow()
    {
        return ListaAlergenow.Count == 0 ? "brak" : string.Join(", ", ListaAlergenow);
    }
}

abstract class DaniaMiesne : Dania
{
    public string RodzajMiesa { get; }

    protected DaniaMiesne(string nazwa, string rodzajMiesa, List<string> listaAlergenow)
        : base(nazwa, listaAlergenow)
    {
        RodzajMiesa = rodzajMiesa;
    }
}

sealed class Rolada : DaniaMiesne
{
    public double WagaGram { get; }
    public double CzasMinut { get; }
    public double Kalorie { get; }

    public Rolada(double wagaGram, double czasMinut, double kalorie, string rodzajMiesa, List<string> listaAlergenow)
        : base("Rolada", rodzajMiesa, listaAlergenow)
    {
        WagaGram = wagaGram;
        CzasMinut = czasMinut;
        Kalorie = kalorie;
    }

    public override double czasOczekiwania() => CzasMinut;
    public override double iloscKalorii() => Kalorie;

    public override string ToString() =>
        $"{Nazwa} ({RodzajMiesa}) - czas: {CzasMinut} min, kalorie: {Kalorie} kcal, alergeny: {OpisAlergenow()}";
}

abstract class DaniaBezMiesa : Dania
{
    public string TypBialka { get; }

    protected DaniaBezMiesa(string nazwa, string typBialka, List<string> listaAlergenow)
        : base(nazwa, listaAlergenow)
    {
        TypBialka = typBialka;
    }
}

class SalatkaWarzywna : DaniaBezMiesa
{
    public double WagaGram { get; }
    public double CzasMinut { get; }
    public double Kalorie { get; }

    public SalatkaWarzywna(double wagaGram, double czasMinut, double kalorie, string typBialka, List<string> listaAlergenow)
        : base("Sałatka warzywna", typBialka, listaAlergenow)
    {
        WagaGram = wagaGram;
        CzasMinut = czasMinut;
        Kalorie = kalorie;
    }

    public override double czasOczekiwania() => CzasMinut;
    public override double iloscKalorii() => Kalorie;

    public override string ToString() =>
        $"{Nazwa} ({TypBialka}) - czas: {CzasMinut} min, kalorie: {Kalorie} kcal, alergeny: {OpisAlergenow()}";
}

class Program
{
    static void Main(string[] args)
    {
        var menu = new List<Dania>
        {
            new Rolada(320, 25, 850, "wołowe", new List<string> { "gluten", "jajka" }),
            new SalatkaWarzywna(230, 10, 220, "roślinne", new List<string> { "orzechy" })
        };

        Console.WriteLine("Menu restauracji:");
        foreach (var danie in menu)
        {
            Console.WriteLine(danie);
        }

        Console.WriteLine();
        Console.WriteLine("Menu dla osób niejedzących mięsa:");
        Console.WriteLine(menu.OfType<DaniaBezMiesa>().FirstOrDefault()?.ToString() ?? "Brak dań bezmięsnych");

        Console.WriteLine();
        Console.WriteLine("Przykład wykorzystania interfejsów, klas abstrakcyjnych i klas:");
        Console.WriteLine("- IDanie zapewnia metody czasOczekiwania i iloscKalorii.");
        Console.WriteLine("- Dania to klasa bazowa abstrakcyjna z listą alergenów.");
        Console.WriteLine("- DaniaMiesne to abstrakcyjna klasa pochodna z rodzajem mięsa.");
        Console.WriteLine("- Rolada to klasa finalna (sealed) dziedzicząca po DaniaMiesne.");

        Console.WriteLine();
        Console.WriteLine($"Łączny czas oczekiwania: {menu.Sum(d => d.czasOczekiwania())} min");
        Console.WriteLine($"Łączna kaloryczność: {menu.Sum(d => d.iloscKalorii())} kcal");
    }
}
