using board;

namespace Chess
{
    class Game
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Cover.PrintBoard(board);
        }
    }
}
