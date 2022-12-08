﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Pawn")]
public class Pawn : Piece {

    private bool CanKillRight, CanKillLeft;
    public void Awake() {
        TypeOfPiece = 1;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        var list = new List<Vector2Int>();
        CanMove = !GetCase(X + 1 * ColorMultiplier, 0);
        CanKillRight = GetCase(X + 1 * ColorMultiplier, Y + 1);
        CanKillLeft = GetCase(X + 1 * ColorMultiplier, Y - 1);
        bool hasPiece;

        if (CanMove) {
            Vector2Int move = new Vector2Int(X + ColorMultiplier, Y);
            list.Add(move);
        }
        if (X == 6 && ColorMultiplier < 0 || X == 1 && ColorMultiplier > 0) {
            for (int i = 1; i < 2; i++) {
                hasPiece = DataManager.Echiquier[X + i * ColorMultiplier, Y].isTaken;
                if (!hasPiece) {
                    Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y);
                    list.Add(move);
                }
                else break;
            }
        }

        if (CanKillRight) {
            Vector2Int KillRight = new Vector2Int(X + ColorMultiplier, Y + 1);
            list.Add(KillRight);
        }
        if (CanKillLeft) {
            Vector2Int KillLeft = new Vector2Int(X + ColorMultiplier, Y - 1);
            list.Add(KillLeft);
        }

        return list;
    }
}