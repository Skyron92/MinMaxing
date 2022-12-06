using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Pawn : Piece
{
    public void Awake()
    {
        button = GetComponent<Button>();
        TypeOfPiece = 1;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }

    public override List<Vector2Int> AvailableMove()
    {
        List<Vector2Int> list = new List<Vector2Int>();
       
        return list;
    }

    public Pawn(int colorMultiplier) : base(colorMultiplier) { }
    
}