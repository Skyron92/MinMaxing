using System.Collections.Generic;
using Script.Managers;
using UnityEngine;

namespace Script.Pieces {
    public class Knight : Piece {
        
        private DataManager _dataManager => DataManager.Instance;

        public Knight(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 3;
            IdPiece = TypeOfPiece * ColorMultiplier;
            if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
        }

        public override List<Vector2Int> AvailableMove() {
            List<Vector2Int> list = new List<Vector2Int>();
            
            // X1, Y2
            Vector2Int X1Y2 = new Vector2Int(X + 1, Y + 2);
            if (IsInBoard(X1Y2)) {
                Piece pieceX1Y2 = _dataManager.board[X1Y2.x, X1Y2.y];
                if (pieceX1Y2 != null) {
                    if (pieceX1Y2.ColorMultiplier != ColorMultiplier) list.Add(X1Y2);
                }
            }

            // X-1, Y2
            Vector2Int x1Y2 = new Vector2Int(X - 1, Y + 2);
            if (IsInBoard(x1Y2)) {
                Piece piecex1Y2 = _dataManager.board[x1Y2.x, x1Y2.y];
                if (piecex1Y2 != null) {
                    if (piecex1Y2.ColorMultiplier != ColorMultiplier) list.Add(x1Y2);
                }
            }

            // X1, Y-2
            Vector2Int X1y2 = new Vector2Int(X + 1, Y - 2);
            if (IsInBoard(X1y2)) {
                Piece pieceX1y2 = _dataManager.board[X1y2.x, X1y2.y];
                if (pieceX1y2 != null) {
                    if (pieceX1y2.ColorMultiplier != ColorMultiplier) list.Add(X1y2);
                }
            }

            // X-1, Y-2
            Vector2Int x1y2 = new Vector2Int(X - 1, Y - 2);
            if (IsInBoard(x1y2)) {
                Piece piecex1y2 = _dataManager.board[x1y2.x, x1y2.y];
                if (piecex1y2 != null) {
                    if (piecex1y2.ColorMultiplier != ColorMultiplier) list.Add(x1y2);
                }
            }

            // X2, Y1
            Vector2Int X2Y1 = new Vector2Int(X + 2, Y + 1);
            if (IsInBoard(X2Y1)) {
                Piece pieceX2Y1 = _dataManager.board[X2Y1.x, X2Y1.y];
                if (pieceX2Y1 != null) {
                    if (pieceX2Y1.ColorMultiplier != ColorMultiplier) list.Add(X2Y1);
                }
            }

            // X2, Y-1
            Vector2Int X2y1 = new Vector2Int(X + 2, Y - 1);
            if (IsInBoard(X2y1)) {
                Piece pieceX2y1 = _dataManager.board[X2y1.x, X2y1.y];
                if (pieceX2y1 != null) {
                    if (pieceX2y1.ColorMultiplier != ColorMultiplier) list.Add(X2y1);
                }
            }

            // X-2, Y-1
            Vector2Int x2y1 = new Vector2Int(X - 2, Y - 1);
            if (IsInBoard(x2y1)) {
                Piece piecex2y1 = _dataManager.board[x2y1.x, x2y1.y];
                if (piecex2y1 != null) {
                    if (piecex2y1.ColorMultiplier != ColorMultiplier) list.Add(x2y1);
                }
            }

            // X-2, Y1
            Vector2Int x2Y1 = new Vector2Int(X - 2, Y + 1);
            if (IsInBoard(x2Y1)) {
                Piece piecex2Y1 = _dataManager.board[x2Y1.x, x2Y1.y];
                if (piecex2Y1 != null) {
                    if (piecex2Y1.ColorMultiplier != ColorMultiplier) list.Add(x2Y1);
                }
            }

            return list;
        }
    }
}