using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[CreateAssetMenu(menuName = "Piece/Fool")]
public class Fool : Piece
{
    public override List<Vector2Int> AvailableMove()
    {
        throw new System.NotImplementedException();
    }
    public void Awake() {
        TypeOfPiece = 4;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }
    public Fool(int colorMultiplier) : base(colorMultiplier)
    {
    }
}