using System;

public class WinScreen
{
    public void DisplayResult(string gamewin)
    {
        if (gamewin == "White")
        {
            Console.WriteLine("White Wins");
        }
        else if (gamewin == "Black")
        {
            Console.WriteLine("Black Wins");
        }
        else
        {
            Console.WriteLine("Draw");
        }
    }
}