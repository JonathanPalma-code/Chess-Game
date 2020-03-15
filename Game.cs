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
                    try
                    {
                        Console.Clear();
                        Cover.PrintBoard(chessTurns.Board);
                        Console.WriteLine($"\nTurn: {chessTurns.Turn}");
                        Console.WriteLine($"Waiting for the {chessTurns.PlayerTurn} Player move...");

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
            }
            catch(BoardException e)
            {
                Console.WriteLine($"Operation Error: {e.Message}");
            }
        }
    }
}
