internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Witaj w programie sumującym kolejne liczby");
        Console.WriteLine("Podaj ile liczb chcesz zsumować?:");
        int Liczba = int.Parse(Console.ReadLine());
        int suma = 0;
        for (int i = 0; i <= Liczba; i++)
        {
            suma += i;
            Console.WriteLine(suma);
        }
        Console.WriteLine($"Wynik to {suma}");
    }
}