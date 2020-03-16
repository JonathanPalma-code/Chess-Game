using System;
using board;
using chessGame;
using System.Collections.Generic;

namespace Chess
{
    class Cover
    {
        public static void PrintGame(ChessTurns chessTurns)
        {
            PrintBoard(chessTurns.Board);
            PrintCapturedPieces(chessTurns);
            Console.WriteLine($"\n\nTurn: {chessTurns.Turn}");
            if (!chessTurns.GameOver)
            {
                Console.WriteLine($"{chessTurns.PlayerTurn} Player's turn...");
                if (chessTurns.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("******** XEQUEMATE! ********");
                Console.WriteLine($"And the Winner is {chessTurns.PlayerTurn}!! ");
            }
            
        }

        public static void PrintCapturedPieces(ChessTurns chessTurns)
        {
            Console.WriteLine("\nPieces captured: ");
            Console.Write("Whites: ");
            PrintList(chessTurns.PiecesCaptured(Colour.white));
            Console.Write("\nBlacks: ");
            ConsoleColor colour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintList(chessTurns.PiecesCaptured(Colour.black));
            Console.ForegroundColor = colour;
        }

        public static void PrintList(HashSet<Piece> list)
        {
            Console.Write("[");
            foreach (Piece piece in list)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {
            for(int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePosition)
        {
            ConsoleColor originalShade = Console.BackgroundColor;
            ConsoleColor changedShade = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possiblePosition[i, j])
                    {
                        Console.BackgroundColor = changedShade;
                    }
                    else
                    {
                        Console.BackgroundColor = originalShade;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalShade;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalShade;
        }

        public static ChessPosition ReadPiecePosition()
        {
            string command = Console.ReadLine();
            char column = command[0];
            int row = int.Parse(command[1] + "");
            return new ChessPosition(column, row);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Colour == Colour.white)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }
    }
}
