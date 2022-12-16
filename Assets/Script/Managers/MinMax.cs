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
            }
            Debug.Log(_myPiece);
            
        }

        private void Update() {
            CurrentTurn.image.color = isWhite ? Color.white : Color.black;
            Text.color = isWhite ? Color.black : Color.white;
        }

        private void Move(Piece piece, Vector2Int vector2Int) {
            if (!isYourTurn) return;
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;

            _dataManager.board[i, j] = null;
            Piece target = _dataManager.board[vector2Int.x, vector2Int.y];
            if(target != null) Kill(target);
            target = piece;
            Opponent.isYourTurn = isYourTurn;
            isYourTurn = !isYourTurn;
            isWhite = !isWhite;
        }

        private int Evaluation(Piece[,] currentBoard) {
            int value = 0;
            foreach (Piece piece in currentBoard) {
                if (team == Team.White) value += piece.IdPiece;
                if (team == Team.Black) value -= piece.IdPiece;
            }
            return value;
        }

        private void Kill(Piece piece) {
            if (team == Team.White) _score += piece.IdPiece;
            if (team == Team.Black) _score -= piece.IdPiece;
            _dataManager.board[piece.Coordinate.x, piece.Coordinate.y] = null;
        }
    }
}