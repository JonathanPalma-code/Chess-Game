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
        public bool GameOver { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Xeque { get; private set; }
        public Piece EnPassant { get; private set; }

        public ChessTurns()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerTurn = Colour.white;
            GameOver = false;
            Xeque = false;
            EnPassant = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.TakePiece(origin);
            piece.AddMovements();
            Piece pieceCaptured = Board.TakePiece(destination);
            Board.PutPiece(piece, destination);
            if (pieceCaptured != null)
            {
                Captured.Add(pieceCaptured);
            }

            // #Small castling
            if (piece is King && destination.Column == origin.Column + 2)
            {
                Position RookOriginPosition = new Position(origin.Row, origin.Column + 3);
                Position RookDestinationPosition = new Position(origin.Row, origin.Column + 1);
                Piece rook = Board.TakePiece(RookOriginPosition);
                rook.AddMovements();
                Board.PutPiece(rook, RookDestinationPosition);
            }

            // #Big castling
            if (piece is King && destination.Column == origin.Column - 2)
            {
                Position RookOriginPosition = new Position(origin.Row, origin.Column - 4);
                Position RookDestinationPosition = new Position(origin.Row, origin.Column - 1);
                Piece rook = Board.TakePiece(RookOriginPosition);
                rook.AddMovements();
                Board.PutPiece(rook, RookDestinationPosition);
            }

            // #En passant
            if (piece is Pawn)
            {
                if (origin.Column != destination.Column && pieceCaptured == null)
                {
                    Position pawnPosition;
                    if (piece.Colour == Colour.white)
                    {
                        pawnPosition = new Position(destination.Row + 1, destination.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(destination.Row - 1, destination.Column);
                    }
                    pieceCaptured = Board.TakePiece(pawnPosition);
                    Captured.Add(pieceCaptured);
                }
            }

            return pieceCaptured;
        }

        public void UnmakeMovement(Position origin, Position destination, Piece pieceCaptured)
        {
            Piece piece = Board.TakePiece(destination);
            piece.UnAddMovements();
            if(pieceCaptured != null)
            {
                Board.PutPiece(pieceCaptured, destination);
                Captured.Remove(pieceCaptured);
            }
            Board.PutPiece(piece, origin);

            // #Small castling
            if (piece is King && destination.Column == origin.Column + 2)
            {
                Position RookOriginPosition = new Position(origin.Row, origin.Column + 3);
                Position RookDestinationPosition = new Position(origin.Row, origin.Column + 1);
                Piece rook = Board.TakePiece(RookDestinationPosition);
                rook.UnAddMovements();
                Board.PutPiece(rook, RookOriginPosition);
            }

            // #Big castling
            if (piece is King && destination.Column == origin.Column - 2)
            {
                Position RookOriginPosition = new Position(origin.Row, origin.Column - 4);
                Position RookDestinationPosition = new Position(origin.Row, origin.Column - 1);
                Piece rook = Board.TakePiece(RookDestinationPosition);
                rook.UnAddMovements();
                Board.PutPiece(rook, RookOriginPosition);
            }

            // #En passant
            if (piece is Pawn)
            {
                if (origin.Column != destination.Column && pieceCaptured == EnPassant)
                {
                    Piece pawn = Board.TakePiece(destination);
                    Position pawnPosition; 
                    if (piece.Colour == Colour.white)
                    {
                        pawnPosition = new Position(3, destination.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(4, destination.Column);
                    }
                    Board.PutPiece(pawn, pawnPosition);
                }
            }
        }

        public void Play(Position origin, Position destination)
        {
            Piece pieceCaptured = MovePiece(origin, destination);
            if (IsInXeque(PlayerTurn))
            {
                UnmakeMovement(origin, destination, pieceCaptured);
                throw new BoardException("You cannot execute this movement, you are in Xeque.");
            }

            Piece piece = Board.Piece(destination);

            // #Promotion

            if (piece is Pawn)
            {
                if ((piece.Colour == Colour.white && destination.Row == 0) || (piece.Colour == Colour.black && destination.Row == 7)){
                    piece = Board.TakePiece(destination);
                    Pieces.Remove(piece);
                    Piece Queen = new Queen(Board, piece.Colour);
                    Board.PutPiece(Queen, destination);
                    Pieces.Add(Queen);
                }
            }

            if (IsInXeque(Opponent(PlayerTurn)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TestXequeMate(Opponent(PlayerTurn)))
            {
                GameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            // #En passant
            if (piece is Pawn && destination.Row == origin.Row -2 || destination.Row == origin.Row + 2)
            {
                EnPassant = piece;
            }
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
              if (!Board.Piece(origin).PossibleMoveTo(destination))
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

        private Colour Opponent(Colour colour)
        {
            if (colour == Colour.white)
            {
                return Colour.black;
            }
            else
            {
                return Colour.white;
            }
        }

        private Piece King(Colour colour)
        {
            foreach (Piece piece in PiecesInGame(colour))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        public bool IsInXeque(Colour colour)
        {
            Piece K = King(colour);
            if (K == null)
            {
                throw new BoardException($"There is no {colour} King in the game.");
            }
            foreach (Piece piece in PiecesInGame(Opponent(colour)))
            {
                bool[,] vs = piece.PossibleMovements();
                if (vs[K.PiecePosition.Row, K.PiecePosition.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestXequeMate(Colour colour)
        {
            if (!IsInXeque(colour))
            {
                return false;
            }
            foreach (Piece piece in PiecesInGame(colour))
            {
                bool[,] vs = piece.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (vs[i, j])
                        {
                            Position origin = piece.PiecePosition;
                            Position destination = new Position(i, j);
                            Piece pieceCaptured = MovePiece(origin, destination);
                            bool testXeque = IsInXeque(colour);
                            UnmakeMovement(origin, destination, pieceCaptured);
                            if (!testXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void PutPieces()
        {
            PutNewPiece('a', 1, new Rook(Board, Colour.white));
            PutNewPiece('b', 1, new Knight(Board, Colour.white));
            PutNewPiece('c', 1, new Bishop(Board, Colour.white));
            PutNewPiece('d', 1, new Queen(Board, Colour.white));
            PutNewPiece('e', 1, new King(Board, Colour.white, this));
            PutNewPiece('f', 1, new Bishop(Board, Colour.white));
            PutNewPiece('g', 1, new Knight(Board, Colour.white));
            PutNewPiece('h', 1, new Rook(Board, Colour.white));
            PutNewPiece('a', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('b', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('c', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('d', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('e', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('f', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('g', 2, new Pawn(Board, Colour.white, this));
            PutNewPiece('h', 2, new Pawn(Board, Colour.white, this));



            PutNewPiece('a', 8, new Rook(Board, Colour.black));
            PutNewPiece('b', 8, new Knight(Board, Colour.black));
            PutNewPiece('c', 8, new Bishop(Board, Colour.black));
            PutNewPiece('d', 8, new Queen(Board, Colour.black));
            PutNewPiece('e', 8, new King(Board, Colour.black, this));
            PutNewPiece('f', 8, new Bishop(Board, Colour.black));
            PutNewPiece('g', 8, new Knight(Board, Colour.black));
            PutNewPiece('h', 8, new Rook(Board, Colour.black));
            PutNewPiece('a', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('b', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('c', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('d', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('e', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('f', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('g', 7, new Pawn(Board, Colour.black, this));
            PutNewPiece('h', 7, new Pawn(Board, Colour.black, this));
        }
    }
}
