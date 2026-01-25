namespace KrotkaImieNazTel;

class Program
{
    static void Main(string[] args)
    {
        var person = (name: "Jan", surname: "Kowalski", phone: "123-456-789");
        Console.WriteLine($"Imię i nazwisko: {person.name} {person.surname}, Telefon: {person.phone}");
    }
}
