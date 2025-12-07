internal class Program
{
    private static void Main(string[] args)
    {
        string[] nazwa = {"BOD7", "H-15-52-20-LA", "BOD10", "W-15-75-30-LA", "Adaptor 52 2 inch F"};
        int[] ilosc = {17, 30, 50, 10, 5};
        double[] cena = {25.98, 10.99, 15.96, 99.99, 58.89};
        double portfel = 0;

        Console.WriteLine("Witaj w naszym magazyenie!!");
        Console.WriteLine("1 - dokonaj zakupu");
        Console.WriteLine("2 - Dodaj produkt");
        Console.WriteLine("3 - Wyświetl sumę zakupów (portfel)");
        Console.WriteLine("4 - EXIT");
        Console.WriteLine("Wybierz opcję, co chcesz zrobić");
        string input1 = Console.ReadLine();

        if (int.TryParse(input1, out int wybor))
        {
            switch (wybor)
            {
                case 1: 
                int zakup = 0;
                Console.WriteLine("Wybrałeś opcję zakupu, Co chcesz zakupić?: ");
                string nazwaZakup = Console.ReadLine();
                for (int i = 0; i < nazwa.Length; i++)
                {
                    if (nazwaZakup == nazwa[i])
                    {
                        Console.WriteLine("Ile tego chcesz kupić?");
                        zakup = int.TryParse(Console.ReadLine());
                        if ()
                    }
                
                }
            }
        }
        
        
    }
}