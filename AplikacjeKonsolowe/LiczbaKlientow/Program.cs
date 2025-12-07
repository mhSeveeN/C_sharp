internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Witaj w programie mierzącym liczbę klientów w sklepie!!");
        int[] klienci = {23, 46, 52, 7, 2, 10, 30, 15, 16, 17, 1, 0};
        int sumaKlientow = 0;
        int max = klienci[0];
        int godzina = klienci[0];

        for (int i=0; i < klienci.Length; i++)
        {
            if (max < klienci[i] )
            {
                max = klienci[i];
                godzina = i;
            }   
            sumaKlientow = sumaKlientow + klienci[i];         
        }
        if (max>20 )
            {
                Console.WriteLine("Potrzeba dodatkowej obsługi");
            }
        Console.WriteLine("Sklep odwiedzilo " + sumaKlientow + " klientów");
        Console.WriteLine($"Najwięcej klientów było {max} o godzinie {godzina}");
    }
}