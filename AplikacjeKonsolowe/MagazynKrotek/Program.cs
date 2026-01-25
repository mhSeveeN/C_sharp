namespace MagazynKrotek;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Witaj w magazynie!!");
        List<(string name, double price, int quatity)> products = new List<(string name, double price, int quatity)>
        {
            (name: "milk", price: 4.0, quatity: 20),
            (name: "bread", price: 3.5, quatity: 15),
            (name: "butter", price: 6.0, quatity: 10)
        };
        Console.WriteLine("\nCzy chcesz coś dodać do stanu magazynowego? (y/n)");
        string input1 = Console.ReadLine();
        if (input1 == "y")
        {
            AddProduct(products);
        } else
        {
            Console.WriteLine("Stan magazynowy nie uległ zmianie.");
        }
        Console.WriteLine("Czy chcesz zobaczyć stan magazynowy, lub dodać coś jeszcze? (M - stan magazynowy/D - dodawanie kolejnego produktu/n - wyjście)");
        string input2 = Console.ReadLine();
        if (input2 == "M" || input2 == "m")
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Produkt: {product.name}, Cena: {product.price}, Ilość: {product.quatity}");
            }
        } else if (input2 == "D" || input2 == "d")
        {
            AddProduct(products);
        } else
        {
            Console.WriteLine("Do widzenia!");
        }

        Console.WriteLine("Całkowita wartość magazynu:");
        double totalValue = 0;
        foreach (var product in products)
        {
            totalValue += product.price * product.quatity;
        }
        Console.WriteLine($"\nWartość magazynu: {totalValue}");
    }

    static void AddProduct(List<(string name, double price, int quatity)> products)
    {
        Console.WriteLine("Podaj nazwę produktu:");
        string productName = Console.ReadLine();
        Console.WriteLine("\nPodaj cenę produktu:");
        double productPrice = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nPodaj ilość produktu:");
        int productQuantity = Convert.ToInt32(Console.ReadLine());
        var newProduct = (name: productName, price: productPrice, quatity: productQuantity);
        products.Add(newProduct);
        Console.WriteLine($"\nDodano produkt: {newProduct.name}, Cena: {newProduct.price}, Ilość: {newProduct.quatity}");
    }
}
