using Entities;
using Enums;
using Entities;

namespace tetris_console {
    internal class Program {
        static void Main(string[] args) {

            try {
                Grid grid = new Grid(10, 20);
                Piece piece = PieceFactory.Create(PieceType.Z);
                for (int x = 0; x < grid.Width; x++) {
                    grid.Color[18, x] = ConsoleColor.Blue;
                    grid.Color[19, x] = ConsoleColor.Red;
                }                
                grid.Draw(piece);
                Console.ReadLine();
                grid.ClearLine();
                grid.Draw(piece);

            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
