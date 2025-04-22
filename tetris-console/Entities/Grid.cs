using Entities;
using System;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace Entities {
    class Grid {
        private readonly int width, height;
        private readonly ConsoleColor[,] grid;
        private readonly int gridOffsetX, gridOffsetY;

        private Game game;

        public Grid(int width, int height, Game game) {
            this.width = width;
            this.height = height;

            gridOffsetX = (Console.WindowWidth - (width * 2)) / 2;
            gridOffsetY = (Console.WindowHeight - height) / 2;

            grid = new ConsoleColor[height, width];
            this.game = game;
        }

        public bool IsValidPosition(Piece piece) {
            foreach (var p in piece.GetBlocks()) {
                if (p.X < 0 || p.X >= width || p.Y < 0 || p.Y >= height) {
                    return false;
                } else if (grid[p.Y, p.X] != ConsoleColor.Black) {
                    return false;
                }
            }
            return true;
        }

        public void MoveLeft(Piece piece) {
            piece.Move(-1, 0);
            if (!IsValidPosition(piece))
                piece.Move(1, 0);
        }

        public void MoveRight(Piece piece) {
            piece.Move(1, 0);
            if (!IsValidPosition(piece))
                piece.Move(-1, 0);
        }

        public bool MoveDown(Piece piece) {
            piece.Move(0, 1);
            if (!IsValidPosition(piece)) {
                piece.Move(0, -1);
                return false;
            }
            return true;
        }

        public void Place(Piece piece) {
            foreach (var p in piece.GetBlocks())
                grid[p.Y, p.X] = piece.color;
        }

        public void ClearLine() {
            int linesCleared = 0;

            for (int y = height - 1; y >= 0 && linesCleared < 4; y--) {
                bool full = true;
                for (int x = 0; x < width; x++) {
                    if (grid[y, x] == ConsoleColor.Black) {
                        full = false;
                        break;
                    }
                }
                if (full) {
                    for (int row = y; row > 0; row--)
                        for (int col = 0; col < width; col++)
                            grid[row, col] = grid[row - 1, col];

                    for (int col = 0; col < width; col++)
                        grid[0, col] = ConsoleColor.Black;

                    y++;
                    linesCleared++;
                }
            }
        }

        public void Draw(Piece piece) {
            Console.Clear();
            DrawNext(game.NextOnes);

            for (int y = 0; y < height; y++) {
                for (int x = -1; x <= width; x++) {
                    Console.SetCursorPosition(gridOffsetX + x * 2, gridOffsetY + y);
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (x == -1)
                        Console.Write("<!");
                    else if (x == width)
                        Console.WriteLine("!>");
                    else
                        Console.Write(grid[y, x] == ConsoleColor.Black ? "." : "[]");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(gridOffsetX - 2, Console.CursorTop);
            Console.Write("<!");
            for (int i = 0; i < width; i++) {
                Console.Write("==");
            }
            Console.WriteLine("!>");

            DrawPiece(piece);
        }

        public void DrawPiece(Piece piece) {
            foreach (var p in piece.GetBlocks()) {
                if (p.Y >= 0) {
                    Console.SetCursorPosition(gridOffsetX + p.X * 2, gridOffsetY + p.Y);
                    Console.ForegroundColor = piece.color;
                    Console.Write("[]");
                }
            }
        }

        public void DrawNext(Queue<Piece> nextOnes) {
            int nextX = gridOffsetX - 15;
            int nextY = gridOffsetY + 2;
            Console.SetCursorPosition(nextX, nextY - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Próximas: ");

            nextX = gridOffsetX - 20;
            nextY = gridOffsetY + 3;

            foreach (var p in nextOnes) {
                foreach (var i in p.GetBlocks()) {
                    Console.SetCursorPosition(nextX + i.X * 2, nextY + i.Y);
                    Console.ForegroundColor = p.color;
                    Console.Write("[]");
                }
                nextY += 3;
            }

            Console.ResetColor();
        }
    }
}
