using System;

namespace PunktDziedziczenie;

class Punkt
{
    private double[] wspolrzedne;

    public double[] Wspolrzedne
    {
        get => wspolrzedne;
        set => wspolrzedne = value is { Length: 2 } ? value : new double[2];
    }

    public double X
    {
        get => Wspolrzedne[0];
        set => Wspolrzedne[0] = value;
    }

    public double Y
    {
        get => Wspolrzedne[1];
        set => Wspolrzedne[1] = value;
    }

    public Punkt()
    {
        Wspolrzedne = new double[2];
    }

    public Punkt(double x, double y)
    {
        Wspolrzedne = new[] { x, y };
    }

    public Punkt(double[] wspolrzedne)
    {
        Wspolrzedne = wspolrzedne;
    }

    public override string ToString()
    {
        return $"Punkt: ({X}, {Y})";
    }
}

class Okrag : Punkt
{
    private double promien;

    public double Promien
    {
        get => promien;
        set => promien = value;
    }

    public Okrag()
        : base()
    {
        Promien = 0;
    }

    public Okrag(double x, double y, double promien)
        : base(x, y)
    {
        Promien = promien;
    }

    public Okrag(double[] wspolrzedne, double promien)
        : base(wspolrzedne)
    {
        Promien = promien;
    }

    public double Obwod()
    {
        return 2 * Math.PI * Promien;
    }

    public override string ToString()
    {
        return $"Okrag: ({X}, {Y}), promien: {Promien}";
    }
}

class Kolo : Okrag
{
    public Kolo()
        : base()
    {
    }

    public Kolo(double x, double y, double promien)
        : base(x, y, promien)
    {
    }

    public Kolo(double[] wspolrzedne, double promien)
        : base(wspolrzedne, promien)
    {
    }

    public double Pole()
    {
        return Math.PI * Math.Pow(Promien, 2);
    }

    public override string ToString()
    {
        return $"Kolo: ({X}, {Y}), promien: {Promien}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj współrzędną X punktu:");
        double x = ReadDoubleFromConsole();

        Console.WriteLine("Podaj współrzędną Y punktu:");
        double y = ReadDoubleFromConsole();

        Console.WriteLine("Podaj promień okręgu/kola:");
        double promien = ReadDoubleFromConsole();

        Punkt punkt = new Punkt(x, y);
        Okrag okrag = new Okrag(x, y, promien);
        Kolo kolo = new Kolo(x, y, promien);

        Console.WriteLine();
        Console.WriteLine(punkt);
        Console.WriteLine(okrag);
        Console.WriteLine($"Obwód okręgu: {okrag.Obwod():F2}");
        Console.WriteLine(kolo);
        Console.WriteLine($"Pole koła: {kolo.Pole():F2}");
    }

    private static double ReadDoubleFromConsole()
    {
        while (true)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (double.TryParse(input, out double value))
            {
                return value;
            }

            Console.WriteLine("Nieprawidłowa liczba. Spróbuj jeszcze raz:");
        }
    }
}
