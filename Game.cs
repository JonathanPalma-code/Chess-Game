using System;
using board;
using chessGame;
using board.exceptions;

namespace Chess
{
    class Game
    {
        static void Main(string[] args)
        {
            try
            {
                ChessTurns chessTurns = new ChessTurns();

                while (!chessTurns.EndOfTurn)
                {
                    Console.Clear();
                    Cover.PrintBoard(chessTurns.Board);

                    Console.WriteLine("\nOrigin: ");
                    Position origin = Cover.ReadPiecePosition().toPosition();
                    Console.WriteLine("Destination: ");
                    Position destination = Cover.ReadPiecePosition().toPosition();

                    chessTurns.MovePiece(origin, destination);
                }
                Cover.PrintBoard(chessTurns.Board);
            }
            catch(BoardException e)
            {
                Console.WriteLine($"Operation Error: {e.Message}");
            }
        }
    }
}
