﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/King")]
public class King : Piece {
    public void Awake() {
        TypeOfPiece = 6;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        throw new NotImplementedException();
    }
}