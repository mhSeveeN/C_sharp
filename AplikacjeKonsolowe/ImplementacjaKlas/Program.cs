namespace ImplementacjaKlas;

public class Student
{
    private string imie;
    private int wiek;
    private string kierunek;
    private bool urlop = false;

    public Student()
    {
        imie = "Nieznane";
        wiek = 0;
        kierunek = "Brak";
    }

    public Student(string imie)
    {
        this.imie = imie;
        wiek = 0;
        kierunek = "Brak";
    }

    public Student(string imie, int wiek, string kierunek)
    {
        this.imie = imie;
        this.wiek = wiek;
        this.kierunek = kierunek;
    }

    public void SetImie(string imie)
    {
        this.imie = imie;
    }

    public string GetImie()
    {
        return imie;
    }

    public void SetWiek(int wiek)
    {
        this.wiek = wiek;
    }

    public int GetWiek()
    {
        return wiek;
    }

    public void SetKierunek(string kierunek)
    {
        this.kierunek = kierunek;
    }

    public string GetKierunek()
    {
        return kierunek;
    }

    public bool GetUrlop()
    {
        return urlop;
    }

    public void SetUrlop(bool urlop)
    {
        this.urlop = urlop;
    }

    public void WezUrlop()
    {
        urlop = true;
    }

    public string Statut()
    {
        return urlop
            ? "Student jest na urlopie dziekańskim."
            : "Student studiuje normalnie.";
    }

    public override string ToString()
    {
        return $"Imię: {imie}, Wiek: {wiek}, Kierunek: {kierunek}, Urlop: {(urlop ? "Tak" : "Nie")}";
    }
}

public class Triangle
{
    private int baseLength;
    private int height;

    public Triangle(int baseLength, int height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public float Area()
    {
        return (baseLength * height) / 2f;
    }

    

    public string Isosceles()
    {
        return baseLength == height
            ? "Trójkąt jest równoramienny."
            : "Trójkąt nie jest równoramienny.";
    }

    public string Equilateral()
    {
        return baseLength == height
            ? "Trójkąt jest równoboczny."
            : "Trójkąt nie jest równoboczny.";
    }

    public override string ToString()
    {
        return $"Trójkąt o podstawie {baseLength} i wysokości {height} ma pole {Area()}.";
    }

}

public class Piramida
{
    private int poziomy;

    public Piramida(int poziomy)
    {
        this.poziomy = poziomy;
    }

    public void Rysuj()
    {
        for (int i = 1; i <= poziomy; i++)
        {
            for (int j = 1; j <= poziomy - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= (2 * i - 1); k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zadanie 1 - Klasa Student");
        Student student1 = new Student();
        Console.WriteLine("Podaj imię studenta:");
        student1.SetImie(Console.ReadLine());
        Console.WriteLine(student1.ToString());
        Console.WriteLine("Podaj kierunek studiów:");
        student1.SetKierunek(Console.ReadLine());
        Console.WriteLine(student1.ToString());
        Console.WriteLine("Podaj wiek studenta:");
        student1.SetWiek(int.Parse(Console.ReadLine()));
        Console.WriteLine(student1.ToString());
        Console.WriteLine("Czy student jest na urlopie dziekańskim? (tak/nie)");
        string urlopInput = Console.ReadLine().ToLower();
        if (urlopInput == "tak")
        {
            student1.WezUrlop();
        }
        Console.WriteLine(student1.ToString());

        // Zadanie 2 - Klasa Triangle
        Console.WriteLine("\nZadanie 2 - Klasa Triangle");
        Console.WriteLine("Podaj długość podstawy trójkąta:");
        int baseLength = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wysokość trójkąta:");
        int height = int.Parse(Console.ReadLine());
        Triangle triangle = new Triangle(baseLength, height);
        Console.WriteLine(triangle.ToString());
        Console.WriteLine(triangle.Isosceles());
        Console.WriteLine(triangle.Equilateral());

        // Zadanie 3 - Piramida z gwiazdek
        Console.WriteLine("\nZadanie 3 - Piramida z gwiazdek");
        Console.WriteLine("Podaj liczbę pięter piramidy:");
        int poziomy = int.Parse(Console.ReadLine());
        Piramida piramida = new Piramida(poziomy);
        piramida.Rysuj();

    }
}
