using board;

namespace chessGame
{
    class Pawn : Piece
    {
        public Pawn(Board board, Colour colour)
            : base(board, colour) { }

        public override string ToString()
        {
            return "P";
        }

        private bool SpotEnemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Colour != Colour;
        }

        private bool IsFree(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] boolboard = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Colour == Colour.white)
            {
                position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column);
                if (Board.IfValidPosition(position) && IsFree(position)){
                    boolboard[position.Row, position.Column] = true;
                }

                position.DefineValues(PiecePosition.Row - 2, PiecePosition.Column);
                Position position1 = new Position(PiecePosition.Row - 1, PiecePosition.Column);
                if (Board.IfValidPosition(position1) && IsFree(position1) && Board.IfValidPosition(position) && IsFree(position) && MovementsQuantity == 0)
                {
                    boolboard[position.Row, position.Column] = true;
                }

                position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column - 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Row, position.Column] = true;
                }

                position.DefineValues(PiecePosition.Row - 1, PiecePosition.Column + 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column);
                if (Board.IfValidPosition(position) && IsFree(position))
                {
                    boolboard[position.Row, position.Column] = true;
                }

                position.DefineValues(PiecePosition.Row + 2, PiecePosition.Column);
                Position position1 = new Position(PiecePosition.Row + 1, PiecePosition.Column);
                if (Board.IfValidPosition(position1) && IsFree(position1) && Board.IfValidPosition(position) && IsFree(position) && MovementsQuantity == 0)
                {
                    boolboard[position.Row, position.Column] = true;
                }

                position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column + 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Row, position.Column] = true;
                }

                position.DefineValues(PiecePosition.Row + 1, PiecePosition.Column - 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Row, position.Column] = true;
                }
            }

            return boolboard;
        }
    }
}
