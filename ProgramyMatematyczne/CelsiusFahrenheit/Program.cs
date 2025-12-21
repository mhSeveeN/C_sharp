namespace CelsiusFahrenheit;

class Program
{
    static double Convert(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Przelicznik temp. Celsjusza na Fahrenheita.");
        Console.WriteLine("");
        Console.WriteLine("Podaj temp. w st. Celsiusza:");
        double celsius = double.Parse(Console.ReadLine());
        double wynik = Convert(celsius);
        Console.WriteLine("Temperatura w st. Fahrenheita wynosi: " + wynik + " F");
    }
}
