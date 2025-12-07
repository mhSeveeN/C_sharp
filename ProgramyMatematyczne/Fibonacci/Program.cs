internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ciąg Fibonacciego\nPodaj liczbę zakresu:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Ciąg Fibonacciego do zakresu {n}");
        int a = 0;
        int b = 1;
        Console.WriteLine(a);
        if (n == 1) return;
        Console.WriteLine(b);

        for (int i = 2; i < n; i++)
        {
            int c = a + b;
            Console.WriteLine(c);
            a = b;
            b = c;
        }
    }
}