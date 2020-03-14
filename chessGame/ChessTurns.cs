using System;
using board;

namespace chessGame
{
    class ChessTurns
    {
        public Board Board { get; private set; }
        private int Turn;
        private Colour ActualPlayer;
        public bool EndOfTurn { get; set; }

        public ChessTurns()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Colour.white;
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

        private void PutPieces()
        {
            Board.PutPiece(new King(Colour.black, Board), new ChessPosition('a', 1).toPosition());
            Board.PutPiece(new Rook(Colour.white, Board), new ChessPosition('b', 8).toPosition());
            Board.PutPiece(new Rook(Colour.black, Board), new ChessPosition('h', 8).toPosition());
        }
    }
}
