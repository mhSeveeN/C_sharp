internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Tabliczka mnożenia");
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                int wynik = 0;
                wynik = i * j;
                Console.WriteLine($"{i} x {j} = {wynik}");
            }
        }
    }
}