namespace ListaParzystych;

class Program
{
    static void Main(string[] args)
    {
        List<int> liczby1 = new List<int>();
        List<int> parzyste = new List<int>();
        for (int i=0; i<5; i++)
        {
            Console.WriteLine($"Podaj liczbę {i+1}:");
            liczby1.Add(Convert.ToInt32(Console.ReadLine()));
        }
        foreach (var liczba in liczby1)
        {
            if (liczba % 2 == 0)
            {
                parzyste.Add(liczba);
            }
        }
        Console.WriteLine($"Wszystkie liczby to: {string.Join(", ", liczby1)}");
        Console.WriteLine($"Liczby parzyste to: {string.Join(", ", parzyste)}");
    }
}
