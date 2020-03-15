using board;

namespace chessGame
{
    class Rook : Piece
    {
        public Rook(Board board, Colour colour)
            : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Colour != Colour;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] boolboard = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            // To go north
            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Row -= 1;
            }


            // To go east
            position.DefineValues(PiecePosition.Row, PiecePosition.Column + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Column += 1;
            }

            // To go south
            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Row += 1;
            }

            // To go west
            position.DefineValues(PiecePosition.Row, PiecePosition.Column - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Column -= 1;
            }

            return boolboard;
        }
    }
}
