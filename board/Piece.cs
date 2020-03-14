namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        public Colour Colour { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Board Board { get; set; }

        public Piece(Colour colour, Board board)
        {
            Position = null;
            Colour = colour;
            Board = board;
            MovementsQuantity = 0;
        }

        public void AddMovements()
        {
            MovementsQuantity++;
        }
    }
}
