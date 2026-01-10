namespace MagazynLista;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("WItaj na magazynie!");
        Console.WriteLine("Klucz to nazwa produktu, a wartość to jego ilość.");
        WJAZD:
        Console.WriteLine("Dostępne komendy: 1. dodaj, \n2. usuń, \n3. pokaż, \n4. zwiększ ilość");
        Dictionary<string, int> warehouse = new Dictionary<string, int>
        {
            { "H-52-20-LA", 10 },
        };
        Console.WriteLine ("Co chcesz zrobić?");
        string command = Console.ReadLine();
        if (int.TryParse(command, out int value)) 
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("Podaj nazwę produktu do dodania:");
                    string addProduct = Console.ReadLine();
                    Console.WriteLine("Podaj ilość produktu:");
                    int addQuantity = int.Parse(Console.ReadLine());
                    warehouse[addProduct] = addQuantity;
                    Console.WriteLine($"Dodano produkt {addProduct} z ilością {addQuantity}.");
                    goto WJAZD;
                case 2:
                    Console.WriteLine("Podaj nazwę produktu do usunięcia:");
                    string removeProduct = Console.ReadLine();
                    if (warehouse.Remove(removeProduct))
                    {
                        Console.WriteLine($"Usunięto produkt {removeProduct}.");
                    }
                    else
                    {
                        Console.WriteLine($"Produkt {removeProduct} nie istnieje.");
                    }
                    goto WJAZD;
                case 3:
                    Console.WriteLine("Zawartość magazynu:");
                    foreach (var item in warehouse)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    goto WJAZD;
                case 4:
                    Console.WriteLine("Podaj nazwę produktu do zwiększenia ilości:");
                    string increaseProduct = Console.ReadLine();
                    Console.WriteLine("Podaj ilość do dodania:");
                    int increaseQuantity = int.Parse(Console.ReadLine());
                    if (warehouse.ContainsKey(increaseProduct))
                    {
                        warehouse[increaseProduct] += increaseQuantity;
                        Console.WriteLine($"Zwiększono ilość produktu {increaseProduct} o {increaseQuantity}. Nowa ilość: {warehouse[increaseProduct]}.");
                    }
                    else
                    {
                        Console.WriteLine($"Produkt {increaseProduct} nie istnieje.");
                    }
                    break;
                default:
                    Console.WriteLine("Nieznana komenda.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowa komenda.");
        }

    }
}
