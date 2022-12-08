using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Rook")]
public class Rook : Piece {
    public void Awake() {
        TypeOfPiece = 2;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        var list = new List<Vector2Int>();
        return list;
    }
}