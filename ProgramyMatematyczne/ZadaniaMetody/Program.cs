// Zadanie 1: Sprawdzenie, czy trójkąt jest prostokątny
Console.WriteLine("Podaj długości boków trójkąta:");
Console.WriteLine("Bok a:");
int a = int.Parse(Console.ReadLine());
Console.WriteLine("Bok b:");
int b = int.Parse(Console.ReadLine());
Console.WriteLine("Bok c:");
int c = int.Parse(Console.ReadLine());
if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) ||
    Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2) ||
    Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2))
{
    Console.WriteLine("Trójkąt jest prostokątny.");
}
else
{
    Console.WriteLine("Trójkąt nie jest prostokątny.");
}

// Zadanie 2: Sprawdzenie, czy suma danych wartości początkowych tablicy nie przekracza danego progu
Console.WriteLine("Podaj rozmiar tablicy:");
int size = int.Parse(Console.ReadLine());
int[] array = new int[size];
Console.WriteLine("Podaj wartości do tablicy:");
for (int i = 0; i < size; i++)
{
    array[i] = int.Parse(Console.ReadLine());
}
Console.WriteLine("Podaj próg:");
int threshold = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 0; i < size; i++)
{
    sum += array[i];
    if (sum <= threshold)
    {
        Console.WriteLine($"Suma wartości początkowych tablicy w indeksie {i + 1} nie przekracza progu.");
        Console.WriteLine($"Aktualna tablica: [{string.Join(", ", array.Take(i + 1))}]");
    }
    else
    {
        break;
    }
}

// Zadanie 3: Sprawdzenie, czy 2 podane tablice są identyczne
Console.WriteLine("Podaj rozmiar pierwszej tablicy:");
int size1 = int.Parse(Console.ReadLine());
int[] array1 = new int[size1];
Console.WriteLine("Podaj wartości do pierwszej tablicy:");
for (int i = 0; i < size1; i++)
{
    array1[i] = int.Parse(Console.ReadLine());
}
Console.WriteLine("Podaj rozmiar drugiej tablicy:");
int size2 = int.Parse(Console.ReadLine());
int[] array2 = new int[size2];
Console.WriteLine("Podaj wartości do drugiej tablicy:");
for (int i = 0; i < size2; i++)
{
    array2[i] = int.Parse(Console.ReadLine());
}
if (size1 != size2)
{
    Console.WriteLine("Tablice nie są identyczne.");
}
else
{
    bool areIdentical = true;
    for (int i = 0; i < size1; i++)
    {
        if (array1[i] != array2[i])
        {
            areIdentical = false;
            break;
        }
    }
    if (areIdentical)
    {
        Console.WriteLine("Tablice są identyczne.");
    }
    else
    {
        Console.WriteLine("Tablice nie są identyczne.");
    }
}

// Zadanie 5: Zwrócenie n-tej liczby ciągu Fibonacciego
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ciąg Fibonacciego\nPodaj liczbę zakresu:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Ciąg Fibonacciego do zakresu {n}");
        int a = 0;
        int b = 1;
        Console.WriteLine(a);
        if (n == 1) return;
        Console.WriteLine(b);

        for (int i = 2; i < n; i++)
        {
            int c = a + b;
            Console.WriteLine(c);
            a = b;
            b = c;
        }
        Console.WriteLine($"{n}-ta liczba ciągu Fibonacciego: {b}");
    }
}

// Zadanie 6: Oblicznanie n silni dla podanego n
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Obliczanie silni\nPodaj liczbę n:");
        int n = int.Parse(Console.ReadLine());
        long factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        Console.WriteLine($"{n}! = {factorial}");
    }
}

// Zadanie 7: Rozkład zadanej liczby na dzielniki pierwsze
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Rozkład liczby na dzielniki pierwsze\nPodaj liczbę:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Dzielniki pierwsze liczby {n}: 1, ");
        for (int i = 2; i <= n; i++)
        {
            while (n % i == 0)
            {
                Console.WriteLine(i);
                n /= i;
            }
        }
    }
}

// Zadanie 8: Średnia arytmetyczna z podanych liczb
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Średnia arytmetyczna\nPodaj ilość liczb:");
        int count = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Podaj liczbę {i + 1}:");
            sum += double.Parse(Console.ReadLine());
        }
        double average = sum / count;
        Console.WriteLine($"Średnia arytmetyczna: {average}");
    }
}

// Zadanie 9: Suma skumulowana z podanych liczb
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Suma skumulowana\nPodaj ilość liczb:");
        int count = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Podaj liczbę {i + 1}:");
            sum += double.Parse(Console.ReadLine());
            Console.WriteLine($"Suma skumulowana po {i + 1} liczbach: {sum}");
        }
    }
}

// Zadanie 10: Odwrócenie łańcucha znaków
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Odwracanie łańcucha znaków\nPodaj łańcuch znaków:");
        string input = Console.ReadLine();
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        Console.WriteLine($"Odwrócony łańcuch znaków: {reversed}");
    }
}

// Zadanie 11: Sprawdzenie, czy podany łańcuch znaków jest palindromem
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Sprawdzanie palindromu\nPodaj łańcuch znaków:");
        string input = Console.ReadLine();
        string cleanedInput = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        char[] charArray = cleanedInput.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        if (cleanedInput == reversed)
        {
            Console.WriteLine("Podany łańcuch znaków jest palindromem.");
        }
        else
        {
            Console.WriteLine("Podany łańcuch znaków nie jest palindromem.");
        }
    }
}