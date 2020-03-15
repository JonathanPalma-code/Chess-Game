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

                    Console.Write("\nOrigin: ");
                    Position origin = Cover.ReadPiecePosition().ToPosition();

                    bool[,] possiblePosition = chessTurns.Board.Piece(origin).PossibleMovements();

                    Console.Clear();
                    Cover.PrintBoard(chessTurns.Board, possiblePosition);

                    Console.Write("\nDestination: ");
                    Position destination = Cover.ReadPiecePosition().ToPosition();

                    chessTurns.MovePiece(origin, destination);
                }
                // Cover.PrintBoard(chessTurns.Board);
            }
            catch(BoardException e)
            {
                Console.WriteLine($"Operation Error: {e.Message}");
            }
        }
    }
}
