using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Rook")]
public class Rook : Piece {
    public override List<Vector2Int> AvailableMove() {
        List<Vector2Int> list = new List<Vector2Int>();
        return list;
    }
    
    public void Awake() {
        TypeOfPiece = 2;
        IdPiece = TypeOfPiece * ColorMultiplier;
    }

    public Rook(int colorMultiplier) : base(colorMultiplier) {}
}