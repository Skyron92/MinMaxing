﻿using System.Collections.Generic;
using UnityEngine;

namespace Script.Pieces {
    public class Pawn : Piece {

        private bool CanKillRight, CanKillLeft;

        public Pawn(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 1;
            IdPiece = TypeOfPiece * ColorMultiplier;
            if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
        }

        public override List<Vector2Int> AvailableMove() {
            var list = new List<Vector2Int>();
            
            return list;
        }

        public List<Vector2Int> Vector2Ints = new List<Vector2Int>();
        

    }
}