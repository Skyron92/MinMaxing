using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Queen : Piece
{
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }
    public void Awake() {
        TypeOfPiece = 5;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }
    public Queen(int colorMultiplier) : base(colorMultiplier)
    {
    }
}