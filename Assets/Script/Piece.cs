using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public abstract class Piece : MonoBehaviour
{
    public int ColorMultiplier, TypeOfPiece, IdPiece;
    public Button button;
    public List<Vector2Int> AvailableTarget = new List<Vector2Int>();

    protected Piece(int colorMultiplier) {
        ColorMultiplier = colorMultiplier;
    }

    public abstract List<Vector2Int> AvailableMove();
}