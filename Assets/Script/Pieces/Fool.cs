using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Fool : Piece {
    
        public Fool(int colorMultiplier) : base(colorMultiplier) { }

        public override List<Vector2Int> AvailableMove(Piece[,] board) {
            Board = board;
            CanKillKingCounter = 0;
            List<Vector2Int> list = new List<Vector2Int>();
            if (Coordinate.x < 0) return list;
            list.AddRange(DiagonalMove);
            if (CanKillKingCounter == 0) canKillKing = false;
            return list;
        }
    
    }
}