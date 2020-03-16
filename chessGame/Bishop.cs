using board;

namespace chessGame
{
    class Bishop : Piece
    {
        public Bishop(Board board, Colour colour)
            : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "B";
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

            // To go north east
            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Row - 1, position.Column - 1);
            }


            // To go south east
            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Row + 1, position.Column + 1);
            }

            // To go south west
            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Row + 1, position.Column - 1);
            }

            // To go north west
            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Row - 1, position.Column + 1);
            }

            return boolboard;
        }
    }
}
