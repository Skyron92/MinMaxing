using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Rook : Piece {

        public Rook(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 5;
            IdPiece = TypeOfPiece * ColorMultiplier;
        }

        public override List<Vector2Int> AvailableMove() {
            var list = new List<Vector2Int>();
            list.AddRange(YMoves);
            list.AddRange(RightMoves);
            list.AddRange(LeftMoves);
            return list;
        }


    }
}