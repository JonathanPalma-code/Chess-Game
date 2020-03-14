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
            ChessPosition chessPosition = new ChessPosition('a', 1);
            Console.WriteLine(chessPosition);
            Console.WriteLine(chessPosition.toPosition());
        }
    }
}
