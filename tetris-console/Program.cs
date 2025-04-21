using Entities;
using Enums;
using Entities;

namespace tetris_console {
    internal class Program {
        static void Main(string[] args) {

            try {
                Grid grid = new Grid(10, 20);
                Piece piece = PieceFactory.Create(PieceType.J);
                piece.Rotate();
                grid.MoveDown(piece);
                grid.MoveRight(piece);
                grid.MoveRight(piece);
                grid.MoveRight(piece);
                grid.MoveRight(piece);
                grid.MoveRight(piece);
                grid.Draw(piece);
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
