using System.Collections.Generic;

namespace linq;

public static class data
{
    public static List<Kurs> Kursy { get; set; } = new List<Kurs>
    {
        new Kurs { Id = 1, Nazwa = "Wprowadzenie do C#" },
        new Kurs { Id = 2, Nazwa = "Zaawansowane C#" },
        new Kurs { Id = 3, Nazwa = "Wprowadzenie do SQL" },
    };

    public static List<Student> Studenci { get; set; } = new List<Student>
    {
        new Student { Imie = "Anna", Nazwisko = "Kowalska", Wiek = 22 },
        new Student { Imie = "Bartek", Nazwisko = "Nowak", Wiek = 20 },
        new Student { Imie = "Cezary", Nazwisko = "Zielinski", Wiek = 25 },
        // Add more as needed
    };
}