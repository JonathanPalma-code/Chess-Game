using board;

namespace chessGame
{
    class Pawn : Piece
    {
        private ChessTurns ChessTurns;
        public Pawn(Board board, Colour colour, ChessTurns chessTurns)
            : base(board, colour) 
        {
            ChessTurns = chessTurns;
        }

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

                // #En passant
                if (PiecePosition.Row == 3)
                {
                    Position left = new Position(PiecePosition.Row, PiecePosition.Column - 1);
                    if (Board.IfValidPosition(left) && SpotEnemy(left) && Board.Piece(left) == ChessTurns.EnPassant)
                    {
                        boolboard[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(PiecePosition.Row, PiecePosition.Column + 1);
                    if (Board.IfValidPosition(right) && SpotEnemy(right) && Board.Piece(right) == ChessTurns.EnPassant)
                    {
                        boolboard[right.Row - 1, right.Column] = true;
                    }
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

                // #En passant
                if (PiecePosition.Row == 4)
                {
                    Position left = new Position(PiecePosition.Row, PiecePosition.Column - 1);
                    if (Board.IfValidPosition(left) && SpotEnemy(left) && Board.Piece(left) == ChessTurns.EnPassant)
                    {
                        boolboard[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(PiecePosition.Row, PiecePosition.Column + 1);
                    if (Board.IfValidPosition(right) && SpotEnemy(right) && Board.Piece(right) == ChessTurns.EnPassant)
                    {
                        boolboard[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return boolboard;
        }
    }
}
