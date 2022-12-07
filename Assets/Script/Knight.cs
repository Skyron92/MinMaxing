
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Knight : Piece
{
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }
    public void Awake() {
        TypeOfPiece = 3;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }
    public Knight(int colorMultiplier) : base(colorMultiplier)
    {
    }
}