using System;
using System.Collections.Generic;
class Program
{
static void Main()
{

// Tworzenie listy z inicjalnymi wartościami
List<int> listaLiczb = new List<int> { 22, 23, 32, 41, 51 };
// Wyświetlenie elementów listy
foreach (var liczba in listaLiczb)
{
Console.WriteLine(liczba);
}
}
}
