using board.exceptions;

namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece Piece (int row, int column)
        {
            return pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.Row, position.Column];
        }

        public bool IfThereIsAPiece(Position position)
        {
            ValidPosition(position);
            return Piece(position) != null;
        } 

        public void PutPiece(Piece newPiece, Position newPosition)
        {
            if (IfThereIsAPiece(newPosition))
            {
                throw new BoardException("The position is already occupied by a piece.");
            }
            pieces[newPosition.Row, newPosition.Column] = newPiece;
            newPiece.PiecePosition = newPosition;
        }

        public Piece TakePiece(Position position)
        {
            if(Piece(position) == null)
            {
                return null;
            }
            Piece newPiece = Piece(position);
            newPiece.PiecePosition = null;
            pieces[position.Row, position.Column] = null;
            return newPiece;
        }

        public bool IfValidPosition(Position position)
        {
            if(position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidPosition(Position position)
        {
            if (!IfValidPosition(position))
            {
                throw new BoardException("Position Invalid.");
            }
        }
    }
}
