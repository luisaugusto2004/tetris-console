using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    class Piece {
        public Point[] Shape { get; private set; }
        private Point position;
        public ConsoleColor color { get; private set; }
        public PieceType type { get; private set; }

        public Piece(Point[] shape, ConsoleColor color, PieceType type) {
            Shape = shape;
            this.color = color;
            this.type = type;
            position = new Point(3, 0);
        }

        public void Move(int dx, int dy) {
            position.X += dx;
            position.Y += dy;
        }

        public void Rotate() {
            Point[] aux = new Point[Shape.Length];

            for (int i = 0; i < Shape.Length; i++) {
                aux[i] = new Point(Shape[i].X - 1, Shape[i].Y - 1);
            }
            for (int i = 0; i < Shape.Length; i++) {
                Shape[i].X = -aux[i].Y + 1;
                Shape[i].Y = aux[i].X + 1;
            }
        }

        public IEnumerable<Point> GetBlocks() {
            foreach (var p in Shape) {
                yield return new Point(position.X + p.X, position.Y + p.Y);
            }
        }

        public static Piece RandomBlock() {
            Random rand = new Random();
            PieceType type = (PieceType)rand.Next(0, 7);
            return PieceFactory.Create(type);
        }
    }
}