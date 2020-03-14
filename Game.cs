using board;
using chessPieces;

namespace Chess
{
    class Game
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PutPiece(new King(Colour.black, board), new Position(0, 0));
            board.PutPiece(new Tower(Colour.white, board), new Position(1, 3));
            board.PutPiece(new Tower(Colour.black, board), new Position(7, 4));

            Cover.PrintBoard(board);
        }
    }
}
