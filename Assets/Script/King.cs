using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class King : Piece
{
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }
    
    public void Awake() {
        TypeOfPiece = 6;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }

    public King(int colorMultiplier) : base(colorMultiplier)
    {
    }
}