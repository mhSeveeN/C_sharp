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
    }
}
