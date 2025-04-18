using Enums;
using System;
using System.Collections.Generic;

namespace Entities {
    class Piece {
        public Point[] Shape { get; private set; }
        public Point position { get; private set; }
        public ConsoleColor color { get; private set; }
        public PieceType type { get; private set; }

        public Piece(Point[] shape, ConsoleColor color, PieceType type) {
            Shape = shape;
            this.color = color;
            this.type = type;
            position = new Point(4, 0);
        }
    }
}