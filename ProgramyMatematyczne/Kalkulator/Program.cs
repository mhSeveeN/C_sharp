using System;

class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        int result = calc.Add(2, 3);
        Console.WriteLine("Wynik dodawania " + result);
    }
}