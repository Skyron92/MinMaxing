﻿using System.Collections.Generic;
using Script.Managers;
using UnityEngine;

namespace Script.Pieces {
    public class King : Piece {
    
        private DataManager _dataManager => DataManager.Instance;
        
        public King(int colorMultiplier) : base(colorMultiplier) { }
    
        public void Awake() {
            TypeOfPiece = 150;
            IdPiece = TypeOfPiece * ColorMultiplier;
            if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
        }

        public override List<Vector2Int> AvailableMove() {
            List<Vector2Int> list = new List<Vector2Int>();
            
            // Forward Move
            Vector2Int forward = new Vector2Int(X + 1, Y);
            if (IsInBoard(forward)) {
                Piece pieceF = _dataManager.board[forward.x, forward.y];
                if (pieceF == null) list.Add(forward);
            }

            // Right Move
            Vector2Int right = new Vector2Int(X, Y + 1);
            if (IsInBoard(right)) {
                Piece pieceR = _dataManager.board[right.x, right.y];
                if (pieceR == null) list.Add(right);
            }

            // Left Move
            Vector2Int left = new Vector2Int(X, Y - 1);
            if (IsInBoard(left)) {
                Piece pieceL = _dataManager.board[left.x, left.y];
                if (pieceL == null) list.Add(left);
            }

            // Backward Move
            Vector2Int backward = new Vector2Int(X - 1, Y);
            if (IsInBoard(backward)) {
                Piece pieceB = _dataManager.board[backward.x, backward.y];
                if (pieceB == null) list.Add(backward);
            }

            // BottomLeft Move
            Vector2Int bottomLeft = new Vector2Int(X - 1, Y - 1);
            if (IsInBoard(bottomLeft)) {
                Piece pieceBL = _dataManager.board[bottomLeft.x, bottomLeft.y];
                if (pieceBL == null) list.Add(bottomLeft);
            }

            // BottomRight Move
            Vector2Int bottomRight = new Vector2Int(X - 1, Y + 1);
            if (IsInBoard(bottomRight)) {
                Piece pieceBR = _dataManager.board[bottomRight.x, bottomRight.y];
                if (pieceBR == null) list.Add(bottomRight);
            }

            // TopRight Move
            Vector2Int topRight = new Vector2Int(X + 1, Y + 1);
            if (IsInBoard(topRight)) {
                Piece pieceTR = _dataManager.board[topRight.x, topRight.y];
                if (pieceTR == null) list.Add(topRight);
            }

            // TopLeft Move
            Vector2Int topLeft = new Vector2Int(X + 1, Y - 1);
            if (IsInBoard(topLeft)) {
                Piece pieceTL = _dataManager.board[topLeft.x, topLeft.y];
                if (pieceTL == null) list.Add(topLeft);
            }

            return list;
        }
    
    }
}