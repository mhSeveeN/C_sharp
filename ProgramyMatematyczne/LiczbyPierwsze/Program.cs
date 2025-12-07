using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Podaj górną granicę zakresu do wyszukania liczb pierwszych:");
        int limit = int.Parse(Console.ReadLine());
        Console.WriteLine($"Liczby pierwsze w zakresie do {limit} to:");
        for (int i = 2; i <= limit; i++)
        {
            bool isPrime = true;
            int sqrt = (int)Math.Sqrt(i);
            for (int j = 2; j <= sqrt; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                Console.WriteLine(i);
        }
    }
}