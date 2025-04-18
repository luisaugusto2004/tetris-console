using Entities;

namespace tetris_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                
                Piece p = PieceFactory.Create(Enums.PieceType.I);
                Console.WriteLine(p);
                p.Rotate();
                Console.WriteLine(p);
                p.Rotate();
                Console.WriteLine(p);
                p.Rotate();
                Console.WriteLine(p);
                p.Rotate();
                Console.WriteLine(p);
            } catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
