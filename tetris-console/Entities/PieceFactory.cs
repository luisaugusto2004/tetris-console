using Enums;
using System;


namespace Entities {
    class PieceFactory {
        public static Piece Create(PieceType type) {
            switch (type) {
                case PieceType.I:
                    return new Piece(new Point[] {
                        new Point(0, 1),
                        new Point(1, 1),
                        new Point(2, 1),
                        new Point(3, 1)
                    }, ConsoleColor.Green, type);

                case PieceType.O:
                    return new Piece(new Point[] {
                        new Point(0, 0),
                        new Point(1, 0),
                        new Point(0, 1),
                        new Point(1, 1)
                    }, ConsoleColor.Green, type);

                case PieceType.T:
                    return new Piece(new Point[] {
                        new Point(0, 1),
                        new Point(1, 0),
                        new Point(1, 1),
                        new Point(2, 1)
                    }, ConsoleColor.Green, type);

                case PieceType.S:
                    return new Piece(new Point[] {
                        new Point(0, 1),
                        new Point(1, 0),
                        new Point(1, 1),
                        new Point(2, 0)
                    }, ConsoleColor.Green, type);

                case PieceType.Z:
                    return new Piece(new Point[] {
                        new Point(0, 0),
                        new Point(1, 0),
                        new Point(1, 1),
                        new Point(2, 1)
                    }, ConsoleColor.Green, type);

                case PieceType.L:
                    return new Piece(new Point[] {
                        new Point(0, 1),
                        new Point(1, 1),
                        new Point(2, 1),
                        new Point(2, 2)
                    }, ConsoleColor.Green, type);
                case PieceType.J:
                    return new Piece(new Point[] {
                        new Point(0, 1),
                        new Point(1, 1),
                        new Point(2, 1),
                        new Point(2, 0)
                    }, ConsoleColor.Green, type);
                default:
                    throw new ArgumentException("Tentativa de criar uma peça com tipo desconhecido.");
            }
        }
    }
}
