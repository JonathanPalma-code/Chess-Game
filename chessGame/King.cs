using board;

namespace chessGame
{
    class King : Piece
    {
        public King(Colour colour, Board board) 
            : base(colour, board)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
