using System.Collections.Generic;
using Script.Managers;
using UnityEngine;

namespace Script.Pieces {
    public class King : Piece {
        private DataManager _dataManager => DataManager.Instance;
        
        public King(int colorMultiplier) : base(colorMultiplier) { }

        public override List<Vector2Int> AvailableMove(Piece[,] board) {
            List<Vector2Int> list = new List<Vector2Int>();
            Board = board;
            if (Coordinate.x < 0) return list;
            CanKillKingCounter = 0;
            
            // Forward Move
            Vector2Int forward = new Vector2Int(X + 1, Y);
            if (IsInBoard(forward)) {
                Piece pieceF = board[forward.x, forward.y];
                if (pieceF == null) list.Add(forward);
                else {
                    if (pieceF.ColorMultiplier != ColorMultiplier) {
                        list.Add(forward);
                        if (pieceF.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // Right Move
            Vector2Int right = new Vector2Int(X, Y + 1);
            if (IsInBoard(right)) {
                Piece pieceR = board[right.x, right.y];
                if (pieceR == null) list.Add(right);
                else {
                    if (pieceR.ColorMultiplier != ColorMultiplier) {
                        list.Add(right);
                        if (pieceR.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // Left Move
            Vector2Int left = new Vector2Int(X, Y - 1);
            if (IsInBoard(left)) {
                Piece pieceL = board[left.x, left.y];
                if (pieceL == null) list.Add(left);
                else {
                    if (pieceL.ColorMultiplier != ColorMultiplier) {
                        list.Add(left);
                        if (pieceL.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // Backward Move
            Vector2Int backward = new Vector2Int(X - 1, Y);
            if (IsInBoard(backward)) {
                Piece pieceB = board[backward.x, backward.y];
                if (pieceB == null) list.Add(backward);
                else {
                    if (pieceB.ColorMultiplier != ColorMultiplier) {
                        list.Add(backward);
                        if (pieceB.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // BottomLeft Move
            Vector2Int bottomLeft = new Vector2Int(X - 1, Y - 1);
            if (IsInBoard(bottomLeft)) {
                Piece pieceBL = board[bottomLeft.x, bottomLeft.y];
                if (pieceBL == null) list.Add(bottomLeft);
                else {
                    if (pieceBL.ColorMultiplier != ColorMultiplier) {
                        list.Add(bottomLeft);
                        if (pieceBL.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // BottomRight Move
            Vector2Int bottomRight = new Vector2Int(X - 1, Y + 1);
            if (IsInBoard(bottomRight)) {
                Piece pieceBR = board[bottomRight.x, bottomRight.y];
                if (pieceBR == null) list.Add(bottomRight);
                else {
                    if (pieceBR.ColorMultiplier != ColorMultiplier) {
                        list.Add(bottomRight);
                        if (pieceBR.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // TopRight Move
            Vector2Int topRight = new Vector2Int(X + 1, Y + 1);
            if (IsInBoard(topRight)) {
                Piece pieceTR = board[topRight.x, topRight.y];
                if (pieceTR == null) list.Add(topRight);
                else {
                    if (pieceTR.ColorMultiplier != ColorMultiplier) {
                        list.Add(topRight);
                        if (pieceTR.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }

            // TopLeft Move
            Vector2Int topLeft = new Vector2Int(X + 1, Y - 1);
            if (IsInBoard(topLeft)) {
                Piece pieceTL = board[topLeft.x, topLeft.y];
                if (pieceTL == null) list.Add(topLeft);
                else {
                    if (pieceTL.ColorMultiplier != ColorMultiplier) {
                        list.Add(topLeft);
                        if (pieceTL.IdPiece == -IdPiece) {
                            canKillKing = true;
                            CanKillKingCounter++;
                        }
                    }
                }
            }
            if (CanKillKingCounter == 0) canKillKing = false;
            return list;
        }
    
    }
}