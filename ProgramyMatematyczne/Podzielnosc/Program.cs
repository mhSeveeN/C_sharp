namespace Podzielnosc;

class Program
{
    static bool CzyPodzielna(int liczba, int dzielnik)
    {
       if (liczba % dzielnik == 0)
            return true;
        else
            return false;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Program sprawdzający podzielność");
        Console.Write("Podaj dwie liczby całkowite: ");
        int liczba = Convert.ToInt32(Console.ReadLine());
        int dzielnik = Convert.ToInt32(Console.ReadLine());
        bool wynik = CzyPodzielna(liczba, dzielnik);
        if (wynik)
            Console.WriteLine("Liczba " + liczba + " jest podzielna przez " + dzielnik);
        else
            Console.WriteLine("Liczba " + liczba + " nie jest podzielna przez " + dzielnik);
    }
}
