using System.Collections.Generic;
using Script.Pieces;
using UnityEngine;

namespace Script.Managers {
    public class MinMax : MonoBehaviour {
        [SerializeField] public Team team;
        private List<Piece> myPiece = new List<Piece>();
        public bool isYourTurn;
        private DataManager _dataManager => DataManager.Instance;

        public enum Team {
            White,
            Black
        }

        private void Awake() {
            isYourTurn = team == Team.White;
            foreach (Piece piece in _dataManager.board) {
                switch (piece.ColorMultiplier) {
                    case 1 when team == Team.White:
                    case -1 when team == Team.Black:
                        myPiece.Add(piece);
                        break;
                }
            }
        }

        private int Evaluation(Piece[,] currentBoard) {
            int value = 0;
            foreach (Piece piece in currentBoard) {
                if (team == Team.White) value += piece.IdPiece;
                if (team == Team.Black) value -= piece.IdPiece;
            }
            return value;
        }
    }
}