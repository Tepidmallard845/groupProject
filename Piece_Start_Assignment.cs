using System;
using System.Collections.Generic;

public class ChessBoardSetup
{
    private static Dictionary<string, List<(int x, int y)>> piecePositions = new Dictionary<string, List<(int, int)>>
    {
        { "White_Rook.png", new List<(int, int)> { (0, 7), (7, 7) } },
        { "White_Knight.png", new List<(int, int)> { (1, 7), (6, 7) } },
        { "White_Bishop.png", new List<(int, int)> { (2, 7), (5, 7) } },
        { "White_Queen.png", new List<(int, int)> { (3, 7) } },
        { "White_King.png", new List<(int, int)> { (4, 7) } },
        { "White_Pawn.png", new List<(int, int)> { (0, 6), (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6) } },
        { "Black_Rook.png", new List<(int, int)> { (0, 0), (7, 0) } },
        { "Black_Knight.png", new List<(int, int)> { (1, 0), (6, 0) } },
        { "Black_Bishop.png", new List<(int, int)> { (2, 0), (5, 0) } },
        { "Black_Queen.png", new List<(int, int)> { (3, 0) } },
        { "Black_King.png", new List<(int, int)> { (4, 0) } },
        { "Black_Pawn.png", new List<(int, int)> { (0, 1), (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1) } }
    };

    public static List<(int x, int y)> GetPiecePositions(string pieceName)
    {
        if (piecePositions.TryGetValue(pieceName, out var positions))
        {
            return positions;
        }
        else
        {
            throw new ArgumentException($"Piece name {pieceName} is not recognized."); //Used to Check
        }
    }
