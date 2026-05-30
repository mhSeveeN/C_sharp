using System;
namespace KlasaWiek1
{

    class cOsoba
    {
        public int wiek;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            cOsoba o = new cOsoba();
            o.wiek = 13;
            Console.WriteLine("Wiek osoby to " + o.wiek.ToString() + " lat");
        }
    }
}
