namespace LiczbyParzysteLista;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Program do wyświetlania listy liczb parzystych w zakresie od 0 do liczby podanej przez użytkownika");
        List<int> evenNumbers = new List<int>();
        Console.WriteLine("Podaj górną granicę zakresu:");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int upperLimit) && upperLimit >= 0)
        {
            for (int i = 0; i <= upperLimit; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(i);
                }
            }

            Console.WriteLine("Liczby parzyste w podanym zakresie:");
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("Proszę podać prawidłową nieujemną liczbę całkowitą.");
        }
    }
}
