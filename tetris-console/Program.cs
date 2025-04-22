using Entities;
using Enums;
using Entities;

namespace tetris_console {
    internal class Program {
        static void Main(string[] args) {

            try {
                Console.Title = "Tetris";
                Console.CursorVisible = false;
                Game game = new Game();
                game.Start();
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
