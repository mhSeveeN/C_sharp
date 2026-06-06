using System;
using System.Collections.Generic;

namespace Biblioteka;

interface IZarzadzanie
{
    void Przetlumacz(string jezyk); // przetlumaczy produkt na podany jezyk
}

interface ICena
{
    void Rabat(int rabat); // obniży cenę o podany procent
    double WEuro(); // zwróci cenę w euro
}

interface IListaZakupow
{
    void DodajElement(string pozycja); // Dodaje element do listy zakupów
    void UsunElement(string pozycja); // Usuwa element z listy zakupów
    void WyswietlListe(); // Wyświetla aktualną listę zakupów
    void Wyswietl(int ile_pozycji); // Wyświetla określoną liczbę pozycji z listy zakupów
}

interface IBibliotekaKsiegarnia : IListaZakupow
{
    void DodajKsiazke(Ksiazka ksiazka);
    bool UsunKsiazke(string tytul);
    void WyswietlKsiazki();
    void PrzetlumaczKsiazke(string tytul, string jezyk);
    void ZastosujRabat(string tytul, int rabat);
    double CenaWEuro(string tytul);
}

class Ksiazka : IZarzadzanie, ICena
{
    public string Tytul { get; set; }
    public string Autor { get; set; }
    public double Cena { get; set; }

    public void Przetlumacz(string jezyk)
    {
        Console.WriteLine($"Przetłumaczono książkę '{Tytul}' na język {jezyk}.");
    }

    public void Rabat(int rabat)
    {
        Cena -= Cena * rabat / 100;
        Console.WriteLine($"Cena książki '{Tytul}' po rabacie: {Cena} zł.");
    }

    public double WEuro()
    {
        return Cena / 4.5; // przykładowy kurs wymiany
    }
}

class ListaZakupow : IListaZakupow
{
    private readonly List<string> listaZakupow;

    public ListaZakupow()
    {
        listaZakupow = new List<string>();
    }

    public void DodajElement(string pozycja)
    {
        listaZakupow.Add(pozycja);
        Console.WriteLine($"Dodano pozycję: {pozycja}");
    }

    public void UsunElement(string pozycja)
    {
        if (listaZakupow.Remove(pozycja))
        {
            Console.WriteLine($"Usunięto pozycję: {pozycja}");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono pozycji: {pozycja}");
        }
    }

    public void WyswietlListe()
    {
        Console.WriteLine("Lista zakupów:");
        if (listaZakupow.Count == 0)
        {
            Console.WriteLine("-- lista jest pusta --");
            return;
        }

        for (int i = 0; i < listaZakupow.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listaZakupow[i]}");
        }
    }

    public void Wyswietl(int ile_pozycji)
    {
        Console.WriteLine($"Pierwsze {ile_pozycji} pozycji z listy zakupów:");
        if (listaZakupow.Count == 0)
        {
            Console.WriteLine("-- lista jest pusta --");
            return;
        }

        for (int i = 0; i < Math.Min(ile_pozycji, listaZakupow.Count); i++)
        {
            Console.WriteLine($"{i + 1}. {listaZakupow[i]}");
        }
    }
}

class BibliotekaKsiegarnia : IBibliotekaKsiegarnia
{
    private readonly List<Ksiazka> ksiazki;
    private readonly ListaZakupow listaZakupow;

    public BibliotekaKsiegarnia()
    {
        ksiazki = new List<Ksiazka>();
        listaZakupow = new ListaZakupow();
    }

    public void DodajKsiazke(Ksiazka ksiazka)
    {
        ksiazki.Add(ksiazka);
        Console.WriteLine($"Dodano książkę: {ksiazka.Tytul} autor {ksiazka.Autor} za {ksiazka.Cena} zł.");
    }

    public bool UsunKsiazke(string tytul)
    {
        var ksiazka = ksiazki.Find(k => k.Tytul.Equals(tytul, StringComparison.OrdinalIgnoreCase));
        if (ksiazka != null)
        {
            ksiazki.Remove(ksiazka);
            Console.WriteLine($"Usunięto książkę: {tytul}");
            return true;
        }

        Console.WriteLine($"Nie znaleziono książki: {tytul}");
        return false;
    }

    public void WyswietlKsiazki()
    {
        Console.WriteLine("Książki w bibliotece-księgarni:");
        if (ksiazki.Count == 0)
        {
            Console.WriteLine("-- brak książek --");
            return;
        }

        for (int i = 0; i < ksiazki.Count; i++)
        {
            var ksiazka = ksiazki[i];
            Console.WriteLine($"{i + 1}. {ksiazka.Tytul} | Autor: {ksiazka.Autor} | Cena: {ksiazka.Cena} zł ({ksiazka.WEuro():F2} €)");
        }
    }

