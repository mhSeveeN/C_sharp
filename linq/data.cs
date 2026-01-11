using System.Collections.Generic;

namespace linq
{
    public static class Data
    {
        public static List<Student> Studenci = new List<Student>
        {
            new Student { Id = 1, Imie = "Anna", Nazwisko = "Kowalska", Wiek = 22 },
            new Student { Id = 2, Imie = "Bartek", Nazwisko = "Nowak", Wiek = 20 },
            new Student { Id = 3, Imie = "Cezary", Nazwisko = "Zielinski", Wiek = 25 },
            new Student { Id = 4, Imie = "Daria", Nazwisko = "Wojcik", Wiek = 19 },
            new Student { Id = 5, Imie = "Ewa", Nazwisko = "Kaczmarek", Wiek = 23 }
        };

        public static List<Kurs> Kursy = new List<Kurs>
        {
            new Kurs { Id = 1, Nazwa = "Wprowadzenie do C#" },
            new Kurs { Id = 2, Nazwa = "Zaawansowane C#" },
            new Kurs { Id = 3, Nazwa = "Wprowadzenie do SQL" }
        };

        public static List<Zaliczenie> Zaliczenia = new List<Zaliczenie>
        {
            new Zaliczenie { StudentId = 1, Ocena = 5.0 },
            new Zaliczenie { StudentId = 2, Ocena = 4.5 },
            new Zaliczenie { StudentId = 3, Ocena = 4.0 },
            new Zaliczenie { StudentId = 4, Ocena = 3.5 },
            new Zaliczenie { StudentId = 5, Ocena = 5.0 }
        };
    }

    public class Student
    {
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public int Wiek { get; set; }
    }

    public class Kurs
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
    }

    public class Zaliczenie
    {
        public int StudentId { get; set; }
        public double Ocena { get; set; }
    }
}