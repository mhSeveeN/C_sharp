/*
   < Program służący jako kalkulator ilości i ceny napojów, działający interaktywnie z użytkownikiem. >
   < Autor: mhSeveeN >
   < Date: 07.11.2025r. >
*/
internal class Program
{
    private static void Main(string[] args)
    {
        //Menu
        Console.WriteLine("====== MENU ======");
        Console.WriteLine("1 - Kawa - 7zł/kubek");
        Console.WriteLine("2 - Herbata - 5zł/kubek");
        Console.WriteLine("3 - Woda - 3zł/500ml");
        Console.WriteLine("4 - Exit");
        Console.WriteLine("Witaj w kalkulatorze napojów!!! ");
        Console.WriteLine("Wybierz opcję (1 - 4): ");//Interakcja z użytkownikiem

        //Wczytanie danych od użytkownika
        string input = Console.ReadLine();

        if (int.TryParse(input, out int wybor))
        {
            switch (wybor) //switch case
            {
                case 1:
                    Console.WriteLine("Wybrałeś kawę!!");
                    Console.WriteLine("Ile chcesz zakupić?");
                    string input2 = Console.ReadLine();
                    int cenaKawa = int.Parse(input2) * 7;
                    Console.WriteLine($"Zapłata wynosi: {cenaKawa} zł");
                    break;

                case 2:
                    Console.WriteLine("Wybrałeś Herbatę!!");
                    Console.WriteLine("Ile chcesz zakupić?");
                    string input3 = Console.ReadLine();
                    int cenaHerbata = int.Parse(input3) * 5;
                    Console.WriteLine($"Zapłata wynosi: {cenaHerbata} zł");
                    break;

                case 3:
                    Console.WriteLine("Wybrałeś Wodę");
                    Console.WriteLine("Ile chcesz zakupić?");
                    string input4 = Console.ReadLine();
                    int cenaWoda = int.Parse(input4) * 3;
                    Console.WriteLine($"Zapłata wynosi: {cenaWoda} zł");
                    break;

                case 4:
                    Console.WriteLine("Do Widzenia!!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Ta opcja nie istnieje w MENU! Uruchom program ponownie!!");
        }
    }
}