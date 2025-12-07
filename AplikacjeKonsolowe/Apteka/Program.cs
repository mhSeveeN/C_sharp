internal class Program
{
    private static void Main(string[] args)
    {
        string[] stan2 = {"Apap", "Pyralgina", "4FLEX", "Ibuprofen", "AMOL", "Cholinex", "Tyraflex", "ApapNOC", "Choligrip", "Gripex"};
        int[] stan = {8, 9, 5, 3, 2, 10, 15, 20, 32, 1}; //stan na pólce
        int[] minimum = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10}; // próg, poniżej którego trzeba zamówić
        double[] cena = {7.59, 8.99, 9.11, 10.99, 7.65, 8.56, 9.99, 10.99, 7.99, 10.99}; // cena jednej sztuki w zł
        double KosztCalkowity = 0;
        int sumaLekow = 0;
        double maxKoszt = 0;

        for (int i = 0; i < stan.Length; i++)
        {
            if (stan[i] < minimum[i])
            {
                int brakuje = minimum[i] - stan[i];
                double cenaLeku = brakuje * cena[i];
                KosztCalkowity += cenaLeku;
                sumaLekow += brakuje;
                Console.WriteLine($"Pozycja {i}, czyli brakuje {brakuje} szt., które można kupic za {cenaLeku} zł");
                if (cenaLeku > maxKoszt)
                {
                    maxKoszt = cenaLeku;
                }
            }
        }
        Console.WriteLine($"Koszt całkowity wyniósł {KosztCalkowity}, a łączna liczba leków do domówienia to {sumaLekow}");
        Console.WriteLine($"Największy koszt za leki to {maxKoszt}");

    }
}