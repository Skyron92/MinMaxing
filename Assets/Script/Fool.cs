using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Fool")]
public class Fool : Piece {
    public void Awake() {
        TypeOfPiece = 4;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        List<Vector2Int> list = new List<Vector2Int>();
        bool hasPiece;
        
        for (int i = 0; X + i < 8; i++) {
            hasPiece = DataManager.Echiquier[X + i * ColorMultiplier, Y + i * ColorMultiplier].isTaken;
            if (!hasPiece) {
                Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y + i * ColorMultiplier);
                list.Add(move);
            }
            else break;
        }
        for (int i = 8; X - i >= 0; i--) {
            hasPiece = DataManager.Echiquier[X - i * ColorMultiplier, Y - i * ColorMultiplier].isTaken;
            if (!hasPiece) {
                Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y - i * ColorMultiplier);
                list.Add(move);
            }
            else break;
        }

        for (int i = 0; X + i < 8; i++) {
            for (int j = 8; Y - j >= 0; j--) {
                hasPiece = DataManager.Echiquier[X + i * ColorMultiplier, Y - j * ColorMultiplier].isTaken;
                if (!hasPiece) {
                    Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y - j * ColorMultiplier);
                    list.Add(move);
                }
            }
        }
        for (int i = 8; X + i >= 0; i--) {
            for (int j = 0; Y - j < 8; j++) {
                hasPiece = DataManager.Echiquier[X - i * ColorMultiplier, Y + j * ColorMultiplier].isTaken;
                if (!hasPiece) {
                    Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y + j * ColorMultiplier);
                    list.Add(move);
                }
            }
        }

        return list;
    }
}