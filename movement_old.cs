using System;
using System.IO;
using System.Collections.Generic;

namespace Pieces
{
  class Movement
  {
    static int[] toVector(string toFind)
    {
      char[] alpha = {'a','b','c','d','e','f','g','h'};
      
      int xPos = Array.IndexOf(alpha, char.ToLower(toFind[0]));
      int yPos = 8-(toFind[1]-'0');
      int[] result = {xPos,yPos};

      return result;
    }

    static string toWords(int[] vector)
    {
      char[] alpha = {'a','b','c','d','e','f','g','h'};
      
      return $"{alpha[vector[0]]}{8-vector[1]}";
    }

    static string Locate(int[] cell)
    {
      string boardTotal = File.ReadAllText("board.csv");
      string[] boardRows = boardTotal.Split('\n');
      string[][] board = new string[boardRows.Length][];

      for (int i=0; i<board.Length; i++)
      {
        board[i] = boardRows[i].Split(',');
      }
      //int[] cellPos = toVector(cell);
      string contents = board[cell[1]][cell[0]];

      return contents;
    }

    static List<int[]>[] checkMove(string piece, int[] pos)
    {
      List<int[]> moves = new List<int[]>();
      List<int[]> captures = new List<int[]>();
      //if (piece.Length != 0) {piece=piece.Substring(1);}
      switch(piece.Substring(1))
      {
        case "rook":

          for (int i=(pos[0]+1); i<8; i++) //Right movement
          {
            int[] newPos = new int[] {i,pos[1]};
            if (Locate(newPos) == "")
            {
              moves.Add(newPos);
            } else if (piece[0] != Locate(newPos)[0]) {
              captures.Add(newPos);
              break;
            }
          }
          for (int i=(pos[1]+1); i<8; i++) //Up movement
          {
            int[] newPos = new int[] {pos[0],i};
            if (Locate(newPos) == "")
            {
              moves.Add(newPos);
            } else if (piece[0] != Locate(newPos)[0]) {
              captures.Add(newPos);
              break;
            }
          }
          for (int i=(pos[0]-1); i>=0; i--) //Left movement
          {
            int[] newPos = new int[] {i,pos[1]};
            if (Locate(newPos) == "")
            {
              moves.Add(newPos);
            } else if (piece[0] != Locate(newPos)[0]) {
              captures.Add(newPos);
              break;
            }
          }
          for (int i=(pos[1]-1); i>=0; i--) //Down movement
          {
            int[] newPos = new int[] {pos[0],i};
            if (Locate(newPos) == "")
            {
              moves.Add(newPos);
            } else if (piece[0] != Locate(newPos)[0]) {
              captures.Add(newPos);
              break;
            }
          }

          break;
      }
      return new List<int[]>[] {moves,captures};
    }

    static void Main(string[] args)
    {   
      Console.WriteLine("Enter piece position: ");
      string position = Console.ReadLine();
      Console.Write($"Piece: {Locate(toVector(position)).Substring(1)}\nCan move:");
      foreach (int[] i in checkMove(Locate(toVector(position)),toVector(position))[0])
      {
        Console.Write($" {toWords(i)}");
      }
      Console.WriteLine($"\nCan take:");
      foreach (int[] i in checkMove(Locate(toVector(position)),toVector(position))[1])
      {
        Console.WriteLine($"A {Locate(i).Substring(1)} at {toWords(i)}");
      }
    }

  }
}