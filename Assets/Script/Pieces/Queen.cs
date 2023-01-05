using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Queen : Piece {
    
        public Queen(int colorMultiplier) : base(colorMultiplier) { }

        public override List<Vector2Int> AvailableMove(Piece[,] board) {
            List<Vector2Int> list = new List<Vector2Int>();
            CanKillKingCounter = 0;
            Board = board;
            if (Coordinate.x < 0) return list;
            list.AddRange(YMoves);
            list.AddRange(RightMoves);
            list.AddRange(LeftMoves);
            list.AddRange(DiagonalMove);
            if (CanKillKingCounter == 0) canKillKing = false;
            return list;
        }
    
    }
}