internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Program do obliczania pola figur");
        Console.WriteLine("Wybierz figurę, której pole chcesz liczyć (1. - 4.):");
        Console.WriteLine("1. Kwadrat");
        Console.WriteLine("2. Prostokąt");
        Console.WriteLine("3. Trójkąt");
        Console.WriteLine("4. Trapez");

        string wybor1 = Console.ReadLine();

        if (int.TryParse(wybor1, out int wybor))
        {
            switch(wybor)
            {
                case 1:
                    Console.WriteLine("Podaj długość boku kwadratu: ");
                    int bokKw = int.Parse(Console.ReadLine());
                    float Pole = bokKw * bokKw;
                    Console.WriteLine("Pole kwadratu o boku " + bokKw + "wynosi " + Pole);
                    break;

                case 2:
                    Console.WriteLine("Podaj dlugosci boków prostokąta: ");
                    int bok1 = int.Parse(Console.ReadLine());
                    int bok2 = int.Parse(Console.ReadLine());
                    float Pole = bok1 * bok2;
                    Console.WriteLine("Pole prostokąta o bokach " + bok1 + " i " + bok2 + " wynosi " + Pole);
                    break;

                case 3:
                    Console.WriteLine("Podaj długość boku trójkąta i jego wysokość:");
                    int bok1 = int.Parse(Console.ReadLine());
                    int wysokosc = int.Parse(Console.ReadLine());
                    float Pole = (bok1 * wysokosc) / 2;
                    Console.WriteLine("Pole trójkąta o podstawie " + bok1 + " i wysokosci " + wysokosc + " wynosi " + Pole);
                    break;
            }
        }
    }
}