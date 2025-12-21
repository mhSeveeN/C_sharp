namespace UsuwanieUjemnych;

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
        foreach (var liczba in liczby1.ToList())
        {
            if (liczba < 0)
            {
                liczby1.Remove(liczba);
            }
        }
        Console.WriteLine($"Lista po usunięciu liczb ujemnych: {string.Join(", ", liczby1)}");
    }
}
