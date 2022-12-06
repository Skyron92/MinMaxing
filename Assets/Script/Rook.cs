using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rook : Piece {
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }

    public Rook(int colorMultiplier) : base(colorMultiplier)
    {
    }
}