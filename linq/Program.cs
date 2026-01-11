using System;
using System.Collections.Generic;
using System.Linq;

namespace linq;

class Program
{
    static void Main(string[] args)
    {
        dorosliStudenci();
       // wypiszStudentowPowyzej21roku();
        //zapytanieZKlasami();
        //foreach (var kurs in mojeKursy())
        //{
        //    Console.WriteLine ($"Kurs: {kurs.Nazwa} (ID: {kurs.Id})");
        //}
        //;
    }
    private static void prosteZapytanie()
    {
        List<string> imiona = new List<string>()
        {
            "Anna",
            "Bartek",
            "Cezary",
            "Daria",
            "Ewa",
            "Filip",
            "Adam"
        };
        var ImionaNaA = from imie in imiona
                        where imie.StartsWith("A")
                        select imie;
        foreach (var imie in ImionaNaA)
        {
            Console.WriteLine(imie);
        }
    }
    private static void zapytanieZKlasami()
    {
        var kursSQL = data.Kursy.FirstOrDefault(k => k.Nazwa == "Wprowadzenie do SQL");
        if (kursSQL == null)
        {
            Console.WriteLine("Kurs SQL nie znaleziony.");
            return;
        } else
        {
            Console.WriteLine($"Kurs: {kursSQL.Nazwa} (ID: {kursSQL.Id})");
        }
    }
    private static List<Kurs> mojeKursy()
    {
        var kursy = from kurs in data.Kursy
        where kurs.Nazwa.Contains("C#")
                        select kurs;
        return kursy.ToList();
    }
    static void wypiszStudentowPowyzej21roku()
    {
        var studenciPowyzej21 = data.Studenci
            .Where(s => s.Wiek > 21)
            .OrderBy(s => s.Nazwisko);

        Console.WriteLine($"Studenci powyżej 21 roku życia: {string.Join(", ", studenciPowyzej21.Select(s => $"{s.Nazwisko ?? "Brak nazwiska"} {s.Wiek}"))}");
    }
    static void dorosliStudenci()
    {
        var dorosli = from student in data.Studenci
            where student.Wiek > 21
            orderby student.Nazwisko
            select student;

        Console.WriteLine("Dorośli studenci:");
        foreach (var student in dorosli)
        {
            Console.WriteLine($"{student.Imie} {student.Nazwisko}, Wiek: {student.Wiek}");
            if (student.Wiek > 21) {
                Console.WriteLine(" - Dorosły student");
            } else {
                Console.WriteLine(" - Młody student");}
        }
    }
}
