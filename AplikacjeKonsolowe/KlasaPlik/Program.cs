using System;
using System.IO;

namespace KlasaPlik;

public class Plik
{
    private string sciezka;
    private string plik;
    private string tekst;

    public string Sciezka
    {
        get => sciezka;
        set => sciezka = value;
    }

    public string PlikNazwa
    {
        get => plik;
        set => plik = value.EndsWith(".txt") ? value : value + ".txt";
    }

    public string Tekst
    {
        get => tekst;
        set => tekst = value;
    }

    public Plik(string sciezka, string plik, string tekst)
    {
        this.sciezka = sciezka;
        this.plik = plik.EndsWith(".txt") ? plik : plik + ".txt";
        this.tekst = tekst;
    }

    public string PelnaSciezka()
    {
        return Path.Combine(sciezka, plik);
    }

    public void Zapisz()
    {
        Directory.CreateDirectory(sciezka);
        File.WriteAllText(PelnaSciezka(), tekst);
    }

    public void SkopiujPlik(string zrodlo)
    {
        if (!File.Exists(zrodlo))
        {
            throw new FileNotFoundException("Plik źródłowy nie istnieje.", zrodlo);
        }

        Directory.CreateDirectory(sciezka);
        File.Copy(zrodlo, PelnaSciezka(), overwrite: true);
        tekst = File.ReadAllText(PelnaSciezka());
    }

    public override string ToString()
    {
        return $"Sciezka: {sciezka}, Plik: {plik}, Tekst: {tekst}";
    }
}

public class Szyfruj_plik
{
    private Plik plik;
    private bool stan;

    public Plik Plik
    {
        get => plik;
        set => plik = value;
    }

    public bool Stan
    {
        get => stan;
        set => stan = value;
    }

    public Szyfruj_plik(Plik plik)
    {
        this.plik = plik;
        this.stan = false;
    }

    private static char EncryptChar(char ch, int a, int b)
    {
        if (char.IsUpper(ch))
        {
            return (char)(((a * (ch - 'A') + b) % 26 + 26) % 26 + 'A');
        }
        if (char.IsLower(ch))
        {
            return (char)(((a * (ch - 'a') + b) % 26 + 26) % 26 + 'a');
        }
        return ch;
    }

    private static char DecryptChar(char ch, int a, int b)
    {
        if (char.IsUpper(ch))
        {
            int aInv = ModularInverse(a, 26);
            return (char)(((aInv * ((ch - 'A') - b)) % 26 + 26) % 26 + 'A');
        }
        if (char.IsLower(ch))
        {
            int aInv = ModularInverse(a, 26);
            return (char)(((aInv * ((ch - 'a') - b)) % 26 + 26) % 26 + 'a');
        }
        return ch;
    }

    private static int ModularInverse(int a, int mod)
    {
        int t = 0, newT = 1;
        int r = mod, newR = a % mod;

        while (newR != 0)
        {
            int quotient = r / newR;
            (t, newT) = (newT, t - quotient * newT);
            (r, newR) = (newR, r - quotient * newR);
        }

        if (r > 1)
        {
            throw new ArgumentException("Klucz a nie ma odwrotności modulo 26.");
        }

        if (t < 0)
        {
            t += mod;
        }

        return t;
    }

    public void SzyfrujPlik(int a, int b)
    {
        if (stan)
        {
            return;
        }

        string wynik = string.Empty;
        foreach (char c in plik.Tekst)
        {
            wynik += EncryptChar(c, a, b);
        }

        plik.Tekst = wynik;
        stan = true;
    }

    public void DeszyfrujPlik(int a, int b)
    {
        if (!stan)
        {
            return;
        }

        string wynik = string.Empty;
        foreach (char c in plik.Tekst)
        {
            wynik += DecryptChar(c, a, b);
        }

        plik.Tekst = wynik;
        stan = false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Plik plik = new Plik("D:\\Programs\\PierwszyProjektC#\\C_sharp\\AplikacjeKonsolowe\\KlasaPlik", "sample.txt", "To jest zawartość pliku.");
        Console.WriteLine(plik.ToString());
        plik.Zapisz();

        Plik kopia = new Plik("D:\\Programs\\PierwszyProjektC#\\C_sharp\\AplikacjeKonsolowe\\KlasaPlik", "sample_copy.txt", string.Empty);
        kopia.SkopiujPlik(plik.PelnaSciezka());
        Console.WriteLine(kopia.ToString());

        Szyfruj_plik szyfr = new Szyfruj_plik(plik);
        szyfr.SzyfrujPlik(5, 8); // przykładowe klucze a=5, b=8
        Console.WriteLine($"Zaszyfrowany tekst: {plik.Tekst}");

        szyfr.DeszyfrujPlik(5, 8);
        Console.WriteLine($"Odszyfrowany tekst: {plik.Tekst}");
    }
}
