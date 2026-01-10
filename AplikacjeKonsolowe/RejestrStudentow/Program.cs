namespace RejestrStudentow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Program używający słownika, gdzie klucz to nr indeksu, a wartość to imie i nazwisko, pozwalający na\n dodawanie, usuwanie i wyświetlanie studentów.");
        Dictionary<int, string> studentRegistry = new Dictionary<int, string>
        {
            {1, "Adam Sztacheta" },
        };
        Wjazd:
        Console.WriteLine("1. Dodaj studenta \n2. Wyświetl studentów \n3. Usuń studenta");
        string choice = Console.ReadLine();
        if (int.TryParse(choice, out int choice2))
        {
            switch (choice2)
            {
                case 1: 
                    Console.WriteLine("Dodaj studenta");
                    Console.WriteLine("Podaj nr indeksu studenta:");
                    string indexInput = Console.ReadLine();
                    Console.WriteLine("Podaj imię i nazwisko studenta:");
                    string nameInput = Console.ReadLine();
                    if (int.TryParse(indexInput, out int index) && !string.IsNullOrWhiteSpace(nameInput))
                    {
                        studentRegistry[index] = nameInput;
                        Console.WriteLine($"Student {nameInput} o nr indeksu {index} został dodany.");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowe dane studenta.");
                    }
                    goto Wjazd;
                    case 2: 
                    Console.WriteLine("Lista studentów:");
                    foreach (var student in studentRegistry)
                    {
                        Console.WriteLine($"Nr indeksu: {student.Key}, Imię i nazwisko: {student.Value}");
                    }
                    goto Wjazd;
                    case 3:
                    Console.WriteLine("Usuń studenta");
                    Console.WriteLine("Podaj nr indeksu studenta do usunięcia:");
                    string deleteIndexInput = Console.ReadLine();
                    if (int.TryParse(deleteIndexInput, out int deleteIndex))
                    {
                        if (studentRegistry.Remove(deleteIndex))
                        {
                            Console.WriteLine($"Student o nr indeksu {deleteIndex} został usunięty.");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono studenta o podanym nr indeksu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy nr indeksu.");
                    }
                    break;
            }
        }
    }
}
