
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Knight : Piece
{
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }

    public Knight(int colorMultiplier) : base(colorMultiplier)
    {
    }
}