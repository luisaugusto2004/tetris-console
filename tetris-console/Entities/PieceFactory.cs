using Enums;
using System;


namespace Entities
{
    class PieceFactory
    {
        public static Piece Create(PieceType type) {
            switch (type) {
                default:
                    throw new ArgumentException("Tentativa de criar uma peça com tipo desconhecido.");
            }
        }
    }
}
