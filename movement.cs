using System;

namespace Pieces
{
  class movement
  {
    /*static void checkMove(var piece) {
        switch piece[0]
        {
            case 'rook'
        }
    }*/

    static void Main(string[] args)
    {   
        char[] abcs = {'a','b','c','d','e','f','g','h'};
        char[] nums = {'1','2','3','4','5','6','7','8'};
        //checkMove({'rook', 0, 0});
        for (int y = 8; y >= 1; y--)
        {
            for (int x = 1; x <= 8; x++)
            {
                Console.Write($"{x}{y} ");
            }
            Console.WriteLine();
        }
    }

  }
}