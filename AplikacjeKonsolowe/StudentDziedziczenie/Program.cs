using System;
using System.Collections.Generic;

namespace StudentDziedziczenie;

class Student
{
    private string imie;
    private int wiek;
    private string kierunek;

    public string Imie
    {
        get => imie;
        set => imie = value;
    }

    public int Wiek
    {
        get => wiek;
        set => wiek = value;
    }

    public string Kierunek
    {
        get => kierunek;
        set => kierunek = value;
    }

    public Student()
    {
        Imie = string.Empty;
        Wiek = 0;
        Kierunek = string.Empty;
    }

    public Student(string imie, int wiek)
        : this(imie, wiek, string.Empty)
    {
    }

    public Student(string imie, int wiek, string kierunek)
    {
        Imie = imie;
        Wiek = wiek;
        Kierunek = kierunek;
    }

    public override string ToString()
    {
        return $"Student: {Imie}, wiek: {Wiek}, kierunek: {Kierunek}";
    }
}

class SuperStudent : Student
{
    private decimal stypendium;
    private List<string> zainteresowaniaNaukowe;

    public decimal Stypendium
    {
        get => stypendium;
        set => stypendium = value;
    }

    public List<string> ZainteresowaniaNaukowe
    {
        get => zainteresowaniaNaukowe;
        set => zainteresowaniaNaukowe = value ?? new List<string>();
    }

    public SuperStudent()
        : base()
    {
        ZainteresowaniaNaukowe = new List<string>();
    }

    public SuperStudent(string imie, int wiek, string kierunek, decimal stypendium, List<string> zainteresowaniaNaukowe)
        : base(imie, wiek, kierunek)
    {
        Stypendium = stypendium;
        ZainteresowaniaNaukowe = zainteresowaniaNaukowe ?? new List<string>();
    }

    public override string ToString()
    {
        string zainteresowania = ZainteresowaniaNaukowe.Count > 0
            ? string.Join(", ", ZainteresowaniaNaukowe)
            : "brak";

        return $"SuperStudent: {Imie}, wiek: {Wiek}, kierunek: {Kierunek}, stypendium: {Stypendium}, zainteresowania naukowe: {zainteresowania}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj imię studenta:");
        string imie = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Podaj wiek studenta:");
        int wiek = ReadIntFromConsole();

        Console.WriteLine("Podaj kierunek studenta:");
        string kierunek = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Podaj wysokość stypendium (liczba, np. 1500.50):");
        decimal stypendium = ReadDecimalFromConsole();

        Console.WriteLine("Podaj zainteresowania naukowe oddzielone przecinkami:");
        List<string> zainteresowania = ReadStringListFromConsole();

        Student student = new Student(imie, wiek, kierunek);
        SuperStudent superStudent = new SuperStudent(imie, wiek, kierunek, stypendium, zainteresowania);

        Console.WriteLine("\nInformacje o studencie:");
        Console.WriteLine(student);

        Console.WriteLine("\nInformacje o superstudencie:");
        Console.WriteLine(superStudent);
    }

    private static int ReadIntFromConsole()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Nieprawidłowa wartość. Wprowadź liczbę całkowitą:");
        }
    }

    private static decimal ReadDecimalFromConsole()
    {
        while (true)
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                return value;
            }

            Console.WriteLine("Nieprawidłowa wartość. Wprowadź liczbę:");
        }
    }

    private static List<string> ReadStringListFromConsole()
    {
        string input = Console.ReadLine() ?? string.Empty;
        var items = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var result = new List<string>();

        foreach (string item in items)
        {
            string trimmed = item.Trim();
            if (!string.IsNullOrEmpty(trimmed))
            {
                result.Add(trimmed);
            }
        }

        return result;
    }
}
