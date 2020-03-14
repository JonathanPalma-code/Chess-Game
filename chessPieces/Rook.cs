using board;

namespace chessPieces
{
    class Rook : Piece
    {
        public Rook(Colour colour, Board board)
            : base(colour, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
