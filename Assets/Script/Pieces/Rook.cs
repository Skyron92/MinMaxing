using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Rook : Piece {

        public Rook(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 5;
            IdPiece = TypeOfPiece * ColorMultiplier;
            if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
        }

        public override List<Vector2Int> AvailableMove() {
            var list = new List<Vector2Int>();
            list.AddRange(XMoves);
            list.AddRange(YMoves);
            return list;
        }


    }
}