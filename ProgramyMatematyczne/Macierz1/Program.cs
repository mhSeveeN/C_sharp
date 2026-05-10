//Macierz.cs

using System;
using System.Text;

namespace Macierze
{
    public class Macierz
    {
        private readonly double[,] macierz;

        public Macierz(int liczbaWierszy, int liczbaKolumn)
        {
            if (liczbaWierszy <= 0 || liczbaKolumn <= 0)
            {
                throw new ArgumentException("Rozmiar macierzy musi by wikszy od 0.");
            }

            macierz = new double[liczbaWierszy, liczbaKolumn];
        }

        public double this[int wiersz, int kolumna]
        {
            get => macierz[wiersz - 1, kolumna - 1];
            set => macierz[wiersz - 1, kolumna - 1] = value;
        }

        public int LiczbaWierszy => macierz.GetLength(0);
        public int LiczbaKolumn => macierz.GetLength(1);

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < LiczbaWierszy; i++)
            {
                for (int j = 0; j < LiczbaKolumn; j++)
                {
                    builder.Append(macierz[i, j].ToString("0.##"));
                    if (j < LiczbaKolumn - 1)
                    {
                        builder.Append(" ");
                    }
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        public static Macierz operator +(Macierz a, Macierz b)
        {
            ValidateSameDimensions(a, b);

            var c = new Macierz(a.LiczbaWierszy, a.LiczbaKolumn);
            for (int i = 0; i < a.LiczbaWierszy; i++)
            {
                for (int j = 0; j < a.LiczbaKolumn; j++)
                {
                    c.macierz[i, j] = a.macierz[i, j] + b.macierz[i, j];
                }
            }

            return c;
        }

        public static Macierz operator -(Macierz a, Macierz b)
        {
            ValidateSameDimensions(a, b);

            var c = new Macierz(a.LiczbaWierszy, a.LiczbaKolumn);
            for (int i = 0; i < a.LiczbaWierszy; i++)
            {
                for (int j = 0; j < a.LiczbaKolumn; j++)
                {
                    c.macierz[i, j] = a.macierz[i, j] - b.macierz[i, j];
                }
            }

            return c;
        }

        public static Macierz operator *(Macierz a, Macierz b)
        {
            if (a.LiczbaKolumn != b.LiczbaWierszy)
            {
                throw new ArgumentException("Zy rozmiar macierzy");
            }

            var c = new Macierz(a.LiczbaWierszy, b.LiczbaKolumn);
            for (int i = 0; i < a.LiczbaWierszy; i++)
            {
                for (int j = 0; j < b.LiczbaKolumn; j++)
                {
                    c.macierz[i, j] = 0;
                    for (int k = 0; k < a.LiczbaKolumn; k++)
                    {
                        c.macierz[i, j] += a.macierz[i, k] * b.macierz[k, j];
                    }
                }
            }

            return c;
        }

        public static Macierz operator *(double x, Macierz a)
        {
            var c = new Macierz(a.LiczbaWierszy, a.LiczbaKolumn);
            for (int i = 0; i < a.LiczbaWierszy; i++)
            {
                for (int j = 0; j < a.LiczbaKolumn; j++)
                {
                    c.macierz[i, j] = x * a.macierz[i, j];
                }
            }

            return c;
        }

        private static void ValidateSameDimensions(Macierz a, Macierz b)
        {
            if (a.LiczbaWierszy != b.LiczbaWierszy || a.LiczbaKolumn != b.LiczbaKolumn)
            {
                throw new ArgumentException("Zy rozmiar macierzy");
            }
        }
    }

    public static class Program
    {
        public static void Main()
        {
            try
            {
                var a = new Macierz(2, 2);
                a[1, 1] = 1;
                a[1, 2] = 2;
                a[2, 1] = 3;
                a[2, 2] = 4;

                var b = new Macierz(2, 2);
                b[1, 1] = 5;
                b[1, 2] = 6;
                b[2, 1] = 7;
                b[2, 2] = 8;

                Console.WriteLine("Macierz A:");
                Console.WriteLine(a);
                Console.WriteLine("Macierz B:");
                Console.WriteLine(b);
                Console.WriteLine("A + B:");
                Console.WriteLine(a + b);
                Console.WriteLine("A - B:");
                Console.WriteLine(a - b);
                Console.WriteLine("A * B:");
                Console.WriteLine(a * b);
                Console.WriteLine("3 * A:");
                Console.WriteLine(3 * a);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystpi bd: {ex.Message}");
            }
        }
    }
}
