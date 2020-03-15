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

        public abstract bool[,] PossibleMovements();
    }
}
