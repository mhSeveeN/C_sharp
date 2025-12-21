namespace WyszukiwanieWLiscie;

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
        Console.WriteLine("Podaj liczbę do wyszukania:");
        int szukanaLiczba = Convert.ToInt32(Console.ReadLine());
        bool znaleziono = false;
        foreach (var liczba in liczby1)
        {
            if (liczba == szukanaLiczba)
            {
                znaleziono = true;
                break;
            }
        }
        if (znaleziono)
            {
                Console.WriteLine($"Liczba {szukanaLiczba} została znaleziona na liście, pod indeksem {liczby1.IndexOf(szukanaLiczba)}.");
            }
    }
}
