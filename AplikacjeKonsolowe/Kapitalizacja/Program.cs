internal class Program
{
    private static void Main(string[] args)
    {
        string input = "hello world";

        string result = StringHelper.Capitalize(input);
        Console.WriteLine(result);
    }
}