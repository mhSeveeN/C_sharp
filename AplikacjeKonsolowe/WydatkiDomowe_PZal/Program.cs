/*

    <Program służący do zarządzania wydatkami domowymi, działający interaktywnie z użytkownikiem. >
    <Autor: mhSeveeN >
    <Date: 01.01.2026r.
*/

namespace WydatkiDomowe_PZal;

class Program
{
    class Expense //Klasa reprezentująca wydatek, Wydatki trzymane w liście.
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public Expense(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
    static void Main(string[] args)  //Główna metoda programu
    {
        List<Expense> expenses = new List<Expense>(); //Utworzenie listy wydatków
        Console.WriteLine("Witaj w aplikacji do zarządzania wydatkami domowymi!");
        back: //Etykieta powrotu pętli switch
        Console.WriteLine("MENU:");
        Console.WriteLine("1. Dodaj wydatek \n2. Wyświetl listę wydatków \n3. Oblicz łączną kwotę wydatków \n4. Znajdź największy wydatek \n5. WYJŚCIE"); //Wyświetlenie menu
        Console.WriteLine("Wybierz opcję (1-5):");

        string choice = Console.ReadLine();
        if (int.TryParse(choice, out int UsrChoice)) //Wprowadzenie do pętli switch case
        {
            switch (UsrChoice)
            {
                case 1: //Opcja 1: Dodawanie wydatków
                    Console.WriteLine("Wybrano opcję: Dodawania wydatków");
                    Console.WriteLine("Podaj nazwę wydatku:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Podaj kwotę wydatku:");
                    string amountInput = Console.ReadLine();
                    if (double.TryParse(amountInput, out double amount))
                    {
                        expenses.Add(new Expense(name, amount));
                        Console.WriteLine("Wydatek dodany pomyślnie.");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa kwota. Wydatek nie został dodany."); //Walidacja poprawności kwoty
                    }

                    goto back; //Powrót do menu głównego
                    
                case 2: //Opcja 2: Wyświetlanie listy wydatków
                    Console.WriteLine("Wybrano opcję: Wyświetlania listy wydatków");
                    if (expenses.Count == 0)
                    {
                        Console.WriteLine("Brak wydatków do wyświetlenia."); //Walidacja zawartości listy
                    }
                    else
                    {
                        Console.WriteLine("Lista wydatków:");
                        foreach (var expense in expenses)
                        {
                            Console.WriteLine($" Nazwa: {expense.Name}, ======> {expense.Amount} zł");
                        }
                    }
                    goto back;

                case 3: //Opcja 3: Obliczanie łącznej kwoty wydatków
                    Console.WriteLine("Wybrano opcję: Obliczania łącznej kwoty wydatków");
                    double total = expenses.Sum(e => e.Amount);
                    Console.WriteLine($"Łączna kwota wydatków: {total} zł.");
                    goto back;

                case 4: //Opcja 4: Znajdowanie największego wydatku
                    Console.WriteLine("Wybrano opcję: Znajdowania największego wydatku");
                    double maxExpense = 0;
                    string maxExpenseName = "";
                    foreach (var expense in expenses)
                    {
                        if (expense.Amount > maxExpense)
                        {
                            maxExpense = expense.Amount;
                            maxExpenseName = expense.Name;
                        }
                    }
                    Console.WriteLine($"Największy wydatek to {maxExpenseName} o wartości {maxExpense} zł.");
                    goto back;

                case 5: //Opcja 5: Wyjście z programu
                    Console.WriteLine("Do widzenia!");
                    break;

                default: //Walidacja poprawności wyboru opcji pętli switch case
                    Console.WriteLine("Nieprawidłowa opcja. Uruchom program ponownie.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowe dane wejściowe. Uruchom program ponownie."); //Walidacja poprawności wprowadzenia wyboru opcji
        }
    }
}
