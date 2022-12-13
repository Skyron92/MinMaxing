using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class King : Piece {
    
        public King(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 150;
            IdPiece = TypeOfPiece * ColorMultiplier;
            if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
        }

        public override List<Vector2Int> AvailableMove() {
            List<Vector2Int> list = new List<Vector2Int>();

            return list;
        }
    
    }
}