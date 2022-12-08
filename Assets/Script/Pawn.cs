using System;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

[CreateAssetMenu(menuName = "Piece/Pawn")]
public class Pawn : Piece
{
    public void Awake() {
        TypeOfPiece = 1;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }

    public override List<Vector2Int> AvailableMove() {
        List<Vector2Int> list = new List<Vector2Int>();
        Vector2Int up = new Vector2Int(1 * ColorMultiplier,0);
        list.Add(up);
        return list;
    }

    public Pawn(int colorMultiplier) : base(colorMultiplier) { }
    
}