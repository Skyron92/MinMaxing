using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public abstract class Piece : ScriptableObject
{
    public int ColorMultiplier, TypeOfPiece, IdPiece;
    public Sprite sprite;
    public List<Vector2Int> AvailableTarget = new List<Vector2Int>();

    protected Piece(int colorMultiplier) {
        ColorMultiplier = colorMultiplier;
    }

    public abstract List<Vector2Int> AvailableMove();
}