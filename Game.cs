using System;
using board;
using chessPieces;
using board.exceptions;

namespace Chess
{
    class Game
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new King(Colour.black, board), new Position(0, 0));
                board.PutPiece(new Rook(Colour.white, board), new Position(1, 9));
                board.PutPiece(new Rook(Colour.black, board), new Position(1, 0));

                Cover.PrintBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine($"Operation Error: {e.Message}");
            }
        }
    }
}
