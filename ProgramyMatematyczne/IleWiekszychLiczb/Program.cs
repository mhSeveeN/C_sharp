namespace IleWiekszychLiczb;

class Program
{
    static void Main(string[] args)
    {
        List<int> liczby1 = new List<int>();
        for (int i=0; i<5; i++)
        {
            Console.WriteLine($"Podaj liczbę {i+1}:");
            liczby1.Add(Convert.ToInt32(Console.ReadLine()));
        }
        Console.WriteLine("Podaj liczbę referencyjną:");
        int referencyjna = Convert.ToInt32(Console.ReadLine());
        int LiczbyWieksze = 0;
        foreach (var liczba in liczby1)
        {
            if (liczba > referencyjna)
            {
                Console.WriteLine(liczba);
                LiczbyWieksze ++;
            }
        }
        Console.WriteLine($"Liczba elementów większych od {referencyjna} to: {LiczbyWieksze}");
    }
}
