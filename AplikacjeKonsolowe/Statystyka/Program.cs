using System;
using System.Linq;

namespace Statystyka;

static class Statystyka
{
    public static double min(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        double minValue = tablica_liczb[0];
        foreach (var liczba in tablica_liczb)
        {
            if (liczba < minValue) minValue = liczba;
        }
        return minValue;
    }

    public static double max(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        double maxValue = tablica_liczb[0];
        foreach (var liczba in tablica_liczb)
        {
            if (liczba > maxValue) maxValue = liczba;
        }
        return maxValue;
    }

    public static int ile_elementow(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        return tablica_liczb.Length;
    }

    public static double rozstep(double[] tablica_liczb)
    {
        return max(tablica_liczb) - min(tablica_liczb);
    }

    public static double suma(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        double suma = 0;
        foreach (var liczba in tablica_liczb)
        {
            suma += liczba;
        }
        return suma;
    }

    public static double srednia(double[] tablica_liczb, string rodzaj_sredniej)
    {
        ValidateArray(tablica_liczb);
        if (string.IsNullOrWhiteSpace(rodzaj_sredniej))
        {
            throw new ArgumentException("Rodzaj średniej nie może być pusty.", nameof(rodzaj_sredniej));
        }

        switch (rodzaj_sredniej.Trim().ToLower())
        {
            case "arytmetyczna":
                return suma(tablica_liczb) / tablica_liczb.Length;
            case "geometryczna":
                if (tablica_liczb.Any(x => x <= 0))
                {
                    throw new ArgumentException("Średnia geometryczna wymaga wartości dodatnich.");
                }
                return Math.Pow(tablica_liczb.Aggregate(1.0, (acc, x) => acc * x), 1.0 / tablica_liczb.Length);
            case "harmoniczna":
                if (tablica_liczb.Any(x => x == 0))
                {
                    throw new ArgumentException("Średnia harmoniczna nie może być wyliczona dla wartości zero.");
                }
                return tablica_liczb.Length / tablica_liczb.Sum(x => 1.0 / x);
            default:
                throw new ArgumentException($"Nieobsługiwany rodzaj średniej: {rodzaj_sredniej}", nameof(rodzaj_sredniej));
        }
    }

    public static double moment_centralny(double[] tablica_liczb, int rzad)
    {
        ValidateArray(tablica_liczb);
        if (rzad < 1)
        {
            throw new ArgumentException("Rząd momentu centralnego musi być większy lub równy 1.", nameof(rzad));
        }

        double mean = srednia(tablica_liczb, "arytmetyczna");
        double sum = 0;
        foreach (var liczba in tablica_liczb)
        {
            sum += Math.Pow(liczba - mean, rzad);
        }
        return sum / tablica_liczb.Length;
    }

    public static double odchylenie_standardowe(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        return Math.Sqrt(moment_centralny(tablica_liczb, 2));
    }

    public static double wspolczynnik_zmiennosci(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        double mean = srednia(tablica_liczb, "arytmetyczna");
        if (mean == 0)
        {
            throw new InvalidOperationException("Nie można obliczyć współczynnika zmienności dla średniej równej zero.");
        }
        return odchylenie_standardowe(tablica_liczb) / Math.Abs(mean);
    }

    public static double wspolczynnik_asymetrii(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        double sigma = odchylenie_standardowe(tablica_liczb);
        if (sigma == 0)
        {
            return 0;
        }
        return moment_centralny(tablica_liczb, 3) / Math.Pow(sigma, 3);
    }

    public static double kurtoza(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        double sigma = odchylenie_standardowe(tablica_liczb);
        if (sigma == 0)
        {
            return 0;
        }
        return moment_centralny(tablica_liczb, 4) / Math.Pow(sigma, 4);
    }

    public static double mediana(double[] tablica_liczb)
    {
        ValidateArray(tablica_liczb);
        return kwantyl(tablica_liczb, 50);
    }

    public static double kwantyl(double[] tablica_liczb, int rzad)
    {
        ValidateArray(tablica_liczb);
        if (rzad < 0 || rzad > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(rzad), "Rząd kwantyla musi być w zakresie 0-100.");
        }

        var sorted = tablica_liczb.OrderBy(x => x).ToArray();
        if (sorted.Length == 1)
        {
            return sorted[0];
        }

        double p = rzad / 100.0;
        double position = p * (sorted.Length - 1);
        int lowerIndex = (int)Math.Floor(position);
        int upperIndex = (int)Math.Ceiling(position);

        if (lowerIndex == upperIndex)
        {
            return sorted[lowerIndex];
        }

        double fraction = position - lowerIndex;
        return sorted[lowerIndex] + fraction * (sorted[upperIndex] - sorted[lowerIndex]);
    }

    private static void ValidateArray(double[] tablica)
    {
        if (tablica == null || tablica.Length == 0)
        {
            throw new ArgumentException("Tablica liczb musi zawierać co najmniej jeden element.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        double[] liczby = { 4.0, 8.5, 2.0, 7.5, 9.0, 3.5 };

        Console.WriteLine("Tablica danych: " + string.Join(", ", liczby));
        Console.WriteLine($"Min: {Statystyka.min(liczby)}");
        Console.WriteLine($"Max: {Statystyka.max(liczby)}");
        Console.WriteLine($"Ilość elementów: {Statystyka.ile_elementow(liczby)}");
        Console.WriteLine($"Rozstęp: {Statystyka.rozstep(liczby)}");
        Console.WriteLine($"Suma: {Statystyka.suma(liczby)}");
        Console.WriteLine($"Średnia arytmetyczna: {Statystyka.srednia(liczby, "arytmetyczna"):F2}");
        Console.WriteLine($"Średnia geometryczna: {Statystyka.srednia(liczby, "geometryczna"):F2}");
        Console.WriteLine($"Średnia harmoniczna: {Statystyka.srednia(liczby, "harmoniczna"):F2}");
        Console.WriteLine($"Mediana: {Statystyka.mediana(liczby):F2}");
        Console.WriteLine($"Kwantyl 25%: {Statystyka.kwantyl(liczby, 25):F2}");
        Console.WriteLine($"Kwantyl 75%: {Statystyka.kwantyl(liczby, 75):F2}");
        Console.WriteLine($"Moment centralny rzędu 3: {Statystyka.moment_centralny(liczby, 3):F4}");
        Console.WriteLine($"Odchylenie standardowe: {Statystyka.odchylenie_standardowe(liczby):F4}");
        Console.WriteLine($"Współczynnik zmienności: {Statystyka.wspolczynnik_zmiennosci(liczby):F4}");
        Console.WriteLine($"Współczynnik asymetrii: {Statystyka.wspolczynnik_asymetrii(liczby):F4}");
        Console.WriteLine($"Kurtoza: {Statystyka.kurtoza(liczby):F4}");
    }
}
