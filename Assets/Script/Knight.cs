using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Knight")]
public class Knight : Piece {
    public void Awake() {
        TypeOfPiece = 3;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        List<Vector2Int> list = new List<Vector2Int>();
        bool hasPiece;
        if (!GetCase(X + 2 * ColorMultiplier, Y + ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X + 2 * ColorMultiplier, Y + ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X + 2 * ColorMultiplier, Y - ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X + 2 * ColorMultiplier, Y - ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X - 2 * ColorMultiplier, Y - ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X - 2 * ColorMultiplier, Y - ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X - 2 * ColorMultiplier, Y + ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X - 2 * ColorMultiplier, Y + ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X + ColorMultiplier, Y + 2 * ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X + ColorMultiplier, Y + 2 * ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X - ColorMultiplier, Y + 2 * ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X - ColorMultiplier, Y + 2 * ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X + ColorMultiplier, Y - 2 * ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X + ColorMultiplier, Y - 2 * ColorMultiplier);
            list.Add(move);
        }
        if (!GetCase(X - ColorMultiplier, Y - 2 * ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X - ColorMultiplier, Y - 2 * ColorMultiplier);
            list.Add(move);
        }

        return list;
    }
}