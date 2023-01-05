using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Queen : Piece {
    
        public Queen(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 10;
            IdPiece = TypeOfPiece * ColorMultiplier;
        }

        public override List<Vector2Int> AvailableMove(Piece[,] board) {
            List<Vector2Int> list = new List<Vector2Int>();
            Board = board;
            if (Coordinate.x < 0) return list;
            list.AddRange(YMoves);
            list.AddRange(RightMoves);
            list.AddRange(LeftMoves);
            list.AddRange(DiagonalMove);
            MoveCount = list.Count;
            return list;
        }
    
    }
}