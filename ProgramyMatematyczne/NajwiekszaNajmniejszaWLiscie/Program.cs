namespace NajwiekszaNajmniejszaWLiscie;

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
        int max = liczby1[0];
        int min = liczby1[0];
        foreach (var liczba in liczby1)
        {
            if (liczba > max)
            {
                max = liczba;
            }
            if (liczba < min)
            {
                min = liczba;
            }
        }
        Console.WriteLine($"Największa liczba to: {max}");
        Console.WriteLine($"Najmniejsza liczba to: {min}");        
    }
}
