﻿using System.Collections.Generic;
using Script.Managers;
using UnityEngine;

namespace Script.Pieces {
    public class Pawn : Piece {

        private DataManager _dataManager => DataManager.Instance;
        private bool hasMoved;

        public Pawn(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 1;
            IdPiece = TypeOfPiece * ColorMultiplier;
        }

        public override List<Vector2Int> AvailableMove() {
            var list = new List<Vector2Int>();
            
            // Simple Forward Move
            Vector2Int vector2Int = new Vector2Int(X + ColorMultiplier, Y);
            if (IsInBoard(vector2Int)) {
                Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                if (piece == null) list.Add(vector2Int);
            }

            //Double Forward Move
            if (!hasMoved) {
                Vector2Int forward = new Vector2Int(X + 2 * ColorMultiplier, Y);
                if (IsInBoard(forward)) {
                    Piece pieceForward = _dataManager.board[forward.x, forward.y];
                    Piece pieceFront = _dataManager.board[forward.x - 1, forward.y];
                    if (pieceForward == null && pieceFront == null) list.Add(forward);
                }
            }

            // Eat Right
            Vector2Int eatRight = new Vector2Int(X + ColorMultiplier, Y + 1);
            if (IsInBoard(eatRight)) {
                Piece rightTarget = _dataManager.board[eatRight.x, eatRight.y];
                if (rightTarget != null) {
                    if (rightTarget.ColorMultiplier != ColorMultiplier) {
                        list.Add(eatRight);
                    }
                }
            }

            // Eat Left
            Vector2Int eatleft = new Vector2Int(X + ColorMultiplier, Y - 1);
            if (IsInBoard(eatleft)) {
                Piece leftTarget = _dataManager.board[eatleft.x, eatleft.y];
                if (leftTarget != null) {
                    if (leftTarget.ColorMultiplier != ColorMultiplier) {
                        list.Add(eatleft);
                    }
                }
            }

            return list;
        }
    }
}