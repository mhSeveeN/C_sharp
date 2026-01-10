namespace SloWnikTlumaczen;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Słownik tłumaczeń, gdzie klucz to słowo w języku angielskim, a wartość to tłumaczenie w języku polskim.");
        Dictionary<string, string> translationDictionary = new Dictionary<string, string>
        {
            { "hello", "cześć" },
            { "dog", "pjes" },
            { "cat", "sierściuch" }
        };
        Console.WriteLine("Podaj słowo w języku angielskim do przetłumaczenia:");
        string inputWord = Console.ReadLine();
        if (translationDictionary.TryGetValue(inputWord, out string translatedWord))
        {
            Console.WriteLine($"Tłumaczenie słowa '{inputWord}' to '{translatedWord}'.");
        }
        else
        {
            Console.WriteLine($"Brak tłumaczenia dla słowa '{inputWord}' w słowniku.");
        }
    }
}
