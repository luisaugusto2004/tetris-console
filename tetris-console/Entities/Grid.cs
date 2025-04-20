using Entities;
using System;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace Entities {
    class Grid {
        private readonly int width, height;
        private readonly ConsoleColor[,] grid;
        private readonly int gridOffsetX, gridOffsetY;

        public Grid(int width, int height) {
            this.width = width;
            this.height = height;

            gridOffsetX = (Console.WindowWidth - (width * 2)) / 2;
            gridOffsetY = (Console.WindowHeight - height) / 2;

            grid = new ConsoleColor[height, width];
        }

        public void Draw(Piece piece) {
            Console.Clear();

            for (int y = 0; y < height; y++) {
                for (int x = -1; x <= width; x++) {
                    Console.SetCursorPosition(gridOffsetX + x * 2, gridOffsetY + y);
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (x == -1)
                        Console.WriteLine("<!");
                    else if (x == width)
                        Console.WriteLine("!>");
                    else
                        Console.Write(grid[y, x] == ConsoleColor.Black ? "." : "[]");
                }

            }
            DrawPiece(piece);
            Console.ResetColor();
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
    }
}
