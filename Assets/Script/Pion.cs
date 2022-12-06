using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Pion : Piece
{
    public void Awake()
    {
        button = GetComponent<Button>();
        TypeOfPiece = 1;
        if (button.image.color == Color.white) ColorMultiplier = 1;
        else ColorMultiplier = -1;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }

    public override List<Vector2Int> AvailableMove()
    {
        List<Vector2Int> list = new List<Vector2Int>();
        
        return list;
    }
}