namespace SumaElementówListy;

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
        int suma =0;
        foreach (var liczba in liczby1)
        {
            suma += liczba;
        }
        Console.WriteLine("" + suma);
    }
}
