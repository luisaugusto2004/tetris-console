using System;
using System.Threading;

namespace Entities {
    class Game {
        private Piece current;
        private Grid grid;

        private int OffsetX;
        private int OffsetY;

        public Game() {
            grid = new Grid(10, 20);
            current = Piece.RandomBlock();
            OffsetX = Console.WindowWidth / 2;
            OffsetY = Console.WindowHeight / 2;
        }


        public void Start() {

            while (true) {
                grid.Draw(current);

                Thread.Sleep(200);

                if (!grid.MoveDown(current)) {
                    grid.Place(current);
                    grid.ClearLine();
                    current = Piece.RandomBlock();
                }
                if (!grid.IsValidPosition(current)) {
                    Console.Clear();
                    Console.SetCursorPosition(OffsetX, OffsetY);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Game Over!");
                    return;
                }
                InputHandler();
            }
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
