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

                while (!chessTurns.GameOver)
                {
                    try
                    {
                        Console.Clear();
                        Cover.PrintGame(chessTurns);

                        Console.Write("\nOrigin: ");
                        Position origin = Cover.ReadPiecePosition().ToPosition();
                        chessTurns.OriginPositionValidation(origin);

                        bool[,] possiblePosition = chessTurns.Board.Piece(origin).PossibleMovements();

                        Console.Clear();
                        Cover.PrintBoard(chessTurns.Board, possiblePosition);

                        Console.Write("\nDestination: ");
                        Position destination = Cover.ReadPiecePosition().ToPosition();
                        chessTurns.DestinationPositionValidation(origin, destination);
                        chessTurns.Play(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Cover.PrintGame(chessTurns);
            }
            catch(BoardException e)
            {
                Console.WriteLine($"Operation Error: {e.Message}");
            }
        }
    }
}
