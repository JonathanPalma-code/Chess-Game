using board;

namespace chessGame
{
    class King : Piece
    {
        private ChessTurns ChessTurns;
        public King(Board board, Colour colour, ChessTurns chessTurns)
            : base(board, colour) 
        {
            ChessTurns = chessTurns;
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

        private bool RookTestForCastling(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Colour == Colour && piece.MovementsQuantity == 0;
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

            // Special play Castling
            if (MovementsQuantity == 0 && !ChessTurns.Xeque)
            {
                // #Small castling
                Position rookSmallCastling = new Position(PiecePosition.Row, PiecePosition.Column + 3);
                if (RookTestForCastling(rookSmallCastling))
                {
                    Position kingPosition1 = new Position(PiecePosition.Row, PiecePosition.Column + 1);
                    Position kingPosition2 = new Position(PiecePosition.Row, PiecePosition.Column + 2);
                    if (Board.Piece(kingPosition1) == null && Board.Piece(kingPosition2) == null)
                    {
                        boolboard[PiecePosition.Row, PiecePosition.Column + 2] = true;
                    }
                }

                // #Big castling
                Position rookBigCastling = new Position(PiecePosition.Row, PiecePosition.Column - 4);
                if (RookTestForCastling(rookBigCastling))
                {
                    Position kingPosition1 = new Position(PiecePosition.Row, PiecePosition.Column - 1);
                    Position kingPosition2 = new Position(PiecePosition.Row, PiecePosition.Column - 2);
                    Position kingPosition3 = new Position(PiecePosition.Row, PiecePosition.Column - 3);
                    if (Board.Piece(kingPosition1) == null && Board.Piece(kingPosition2) == null && Board.Piece(kingPosition3) == null)
                    {
                        boolboard[PiecePosition.Row, PiecePosition.Column - 2] = true;
                    }
                }
            }
            
            return boolboard;
        }
    }
}
