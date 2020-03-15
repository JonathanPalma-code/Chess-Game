using board;

namespace chessGame
{
    class ChessTurns
    {
        public Board Board { get; private set; }
        private int Turn;
        private Colour ActualPlayer;
        public bool EndOfTurn { get; private set; }

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
