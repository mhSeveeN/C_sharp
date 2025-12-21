using System;

namespace ToDoList;

class Zadanie
{
    public string Opis { get; set; }
    public bool IsCompleted { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Witaj w systemie zarządzania listą zadań!");
        List<Zadanie> ListaZadan = new List<Zadanie>();
        
        while (true)
        {
            Console.WriteLine("\nMENU\n1. Wyświetl listę zadań\n2. Dodaj zadanie\n3. Usuń zadanie\n4. Oznacz zadanie jako wykonane\n5. Zakończ program");
            Console.WriteLine("Wybierz opcję (1-5):");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                switch (result)
                {
                    case 1:
                        Console.WriteLine("Wyświetlanie listy zadań...");
                        if (ListaZadan.Count == 0)
                        {
                            Console.WriteLine("Brak zadań na liście.");
                        }
                        else
                        {
                            for (int i = 0; i < ListaZadan.Count; i++)
                            {
                                var zadanie = ListaZadan[i];
                                string status = zadanie.IsCompleted ? "Wykonane" : "Nie wykonane";
                                Console.WriteLine($"{i + 1}. {zadanie.Opis} - {status}");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Dodawanie zadania...");
                        Console.WriteLine("Podaj opis zadania:");
                        string opis = Console.ReadLine();
                        ListaZadan.Add(new Zadanie { Opis = opis, IsCompleted = false });
                        Console.WriteLine("Zadanie zostało dodane.");
                        break;
                    case 3:
                        Console.WriteLine("Usuwanie zadań...");
                        Console.WriteLine("Podaj numer zadania do usunięcia:");
                        if (int.TryParse(Console.ReadLine(), out int numerZadania) && numerZadania > 0 && numerZadania <= ListaZadan.Count)
                        {
                            ListaZadan.RemoveAt(numerZadania - 1);
                            Console.WriteLine("Zadanie zostało usunięte.");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer zadania.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Oznaczanie zadania jako wykonanego...");
                        Console.WriteLine("Podaj numer zadania do oznaczenia jako wykonanego:");
                        if (int.TryParse(Console.ReadLine(), out int numerZadaniaWykonane) && numerZadaniaWykonane > 0 && numerZadaniaWykonane <= ListaZadan.Count)
                        {
                            ListaZadan[numerZadaniaWykonane - 1].IsCompleted = true;
                            Console.WriteLine($"Zadanie '{ListaZadan[numerZadaniaWykonane - 1].Opis}' zostało oznaczone jako wykonane.");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer zadania.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Zakończenie programu. \nDo widzenia!");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Wybierz 1-5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wprowadź prawidłową liczbę.");
            }
        }
    }
}
