internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Podaj wysokość i szerokość prostokąta:");
        int height = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}