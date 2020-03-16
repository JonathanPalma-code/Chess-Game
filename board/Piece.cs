namespace board
{
    abstract class Piece
    {
        public Position PiecePosition { get; set; }
        public Colour Colour { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Board Board { get; set; }

        public Piece(Board board, Colour colour)
        {
            PiecePosition = null;
            Board = board;
            Colour = colour;
            MovementsQuantity = 0;
        }

        public void AddMovements()
        {
            MovementsQuantity++;
        }

        public void UnAddMovements()
        {
            MovementsQuantity--;
        }

        public bool PossibleMovementsAvailable()
        {
            bool[,] move = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (move[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
