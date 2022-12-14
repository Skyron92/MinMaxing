using System.Collections.Generic;
using Script.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Pieces {
    public abstract class Piece {
        public int ColorMultiplier, TypeOfPiece, IdPiece;
        public Image sprite;

        private DataManager _dataManager => DataManager.Instance;

        private Vector2Int Coordinate {
            get {
                for (int i = 0; i < 8; i++) {
                    for (int j = 0; j < 8; j++) {
                        if (_dataManager.board[i, j] == this)
                            return new Vector2Int(i, j);
                    }
                }
                return -Vector2Int.one;
            }
        }

        protected int X => Coordinate.x;
        protected int Y => Coordinate.y;
        
        public List<Vector2Int> YMoves {
            get {
                // Right Move
                List<Vector2Int> vector2Ints = new List<Vector2Int>();
                for (int i = X + 1; i <= 7; i++) {
                    Vector2Int vector2Int = new Vector2Int(i, Y);
                    Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                    if (piece != null) {
                        if (piece.ColorMultiplier == ColorMultiplier) {
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                        break;
                    }
                    vector2Ints.Add(vector2Int);
                }
                // Left Move
                for (int i = X - 1; i >= 0; i--) {
                    Vector2Int vector2Int = new Vector2Int(i, Y);
                    Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                    if (piece != null) {
                        if (piece.ColorMultiplier == ColorMultiplier) {
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                        break;
                    }
                    vector2Ints.Add(vector2Int);
                }
                return vector2Ints;
            }
        }

        public List<Vector2Int> RightMoves {
            get {
                List<Vector2Int> vector2Ints = new List<Vector2Int>();
                
                // Right move
                for (int i = Y + 1; i <= 7; i++) {
                    Vector2Int vector2Int = new Vector2Int(X, i);
                    Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                    if (piece != null) {
                        if (piece.ColorMultiplier == ColorMultiplier) {
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                        break;
                    }
                    vector2Ints.Add(vector2Int);
                }
                return vector2Ints;
            }
        }

        public List<Vector2Int> LeftMoves {
            get {
                List<Vector2Int> vector2Ints = new List<Vector2Int>();
                // Left move
                for (int i = Y - 1; i >= 0; i--) {
                    Vector2Int vector2Int = new Vector2Int(X, i);
                    Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                    if (piece != null) {
                        if (piece.ColorMultiplier == ColorMultiplier) {
                            break;
                        }
                        vector2Ints.Add(vector2Int); 
                        break;
                    }
                    vector2Ints.Add(vector2Int);
                }

                return vector2Ints;
            }
        }

        public List<Vector2Int> DiagonalMove {
            get {
                List<Vector2Int> vector2Ints = new List<Vector2Int>();
                // BottomRight move
                for (int i = 1; X + i <= 7 && Y + i <= 7; i++) {
                    Vector2Int vector2Int = new Vector2Int(X + i, Y + i);
                        Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                        if (piece != null) {
                            if (piece.ColorMultiplier == ColorMultiplier) {
                                break;
                            }
                            vector2Ints.Add(vector2Int);
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                }
                // TopLeft move
                for (int i = 1; X + i <= 7 && Y - i >= 0; i++) {
                    Vector2Int vector2Int = new Vector2Int(X + i, Y - i);
                        Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                        if (piece != null) {
                            if (piece.ColorMultiplier == ColorMultiplier) {
                                break;
                            }
                            vector2Ints.Add(vector2Int);
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                }
                // BottomLeft move
                for (int i = 1; X - i >= 0 && Y + i <= 7; i++) {
                    Vector2Int vector2Int = new Vector2Int(X - i, Y + i);
                        Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                        if (piece != null) {
                            if (piece.ColorMultiplier == ColorMultiplier) {
                                break;
                            }
                            vector2Ints.Add(vector2Int);
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                    
                }
                // TopRight move
                for (int i = 1; X - i >= 0 && Y - i >= 0; i++) {
                    Vector2Int vector2Int = new Vector2Int(X - i, Y - i);
                        Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
                        if (piece != null) {
                            if (piece.ColorMultiplier == ColorMultiplier) {
                                break;
                            }
                            vector2Ints.Add(vector2Int);
                            break;
                        }
                        vector2Ints.Add(vector2Int);
                }
                return vector2Ints;
            }
        }

        protected Piece(int colorMultiplier) {
            ColorMultiplier = colorMultiplier;
        }

        public Piece GetPiece(Vector2Int vector2Int) {
            Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
            return piece;
        }

        public abstract List<Vector2Int> AvailableMove();
        

        private void OnDestroy() {
            _dataManager.Score -= IdPiece;
        }
        
        public bool IsInBoard(Vector2Int vector2Int) {
            return vector2Int.x >= 0 && vector2Int.x <= 7 && vector2Int.y >= 0 && vector2Int.y <= 7;
        }
    }
}