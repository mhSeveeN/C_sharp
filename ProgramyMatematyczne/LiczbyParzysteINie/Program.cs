internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Liczby parzyste i nieparzyste");
        for (int i = 1; i <= 50;)
        {
            while (i % 2 == 0)
            {
                Console.WriteLine($"Liczba {i}. Jest Parzysta");
                i++;
            }
            while (i % 2 != 0)
            {
                Console.WriteLine($"Liczba {i}. Jest Nieparzysta");
                i++;
            }
        }
    }
}