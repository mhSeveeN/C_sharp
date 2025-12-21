namespace IleRazyWystepuje;

class Program
{
    static void Main(string[] args)
    {
        List<int> liczby1 = new List<int>();
        for (int i=0; i<9; i++)
        {
            Console.WriteLine($"Podaj liczbę {i+1}:");
            liczby1.Add(Convert.ToInt32(Console.ReadLine()));
        }
        Console.WriteLine("Podaj liczbę do sprawdzenia ile razy występuje:");
        int szukanaLiczba = Convert.ToInt32(Console.ReadLine());
        int licznik = 0;
        foreach (var liczba in liczby1)
        {
            if (liczba == szukanaLiczba)
            {
                licznik++;
            }
        }
        Console.WriteLine($"Liczba {szukanaLiczba} występuje {licznik} razy w podanej liście.");
    }
}
