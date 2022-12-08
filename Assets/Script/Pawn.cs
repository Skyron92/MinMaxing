using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Pawn")]
public class Pawn : Piece {
    public void Awake() {
        TypeOfPiece = 1;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        var list = new List<Vector2Int>();
        var up = new Vector2Int(1 * ColorMultiplier, 0);
        list.Add(up);
        return list;
    }
}