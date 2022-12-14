using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Queen : Piece {
    
        public Queen(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 10;
            IdPiece = TypeOfPiece * ColorMultiplier;
        }

        public override List<Vector2Int> AvailableMove() {
            List<Vector2Int> list = new List<Vector2Int>();
            list.AddRange(YMoves);
            list.AddRange(RightMoves);
            list.AddRange(LeftMoves);
            list.AddRange(DiagonalMove);
            return list;
        }
    
    }
}