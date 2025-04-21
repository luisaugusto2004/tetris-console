using System;
using System.Threading;

namespace Entities {
    class Game {
        private Piece current;
        private Grid grid;

        public Game(Grid grid) {
            this.grid = grid;
            current = current.RandomBlock();
        }

        public void InputHandler() {
            while (Console.KeyAvailable) {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key) {
                    case ConsoleKey.LeftArrow:
                        grid.MoveLeft(current);
                        break;
                    case ConsoleKey.RightArrow:
                        grid.MoveRight(current);
                        break;
                    case ConsoleKey.DownArrow:
                        grid.MoveDown(current);
                        break;
                    case ConsoleKey.UpArrow:
                        current.Rotate();
                        if (!grid.IsValidPosition(current)) {
                            current.Rotate();
                            current.Rotate();
                            current.Rotate();
                        }
                        break;
                }
            }
        }
    }
}
