using System;
using System.Collections.Generic;
using Script.Pieces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Managers {
    public class MinMax : MonoBehaviour {
        [SerializeField] public Team team;
        [SerializeField] public MinMax Opponent;
        private List<Piece> _myPiece = new List<Piece>();
        public bool isYourTurn;
        public Button CurrentTurn;
        public TextMeshProUGUI Text;
        private bool isWhite = true;
        private int _score;
        public int Depth;
        private int teamMultiplier;
        Piece[,] Node =new Piece[8,8];
        Piece[,] NextNode = new Piece[8,8];
        private DataManager _dataManager => DataManager.Instance;

        public enum Team {
            White,
            Black
        }

        private void Start() {
            isYourTurn = team == Team.White;
            foreach (Piece piece in _dataManager.board) {
                if(piece == null) continue;
                switch (piece.ColorMultiplier) {
                    case 1 when team == Team.White:
                    case -1 when team == Team.Black:
                        _myPiece.Add(piece);
                        break;
                }
                if (team == Team.Black) teamMultiplier = -1;
                if (team == Team.White) teamMultiplier = 1;
            }
        }

        private void Update() {
            CurrentTurn.image.color = isWhite ? Color.white : Color.black;
            Text.color = isWhite ? Color.black : Color.white;
        }

        
        private void Move(Piece[,] board, Piece piece, Vector2Int vector2Int) {
            if (!isYourTurn) return;
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;
            
            Piece target = _dataManager.board[vector2Int.x, vector2Int.y];
            if(target != null) Kill(target);
            target = piece;
            _dataManager.board[i, j] = null;
            _dataManager.DisplayPieces();
            Opponent.isYourTurn = isYourTurn;
            isYourTurn = !isYourTurn;
            isWhite = !isWhite;
        }

        private Vector2Int Evaluation(Piece[,] currentBoard, int depth) {
            Vector2Int BestMove = new Vector2Int();
            Vector2Int MyMove = new Vector2Int();
            int currentScore = _score;
            Node = _dataManager.board;
            for (int i = depth; i >= 0; i--) {
                foreach (Piece piece in Node) {
                    foreach (Vector2Int vector2Int in piece.AvailableMove()) {
                        Piece target = Node[vector2Int.x, vector2Int.y];
                        if (target == null) continue;
                        bool isWhitePiece = target.ColorMultiplier == 1;
                        switch (isWhitePiece) {
                            case true when team == Team.Black:
                            case false when team == Team.White:
                                Kill(target);
                                break;
                        }

                        currentScore += GetValue(vector2Int);
                        if (currentScore > _score) {
                            BestMove = vector2Int;
                        }

                        MyMove = BestMove;
                        currentScore = _score;
                    }
                }
            }
            return MyMove;
        }

        private int GetValue(Vector2Int vector2Int) {
            int value = 0;
            if (_dataManager.board[vector2Int.x, vector2Int.y] == null) return value;  
            Piece piece = _dataManager.board[vector2Int.x, vector2Int.y];
            value = GetTypeOfPiece(piece);
            return value;
        }

        private void Kill(Piece piece) {
            if (team == Team.White) _score += piece.IdPiece;
            if (team == Team.Black) _score -= piece.IdPiece;
            _dataManager.board[piece.Coordinate.x, piece.Coordinate.y] = null;
        }

        private int GetTypeOfPiece(Piece piece) {
            return piece.IdPiece;
        }
    }
}