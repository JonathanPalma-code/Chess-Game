using board;

namespace chessPieces
{
    class Tower : Piece
    {
        public Tower(Colour colour, Board board)
            : base(colour, board)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
