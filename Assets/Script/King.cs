using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/King")]
public class King : Piece {
    public void Awake() {
        TypeOfPiece = 150;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        List<Vector2Int> list = new List<Vector2Int>();

        if (!GetCase(X + ColorMultiplier, Y)) {
            Vector2Int move = new Vector2Int(X + ColorMultiplier, Y);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X + ColorMultiplier, Y)) {
                Vector2Int move = new Vector2Int(X + ColorMultiplier, Y);
                list.Add(move);
            }
        }
        if (!GetCase(X - ColorMultiplier, Y)) {
            Vector2Int move = new Vector2Int(X - ColorMultiplier, Y);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X - ColorMultiplier, Y)) {
                Vector2Int move = new Vector2Int(X - ColorMultiplier, Y);
                list.Add(move);
            }
        }
        if (!GetCase(X + ColorMultiplier, Y + ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X + ColorMultiplier, Y + ColorMultiplier);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X + ColorMultiplier, Y + ColorMultiplier)) {
                Vector2Int move = new Vector2Int(X + ColorMultiplier, Y + ColorMultiplier);
                list.Add(move);
            }
        }
        if (!GetCase(X - ColorMultiplier, Y - ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X - ColorMultiplier, Y - ColorMultiplier);
            list.Add(move);
        }else {
            if (!GetFactionCase(X - ColorMultiplier, Y - ColorMultiplier)) {
                Vector2Int move = new Vector2Int(X - ColorMultiplier, Y - ColorMultiplier);
                list.Add(move);
            }
        }
        
        if (!GetCase(X + ColorMultiplier, Y - ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X + ColorMultiplier, Y - ColorMultiplier);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X + ColorMultiplier, Y - ColorMultiplier)) {
                Vector2Int move = new Vector2Int(X + ColorMultiplier, Y - ColorMultiplier);
                list.Add(move);
            }
        }
        if (!GetCase(X - ColorMultiplier, Y + ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X - ColorMultiplier, Y + ColorMultiplier);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X - ColorMultiplier, Y + ColorMultiplier)) {
                Vector2Int move = new Vector2Int(X - ColorMultiplier, Y + ColorMultiplier);
                list.Add(move);
            }
        }
        if (!GetCase(X, Y - ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X, Y - ColorMultiplier);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X, Y - ColorMultiplier)) {
                Vector2Int move = new Vector2Int(X, Y - ColorMultiplier);
                list.Add(move);
            }
        }
        if (!GetCase(X, Y + ColorMultiplier)) {
            Vector2Int move = new Vector2Int(X, Y + ColorMultiplier);
            list.Add(move);
        }
        else {
            if (!GetFactionCase(X, Y + ColorMultiplier)) {
                Vector2Int move = new Vector2Int(X, Y + ColorMultiplier);
                list.Add(move);
            }
        }

        return list;
    }
}