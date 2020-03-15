using board;

namespace chessGame
{
    class King : Piece
    {
        public King(Board board, Colour colour)
            : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "K";
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
            if(Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go north east
            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go east
            position.DefineValues(PiecePosition.Row , PiecePosition.Column + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go south east
            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go south
            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go south west
            position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go west
            position.DefineValues(PiecePosition.Row, PiecePosition.Column - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }

            // To go north west
            position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Row, position.Column] = true;
            }
            return boolboard;
        }
    }
}
