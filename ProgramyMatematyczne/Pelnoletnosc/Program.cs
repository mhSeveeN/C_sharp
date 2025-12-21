namespace Pelnoletnosc;

class Program
{
     static int Pelnoletnosc (int wiekUrz, int granica = 18)
        {
            if (wiekUrz >= granica)
                return 1;
            else
                return 0;
        }
    static void Main(string[] args)
    {
        Console.WriteLine("Program sprawdzający pełnoletność użytkownika.");
        Console.Write("Podaj swój wiek: ");
        int wiekUrz = Convert.ToInt32(Console.ReadLine());
        Pelnoletnosc(wiekUrz);
        Console.WriteLine(Pelnoletnosc(wiekUrz) == 1 ? "Jesteś pełnoletni." : "Nie jesteś pełnoletni.");
        

    }
}
