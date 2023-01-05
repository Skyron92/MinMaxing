using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Rook : Piece {

        public Rook(int colorMultiplier) : base(colorMultiplier) { }

        public override List<Vector2Int> AvailableMove(Piece[,] board) {
            var list = new List<Vector2Int>();
            CanKillKingCounter = 0;
            Board = board;
            if (Coordinate.x < 0) return list;
            list.AddRange(YMoves);
            list.AddRange(RightMoves);
            list.AddRange(LeftMoves);
            if (CanKillKingCounter == 0) canKillKing = false;
            return list;
        }
    }
}