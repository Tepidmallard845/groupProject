using System;
using System.Collections.Generic;

public class ChessPointSystem
{
    private int WhitePoints = 0;
    private int BlackPoints = 0;

    private readonly Dictionary<string, int> PieceValues = new Dictionary<string, int>
    {
        { "Pawn", 1 },
        { "Knight", 3 },
        { "Bishop", 3 },
        { "Rook", 5 },
        { "Queen", 9 },
        { "King", 0 }
    };

    public void CapturePiece(string pieceName, string capturedBy)
    {
        if (PieceValues.ContainsKey(pieceName))
        {
            int points = PieceValues[pieceName];

            if (capturedBy == "White")
            {
                WhitePoints += points;
                Console.WriteLine($"White's points: {WhitePoints}"); //Just a test, to check for stuff
            }
            else if (capturedBy == "Black")
            {
                BlackPoints += points;
                Console.WriteLine($"Black's points: {BlackPoints}");
            }
            else
            {
                Console.WriteLine("Invalid player specified. Use 'White' or 'Black'.");
            }
        }
        else
        {
            Console.WriteLine($"Invalid piece name: {pieceName}. Valid pieces are: {string.Join(", ", PieceValues.Keys)}.");
        }
    }

    public void ResetPoints()
    {
        WhitePoints = 0;
        BlackPoints = 0;
        Console.WriteLine("Points have been reset.");
    }

    public (int whitePoints, int blackPoints) GetPoints()
    {
        return (WhitePoints, BlackPoints);
    }

    public void DisplayPoints()
    {
        Console.WriteLine($"Current Points - White: {WhitePoints}, Black: {BlackPoints}");
    }
}
