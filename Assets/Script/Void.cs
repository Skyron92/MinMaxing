using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Void")]
public class Void : Piece {
    public override List<Vector2Int> AvailableMove() {
        throw new System.NotImplementedException();
    }

    public void Awake() {
        TypeOfPiece = 0;
        IdPiece = 0;
        ColorMultiplier = 0;
    }
}