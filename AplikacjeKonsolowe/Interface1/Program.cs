using System;
using System.Collections.Generic;

namespace Interface1;

interface ILista_zakupow
{
    void DodajElement(string pozycja); // Dodaje element do listy zakupów
    void UsunElement(string pozycja); // Usuwa element z listy zakupów

    void WyswietlListe(); // Wyświetla aktualną listę zakupów

    void Wyswietl(int ile_pozycji); // Wyświetla określoną liczbę pozycji z listy zakupów
}

class ListaZakupow : ILista_zakupow
{
    private List<string> listaZakupow;

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

class Program
{
    static void Main(string[] args)
    {
        ILista_zakupow mojaLista = new ListaZakupow();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Menu listy zakupów:");
            Console.WriteLine("1. Dodaj element");
            Console.WriteLine("2. Usuń element");
            Console.WriteLine("3. Wyświetl całą listę");
            Console.WriteLine("4. Wyświetl pierwsze N pozycji");
            Console.WriteLine("5. Zakończ");
            Console.Write("Wybierz opcję: ");

            string wybór = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            switch (wybór.Trim())
            {
                case "1":
                    Console.Write("Podaj nazwę produktu do dodania: ");
                    string dodaj = Console.ReadLine() ?? string.Empty;
                    mojaLista.DodajElement(dodaj.Trim());
                    break;

                case "2":
                    Console.Write("Podaj nazwę produktu do usunięcia: ");
                    string usun = Console.ReadLine() ?? string.Empty;
                    mojaLista.UsunElement(usun.Trim());
                    break;

                case "3":
                    mojaLista.WyswietlListe();
                    break;

                case "4":
                    Console.Write("Ile pierwszych pozycji wyświetlić? ");
                    if (int.TryParse(Console.ReadLine(), out int ile) && ile > 0)
                    {
                        mojaLista.Wyswietl(ile);
                    }
                    else
                    {
                        Console.WriteLine("Podaj poprawną liczbę większą od 0.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Koniec programu.");
                    return;

                default:
                    Console.WriteLine("Niepoprawna opcja. Wybierz 1-5.");
                    break;
            }
        }
    }
}
