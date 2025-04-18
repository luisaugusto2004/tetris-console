using Entities;

namespace tetris_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                PieceFactory.Create(Enums.PieceType.I);
            } catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
