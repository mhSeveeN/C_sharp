internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("|+| Welcome Everybody on our flight. I hope you'll enjoy your work. |+|");
        Console.WriteLine("|+| I want to ask you What is the height that you're currently flying?:  |+|");
        int PlaneHeight = int.Parse(Console.ReadLine());
        if (PlaneHeight > 1000)
        {
            Console.WriteLine("|+| You're flying higher than you shouldn't - Please take down a little!! |+|");
        }
        else if (PlaneHeight <= 1000 && PlaneHeight > 800)
        {
            Console.WriteLine("|+| You're height is optimal, keep going :) |+|");
        }
        else
        {
            Console.WriteLine("|+| You're too close - PULL UP     PULL UP    PULL UP!!!! |+| ");
        }

        Console.WriteLine("=================================================================================================");
    }
}