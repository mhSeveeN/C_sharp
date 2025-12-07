
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Program odwracający liczby");
        Console.WriteLine("Podaj liczbę do odwrócenia:");
        string liczba = Console.ReadLine();
        char[] chars = liczba.ToCharArray();
        Array.Reverse(chars);
        string odwróconaLiczba = new string(chars);
        Console.WriteLine("Odwrócona liczba: " + odwróconaLiczba);
    }
}