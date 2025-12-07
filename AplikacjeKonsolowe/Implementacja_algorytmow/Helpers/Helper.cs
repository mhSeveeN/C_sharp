namespace Implementacja_algorytmow.Helpers
{
    public static class Helper
    {
        public static void Powitanie()
        {
            Console.WriteLine("Witaj w programie Implementacja_algorytmow");
        }
        public static void PrzygotujGarnekIZalejWoda()
        {
            Console.WriteLine("Wyciągnij garnek z szafki");
            Console.WriteLine("Napełnij garnek wodą");
        }
        public static void OdpalPalnik()
        {
            Console.WriteLine("Odpal palnik pod garnkiem");
            Console.WriteLine("Gotuj wodę do wrzenia");
        }

        ///<summary>
        ///Gotuj wode, zwiększamy temperaturę od 16 do 100 stopni 
        ///Funkcja zwraca true, gdy woda osiągnie 100stopni
        ///</summary>
        public static bool GotujWode(ref int temperatura)
        {
            Random rand = new Random();
            temperatura += rand.Next(1, 10);
            if (temperatura >= 100)
            {
                temperatura = 100;
                return true;
            }
            return false;
        }

        ///<summary>
        ///Procedura gotowania jajka na miękko po minucie
        ///aż wylosujemy, że jajko jest ugotowane
        ///</summary>
        public static void UgotujJajko()
        {
            Console.WriteLine("Włóż jajko do gorącej wody!!");
            Console.WriteLine("Czekaj 3min");
            bool jajkougotowane = false;

            while (!jajkougotowane)
            {
                Console.WriteLine("Gotuj minute.");
                jajkougotowane = CzyJajkoUgotowaneLosowo();

                if (jajkougotowane)
                {
                    Console.WriteLine("Jajko jest ugotowane n miekko bo sie kręci.");
                }
                else
                {
                    Console.WriteLine("Jajko nie jest jeszcze ugotowane, kontynuuj");
                }
            }
        }
        private static bool CzyJajkoUgotowaneLosowo()
        {
            int wartosc = new Random().Next(0, 2);
            return wartosc = 1;

        }
    }
}