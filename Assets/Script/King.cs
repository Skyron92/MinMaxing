using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class King : Piece
{
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }

    public King(int colorMultiplier) : base(colorMultiplier)
    {
    }
}