string usrname = "user1234";
string pass = "pass1234";


Console.WriteLine("Witaj na portalu logowania!!");
Console.WriteLine("Podaj nazwę użytkownika:");
string username = Console.ReadLine();
Console.WriteLine("Podaj hasło:");
string password = Console.ReadLine();
if (usrname == username && pass == password)
{
    Console.WriteLine("Zalogowano pomyślnie!");
} 
else 
{
    Console.WriteLine("Błędna nazwa użytkownika lub hasło.");
}
