namespace Restauracja;

class Program
{
    static void Main(string[] args)
    {
        List<string> orders = new List<string>();
        Dictionary<string, int> Counter = new Dictionary<string, int>();
        Console.WriteLine("Welcome everybody in our restaurant. \nYou won't eat anything because its just a computer, but you can pay for it.");
        while (true)
        {
            Console.WriteLine("What do you want to order? (Type 'exit' to finish)");
            string order = Console.ReadLine();
            if (order.ToLower() == "exit")
                break;

            orders.Add(order);

            if (Counter.ContainsKey(order))
                Counter[order]++;
            else
                Counter[order] = 1;
        }

        
        Console.WriteLine("\nAll orders in order:");
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }

        
        Console.WriteLine("\nOrder counts:");
        foreach (var item in Counter)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        
        while (true)
        {
            Console.WriteLine("\nEnter the order to remove (or 'done' to finish):");
            string removeOrder = Console.ReadLine();
            if (removeOrder.ToLower() == "done")
                break;

            if (orders.Contains(removeOrder))
            {
                orders.Remove(removeOrder);
                if (Counter.ContainsKey(removeOrder))
                {
                    Counter[removeOrder]--;
                    if (Counter[removeOrder] == 0)
                        Counter.Remove(removeOrder);
                }
                Console.WriteLine("Order removed.");
            }
            else
            {
                Console.WriteLine("Error: Order not found.");
            }
        }
    }
}
