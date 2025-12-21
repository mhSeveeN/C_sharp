namespace ListaUzytkownik1;

class Program
{
    static void Main(string[] args)
    {
        List<int> liczby = new List<int>();
        for (int i=0; i<5; i++)
        {
            Console.WriteLine($"Podaj liczbę {i+1}:");
            liczby.Add(Convert.ToInt32(Console.ReadLine()));
        }
        Console.WriteLine("Podane liczby to:");
        foreach (var liczba in liczby)
        {
            Console.WriteLine(liczba);
        }
    }
}
