namespace AnalizaTekstu;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        Console.WriteLine("Program czytający zdanie od użytkownika, który liczy liczbę występień danego słowa");
        Console.WriteLine("Podaj zdanie:");
        string input = Console.ReadLine();
        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            string lowerWord = word.ToLower();
            if (wordCount.ContainsKey(lowerWord))
            {
                wordCount[lowerWord]++;
            }
            else
            {
                wordCount[lowerWord] = 1;
            }
        };
        Console.WriteLine("Liczba wystąpień poszczególnych słów:");
        foreach (var item in wordCount)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        };
    }
}
