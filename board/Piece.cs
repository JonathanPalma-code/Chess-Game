namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        public Colour Colour { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Board Board { get; set; }

        public Piece(Position position, Colour colour, Board board)
        {
            Position = position;
            Colour = colour;
            Board = board;
            MovementsQuantity = 0;
        }
    }
}
