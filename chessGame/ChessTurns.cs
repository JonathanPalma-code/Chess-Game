using board;
using board.exceptions;
using System.Collections.Generic;

namespace chessGame
{
    class ChessTurns
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Colour PlayerTurn { get; private set; }
        public bool EndOfTurn { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessTurns()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerTurn = Colour.white;
            EndOfTurn = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.TakePiece(origin);
            piece.AddMovements();
            Piece pieceCaptured = Board.TakePiece(destination);
            Board.PutPiece(piece, destination);
            if (pieceCaptured != null)
            {
                Captured.Add(pieceCaptured);
            }
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

        public HashSet<Piece> PiecesCaptured(Colour colour)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece model in Captured)
            {
                if (model.Colour == colour)
                {
                    pieces.Add(model);
                }
            }
            return pieces;
        }

        public HashSet<Piece> PiecesInGame(Colour colour)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece model in Pieces)
            {
                if (model.Colour == colour)
                {
                    pieces.Add(model);
                }
            }
            pieces.ExceptWith(PiecesCaptured(colour));
            return pieces;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Rook(Board, Colour.white));
            PutNewPiece('c', 2, new Rook(Board, Colour.white));
            PutNewPiece('d', 1, new King(Board, Colour.white));
            PutNewPiece('d', 2, new Rook(Board, Colour.white));
            PutNewPiece('e', 1, new Rook(Board, Colour.white));
            PutNewPiece('e', 2, new Rook(Board, Colour.white));

            PutNewPiece('c', 7, new Rook(Board, Colour.black));
            PutNewPiece('c', 8, new Rook(Board, Colour.black));
            PutNewPiece('d', 8, new King(Board, Colour.black));
            PutNewPiece('d', 7, new Rook(Board, Colour.black));
            PutNewPiece('e', 7, new Rook(Board, Colour.black));
            PutNewPiece('e', 8, new Rook(Board, Colour.black));
        }
    }
}