    public void PrzetlumaczKsiazke(string tytul, string jezyk)
    {
        var ksiazka = ksiazki.Find(k => k.Tytul.Equals(tytul, StringComparison.OrdinalIgnoreCase));
        if (ksiazka != null)
        {
            ksiazka.Przetlumacz(jezyk);
        }
        else
        {
            Console.WriteLine($"Nie znaleziono książki: {tytul}");
        }
    }

    public void ZastosujRabat(string tytul, int rabat)
    {
        var ksiazka = ksiazki.Find(k => k.Tytul.Equals(tytul, StringComparison.OrdinalIgnoreCase));
        if (ksiazka != null)
        {
            ksiazka.Rabat(rabat);
        }
        else
        {
            Console.WriteLine($"Nie znaleziono książki: {tytul}");
        }
    }

    public double CenaWEuro(string tytul)
    {
        var ksiazka = ksiazki.Find(k => k.Tytul.Equals(tytul, StringComparison.OrdinalIgnoreCase));
        if (ksiazka != null)
        {
            return ksiazka.WEuro();
        }

        Console.WriteLine($"Nie znaleziono książki: {tytul}");
        return 0;
    }

    public void DodajElement(string pozycja) => listaZakupow.DodajElement(pozycja);
    public void UsunElement(string pozycja) => listaZakupow.UsunElement(pozycja);
    public void WyswietlListe() => listaZakupow.WyswietlListe();
    public void Wyswietl(int ile_pozycji) => listaZakupow.Wyswietl(ile_pozycji);
}

class Program
{
    static void Main(string[] args)
    {
        var sklep = new BibliotekaKsiegarnia();
        sklep.DodajKsiazke(new Ksiazka { Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Cena = 50 });
        sklep.DodajKsiazke(new Ksiazka { Tytul = "Lalka", Autor = "Bolesław Prus", Cena = 45 });

        sklep.DodajElement("Zakreślacz");
        sklep.DodajElement("Notes");

        bool zakoncz = false;

        while (!zakoncz)
        {
            Console.WriteLine();
            Console.WriteLine("=== Biblioteka-Księgarnia ===");
            Console.WriteLine("1. Wyświetl książki");
            Console.WriteLine("2. Dodaj książkę");
            Console.WriteLine("3. Usuń książkę");
            Console.WriteLine("4. Przetłumacz książkę");
            Console.WriteLine("5. Zastosuj rabat do książki");
            Console.WriteLine("6. Wyświetl listę zakupów");
            Console.WriteLine("7. Dodaj element do listy zakupów");
            Console.WriteLine("8. Usuń element z listy zakupów");
            Console.WriteLine("9. Zakończ");
            Console.Write("Wybierz opcję: ");

            var wybor = Console.ReadLine();
            Console.WriteLine();

            switch (wybor)
            {
                case "1":
                    sklep.WyswietlKsiazki();
                    break;
                case "2":
                    Console.Write("Tytuł: ");
                    var nowyTytul = Console.ReadLine();
                    Console.Write("Autor: ");
                    var nowyAutor = Console.ReadLine();
                    Console.Write("Cena: ");
                    if (double.TryParse(Console.ReadLine(), out var nowaCena))
                    {
                        sklep.DodajKsiazke(new Ksiazka { Tytul = nowyTytul ?? "", Autor = nowyAutor ?? "", Cena = nowaCena });
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa cena.");
                    }
                    break;
                case "3":
                    Console.Write("Tytuł do usunięcia: ");
                    sklep.UsunKsiazke(Console.ReadLine() ?? "");
                    break;
                case "4":
                    Console.Write("Tytuł książki: ");
                    var tytulDoTlumaczenia = Console.ReadLine() ?? "";
                    Console.Write("Na jaki język: ");
                    var jezyk = Console.ReadLine() ?? "";
                    sklep.PrzetlumaczKsiazke(tytulDoTlumaczenia, jezyk);
                    break;
                case "5":
                    Console.Write("Tytuł książki: ");
                    var tytulDoRabatu = Console.ReadLine() ?? "";
                    Console.Write("Rabat (%): ");
                    if (int.TryParse(Console.ReadLine(), out var procentRabatu))
                    {
                        sklep.ZastosujRabat(tytulDoRabatu, procentRabatu);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy rabat.");
                    }
                    break;
                case "6":
                    sklep.WyswietlListe();
                    break;
                case "7":
                    Console.Write("Element do dodania: ");
                    sklep.DodajElement(Console.ReadLine() ?? "");
                    break;
                case "8":
                    Console.Write("Element do usunięcia: ");
                    sklep.UsunElement(Console.ReadLine() ?? "");
                    break;
                case "9":
                    zakoncz = true;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }

        Console.WriteLine("Do widzenia!");
    }
}
