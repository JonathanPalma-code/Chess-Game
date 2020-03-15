using board;
using board.exceptions;

namespace chessGame
{
    class ChessTurns
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Colour PlayerTurn { get; private set; }
        public bool EndOfTurn { get; private set; }

        public ChessTurns()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerTurn = Colour.white;
            EndOfTurn = false;
            PutPieces();
        }

        public void MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.TakePiece(origin);
            piece.AddMovements();
            Piece pieceCaptured = Board.TakePiece(destination);
            Board.PutPiece(piece, destination);
        }

        public void Play(Position origin, Position destination)
        {
            MovePiece(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void OriginPositionValidation(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in the position of origin chosen.");
            }
            if (PlayerTurn != Board.Piece(position).Colour)
            {
                throw new BoardException("The piece chosen it is not yours.");
            }
            if (!Board.Piece(position).PossibleMovementsAvailable())
            {
                throw new BoardException("There is no possible moviments from the piece chosen.");
            }
        }

        public void DestinationPositionValidation(Position origin, Position destination)
        {
              if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Position of destination invalid.");
            }
        }

        private void ChangePlayer()
        {
            if(PlayerTurn == Colour.white)
            {
                PlayerTurn = Colour.black;
            }
            else
            {
                PlayerTurn = Colour.white;
            }
        }

        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Colour.white), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.white), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new King(Board, Colour.white), new ChessPosition('d', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.white), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.white), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.white), new ChessPosition('e', 2).ToPosition());

            Board.PutPiece(new Rook(Board, Colour.black), new ChessPosition('c', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.black), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new King(Board, Colour.black), new ChessPosition('d', 8).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.black), new ChessPosition('d', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.black), new ChessPosition('e', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Colour.black), new ChessPosition('e', 8).ToPosition());
        }
    }
}
