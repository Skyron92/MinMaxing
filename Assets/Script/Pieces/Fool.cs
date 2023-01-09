using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Fool : Piece {
    
        public Fool(int colorMultiplier) : base(colorMultiplier) { }

        public override IEnumerable<Vector2Int> AvailableMove(Piece[,] board) {
            Board = board;
            List<Vector2Int> list = new List<Vector2Int>();
            if (Coordinate.x < 0) return list;
            list.AddRange(DiagonalMove);
            return list;
        }
    
    }
}