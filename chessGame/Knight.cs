using board;

namespace chessGame
{
    class Knight : Piece
    {
        public Knight(Board board, Colour colour)
            : base(board, colour) { }

        public override string ToString()
        {
            return "H";
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

            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column - 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row - 2, PiecePosition.Column - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row - 2, PiecePosition.Column + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column + 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column + 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row + 2, PiecePosition.Column + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row + 2, PiecePosition.Column - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column - 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }
            return boolboard;
        }
    }
}
