using System.Collections.Generic;
using Script.Managers;
using UnityEngine;

namespace Script.Pieces {
    public class Pawn : Piece {
        private bool hasMoved;
        public Pawn(int colorMultiplier) : base(colorMultiplier) { }

        public override List<Vector2Int> AvailableMove(Piece[,] board) {
            var list = new List<Vector2Int>();
            Board = board;
            if (Coordinate.x < 0) return list;
            if (ColorMultiplier == 1) {
                if (Coordinate.x == 6) hasMoved = false;
                else {
                    hasMoved = true;
                }
            }
            if (ColorMultiplier == -1) {
                if (Coordinate.x == 1) hasMoved = false;
                else {
                    hasMoved = true;
                }
            }
            
            // Simple Forward Move
            Vector2Int vector2Int = new Vector2Int(X - ColorMultiplier, Y);
            if (IsInBoard(vector2Int)) {
                Piece piece = board[vector2Int.x, vector2Int.y];
                if (piece == null) list.Add(vector2Int);
            }

            //Double Forward Move
            if (!hasMoved) {
                Vector2Int forward = new Vector2Int(X - 2 * ColorMultiplier, Y);
                if (IsInBoard(forward)) {
                    Piece pieceForward =board[forward.x, forward.y];
                    Piece pieceFront = board[forward.x - 1, forward.y];
                    if (pieceForward == null && pieceFront == null) list.Add(forward);
                }
            }

            // Eat Right
            Vector2Int eatRight = new Vector2Int(X - ColorMultiplier, Y + 1);
            if (IsInBoard(eatRight)) {
                Piece rightTarget = board[eatRight.x, eatRight.y];
                if (rightTarget != null) {
                    if (rightTarget.ColorMultiplier != ColorMultiplier) {
                        list.Add(eatRight);
                    }
                }
            }

            // Eat Left
            Vector2Int eatleft = new Vector2Int(X - ColorMultiplier, Y - 1);
            if (IsInBoard(eatleft)) {
                Piece leftTarget = board[eatleft.x, eatleft.y];
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