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
        private bool isWhite = true, isMaximizing = true, gameOver;
        private int _score;
        public int Depth;
        private int teamMultiplier;
        private Piece[,] MyNode = new Piece[8, 8];
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
                if (team == Team.White) {teamMultiplier = 1;}
            }
        }

        private void Update() {
            CurrentTurn.image.color = isWhite ? Color.white : Color.black;
            Text.color = isWhite ? Color.black : Color.white;
            Test();
        }

        private void Test() {
            if (Input.GetButtonDown("Fire1")) {
                Debug.Log(MiniMax(_dataManager.board, 1));
            }
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
        
        private Piece[,] TheoricMove(Piece[,] board, Piece piece, Vector2Int vector2Int) {
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;
            
            Piece target = board[vector2Int.x, vector2Int.y];
            if(target != null) Kill(target);
            board[vector2Int.x, vector2Int.y] = piece;
            board[i, j] = null;
            return board;
        }

        private Piece[,] CancelMove(Piece[,] board, Piece piece, Vector2Int vector2Int, bool wasATargetHere, Piece cible) {
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;
            board[vector2Int.x, vector2Int.y] = piece;
            if (wasATargetHere && cible != null) board[i, j] = cible;
            else {
                board[i, j] = null;
            }
            return board;
        }

      /*  private void Minimax(Piece[,] board, int depth, Team team) {
            if (gameOver || depth < 0) return;
            Piece[,] move = new Piece[8,8];
            Piece[,] bestMove = new Piece[8,8];
            foreach (var list in GetNodes(board, depth)) {
                foreach (var plateau in list) {
                    EvaluateBoard(plateau);
                    if (isMaximizing) {
                        int maxEval;
                    }
                }
            }
        }*/

      private void ChooseTheBestMove(Piece [,] board) {
          int bestValue;
          if (isYourTurn) bestValue = MiniMax(board, 1);

      }
      
      private int MiniMax(Piece[,] board, int depth) {
          int value = 0;
          List<List<Piece[,]>> Tree = GetNodes(board, depth);
          for (int i = depth - 1; i < Tree.Count; i++) {
              if (isMaximizing) {
                  value = -50000;
                  for (int j = 0; j < Tree[i].Count; j++) {
                      int index = EvaluateBoard(Tree[i][j]);
                      if (index > value) {
                          value = index;
                      }
                  }
                  depth--;
                  isMaximizing = !isMaximizing;
              }
              else {
                  value = +50000;
                  for (int j = 0; j < Tree[i].Count; j++) {
                      int index = EvaluateBoard(Tree[i][j]);
                      if (index < value) {
                          value = index;
                      }
                  }
                  depth--;
                  isMaximizing = !isMaximizing;
              }
          } 
          return value;
      }

        private List<List<Piece[,]>> GetNodes(in Piece[,] board, int depth) {
            List<List<Piece[,]>> Tree = new List<List<Piece[,]>>();
            if (depth > 0) {
                List<List<Piece[,]>> tree = new List<List<Piece[,]>>();
                List<Piece[,]> Actions = new List<Piece[,]>();
                foreach (Piece piece in board) {
                    if(piece == null) continue;
                    Vector2Int position = new Vector2Int(piece.Coordinate.x, piece.Coordinate.y);
                    List<Vector2Int> move = piece.AvailableMove();
                    foreach (Vector2Int vector2Int in move) {
                        bool wasATargetHere = false;
                        Piece cible = null;
                        if (board[vector2Int.x, vector2Int.y] != null) {
                            wasATargetHere = true;
                            cible = board[vector2Int.x, vector2Int.y];
                        }
                        
                        Piece[,] Node = new Piece[8,8];
                        Array.Copy(board, Node, 64);
                        Node = TheoricMove(Node, piece, vector2Int);
                        Actions.Add(Node);
                       // Node = CancelMove(board, piece, position, wasATargetHere, cible);
                    }
                }
                tree.Add(Actions);
                depth--;
                foreach (var possibilité in Actions) {
                    GetNodes(possibilité, depth);
                }
                Tree = tree;
            }
            return Tree;
        }

        private int EvaluateBoard(Piece[,] board) {
            int value = 0;
            foreach (var VARIABLE in board) {
                if (VARIABLE == null) continue;
                switch (team) {
                    case Team.White:
                        value += VARIABLE.IdPiece * 10;
                        value += VARIABLE.AvailableMove().Count * VARIABLE.ColorMultiplier;
                        break;
                    case Team.Black:
                        value -= VARIABLE.IdPiece * 10;
                        value -= VARIABLE.AvailableMove().Count * VARIABLE.ColorMultiplier;
                        break;
                }
            }
            return value;
        }

        /*private Vector2Int Evaluation(Piece[,] currentBoard, int depth) {
            Vector2Int BestMove = new Vector2Int();
            Vector2Int MyMove = new Vector2Int();
            int currentScore = _score;
            for (int i = depth; i >= 0; i--) {
                foreach (Piece piece in _dataManager.board) {
                    foreach (Vector2Int vector2Int in piece.AvailableMove()) {
                        Piece target = _dataManager.board[vector2Int.x, vector2Int.y];
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
        }*/

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