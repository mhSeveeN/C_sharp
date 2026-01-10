namespace ListaZakupow;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> shoppingList = new List<string>();
        Console.WriteLine("Program do list zakupów");
        bool running = true;
        while (running)
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Dodaj produkt \n2. Wyświetl Liste zakupową \n3. Usuń produkt \n4. Wyjdź");
            Console.WriteLine("Wybierz opcję (1-4):");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int choice2))
            {
                switch (choice2)
                {
                    case 1:
                        Console.WriteLine("Dodaj produkt");
                        Console.WriteLine("Podaj nazwę produktu:");
                        string productName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(productName))
                        {
                            shoppingList.Add(productName);
                            Console.WriteLine($"Produkt {productName} został dodany do listy zakupów.");
                        }
                        else
                        {
                            Console.WriteLine("Nazwa produktu nie może być pusta.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Lista zakupów:");
                        if (shoppingList.Count == 0)
                        {
                            Console.WriteLine("Lista jest pusta.");
                        }
                        else
                        {
                            for (int i = 0; i < shoppingList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Usuń produkt");
                        Console.WriteLine("Podaj nazwę produktu do usunięcia:");
                        string productNameInput = Console.ReadLine();
                        if (shoppingList.Remove(productNameInput))
                        {
                            Console.WriteLine($"Produkt {productNameInput} został usunięty z listy zakupów.");
                        }
                        else
                        {
                            Console.WriteLine("Produkt nie znaleziony na liście.");
                        }
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wprowadź liczbę od 1 do 4.");
            }
        }
    }
}
