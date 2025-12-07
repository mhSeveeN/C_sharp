internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Podaj liczbę pięter piramidy:");
        int poziomy = int.Parse(Console.ReadLine());
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