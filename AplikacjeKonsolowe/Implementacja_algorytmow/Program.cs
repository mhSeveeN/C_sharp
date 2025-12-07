namespace Implementacja_algorytmow
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int temperatura = 20;
            bool wodaSieGotuje = false;
            Helper.PrzygotujGarnekIZalejWoda();
            Helper.OdpalPalnik();
            while (!wodaSieGotuje)
            {
                wodaSieGotuje = Helper.GotujWode(ref temperatura);
                Console.WriteLine($"Aktualna temperatura wody: {temperatura}stC, Woda się gotuje - {wodaSieGotuje}");
            }
            Helper.UgotujJajko();
        }
    }
}