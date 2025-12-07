internal class Program
{
    private static void Main(string[] args)
    {
        Random lose = new Random();
        int liczba = lose.Next(1, 101);
        Console.WriteLine("Witaj użytkowniku!! Wylosuj liczbę z przedziału <1, 10>");
        //Console.WriteLine(liczba);
        int traf = int.Parse(Console.ReadLine());
        if (traf == liczba)
        {
            Console.WriteLine("Twój traf jest szczęśliwy!!!! To dokładnie ta liczba!!!");
        } else if (traf < liczba)
        {
            Console.WriteLine("Dzisiaj nie masz szczęścia!!  Twój traf jest za mały!!");
        } else
        {
            Console.WriteLine("Nie masz szczęscia!! Twój traf jest za duży!!");
        }
    }
}