using Entities;
using Enums;
using Entities;

namespace tetris_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try {
                Grid grid = new Grid(10, 20);
                Piece piece = PieceFactory.Create(PieceType.J);
                grid.Draw(piece);
            } catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
