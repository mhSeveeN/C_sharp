internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Program liczący silnie");
        int silnia = 0;
        Console.WriteLine("Z jakiej liczby chcesz wyliczyć silnię?:");
        int Liczba = int.Parse(Console.ReadLine());
        int i = 1;
        while (i < Liczba)
            {
                silnia = i * (i+1);
                i++;
            }
            Console.WriteLine($"Silnia liczby {Liczba} wynosi {silnia}");
    }
}