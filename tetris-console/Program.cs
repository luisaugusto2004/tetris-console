using Entities;

namespace tetris_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                PieceFactory.Create(Enums.PieceType.Z);
            } catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
