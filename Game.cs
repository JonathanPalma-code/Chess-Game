using System;
using Chess.board;

namespace Chess
{
    class Game
    {
        static void Main(string[] args)
        {
            Position position = new Position(3, 4); 

            Console.WriteLine($"Position: {position}");
        }
    }
}
