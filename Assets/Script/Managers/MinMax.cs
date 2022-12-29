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
        private List<Piece> _opponentPiece = new List<Piece>();
        public bool isYourTurn;
        public Button CurrentTurn;
        public static bool WhiteHasPlayed, BLackHasPlayed;
        public TextMeshProUGUI Text;
        private bool isWhite = true, isMaximizing = true, gameOver, isMaximizingNode, startTimer;
        private int _score;
        public int Depth;
        private int teamMultiplier;
        private Piece[,] MyNode = new Piece[8, 8];
        public static Piece[,] NewBoard = new Piece[8, 8];
        private DataManager _dataManager => DataManager.Instance;
        private Vector2Int BestMove = new Vector2Int();
        private Piece BestPiece;
        private float timer;

        public enum Team {
            White,
            Black
        }

        private void Start() {
            isYourTurn = team == Team.White;
            BestMove = new Vector2Int();
            BestPiece = null;
            foreach (Piece piece in _dataManager.board) {
                if(piece == null) continue;
                switch (piece.ColorMultiplier) {
                    case 1 when team == Team.White:
                    case -1 when team == Team.Black:
                        _myPiece.Add(piece);
                        break;
                }
                switch (piece.ColorMultiplier) {
                    case -1 when team == Team.White:
                    case 1 when team == Team.Black:
                        _opponentPiece.Add(piece);
                        break;
                }
                if (team == Team.Black) teamMultiplier = -1;
                if (team == Team.White) {teamMultiplier = 1;}
            }
        }

        private void Update() {
            CurrentTurn.image.color = isWhite ? Color.white : Color.black;
            Text.color = isWhite ? Color.black : Color.white;
            startTimer = isYourTurn;
            if (startTimer) timer += Time.deltaTime;
            if (timer >= 2f) {
                Play();
                startTimer = false;
                timer = 0;
            }
        }

        /*private void Test() {
            if (Input.GetButtonDown("Fire1")) {
                Play();
            }
        }*/
        
        private void Play() {
            WhiteHasPlayed = false;
            BLackHasPlayed = false;
            MiniMax(_dataManager.board, 2);
                NewBoard = Move(_dataManager.board, BestPiece, BestMove);
                if (team == Team.White) WhiteHasPlayed = true;
                if (team == Team.Black) BLackHasPlayed = true;
        }

        
        private Piece[,] Move(Piece[,] board, Piece piece, Vector2Int vector2Int) {
            Piece[,] newBoard = new Piece[8, 8];
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;
            
            Piece target = board[vector2Int.x, vector2Int.y];
            if(target != null) Kill(board, target);
            board[vector2Int.x, vector2Int.y] = piece;
            board[i, j] = null;
            newBoard = board;
            //_dataManager.DisplayPieces(board);
            Opponent.isYourTurn = isYourTurn;
            isYourTurn = !isYourTurn;
            isWhite = !isWhite;
            return newBoard;
        }
        
        private Piece[,] TheoricMove(Piece[,] board, Piece piece, Vector2Int vector2Int) {
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;
            
            Piece target = board[vector2Int.x, vector2Int.y];
            if (target != null) {
                if(target.ColorMultiplier != piece.ColorMultiplier) Kill(board, target);
            }
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

      /*private void ChooseTheBestMove(Piece [,] board) {
          Vector2Int bestMove;
          int index;
          if (isYourTurn) index = MiniMax(board, 1);

      }*/
      
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

      private List<List<Piece[,]>> GetNodes(Piece[,] board, int depth) {
          List<List<Piece[,]>> Tree = new List<List<Piece[,]>>();
          int maxValue = -99999;
          if (depth > 0) {
              List<List<Piece[,]>> tree = new List<List<Piece[,]>>();
              List<Piece[,]> Actions = new List<Piece[,]>();
              isMaximizingNode = depth % 2 != 0;
              if (isMaximizingNode) {
                  foreach (Piece piece in _myPiece) {
                      if(piece == null) continue;
                      Vector2Int position = new Vector2Int(piece.Coordinate.x, piece.Coordinate.y);
                      List<Vector2Int> move = piece.AvailableMove(board);
                      foreach (Vector2Int vector2Int in move) {
                          int value = 0;
                          bool wasATargetHere = false;
                          Piece cible = null;
                          if (board[vector2Int.x, vector2Int.y] != null) { 
                              wasATargetHere = true;
                              cible = board[vector2Int.x, vector2Int.y];
                          }
                          Piece[,] Node = new Piece[8,8];
                          Array.Copy(board, Node, 64);
                          Node = TheoricMove(Node, piece, vector2Int);
                          value = EvaluateBoard(Node);
                          if (piece.ColorMultiplier == teamMultiplier) {
                              if (value > maxValue) {
                                  maxValue = value;
                                  BestMove = vector2Int;
                                  BestPiece = piece;
                              }
                          }
                          Actions.Add(Node);
                      }
                  }
              }
              else {
                  foreach (Piece piece in _opponentPiece) {
                      if(piece == null) continue;
                      Vector2Int position = new Vector2Int(piece.Coordinate.x, piece.Coordinate.y);
                      List<Vector2Int> move = piece.AvailableMove(board);
                      foreach (Vector2Int vector2Int in move) {
                          int value = 0;
                          bool wasATargetHere = false;
                          Piece cible = null;
                          if (board[vector2Int.x, vector2Int.y] != null) { 
                              wasATargetHere = true;
                              cible = board[vector2Int.x, vector2Int.y];
                          }
                          Piece[,] Node = new Piece[8,8];
                          Array.Copy(board, Node, 64);
                          Node = TheoricMove(Node, piece, vector2Int);
                          value = EvaluateBoard(Node);
                          if (piece.ColorMultiplier == teamMultiplier) {
                              if (value > maxValue) {
                                  maxValue = value;
                                  BestMove = vector2Int;
                                  BestPiece = piece;
                              }
                          }
                          Actions.Add(Node);
                      }
                  }
              }
              
              /*foreach (Piece piece in board) {
                  if(piece == null) continue;
                  Vector2Int position = new Vector2Int(piece.Coordinate.x, piece.Coordinate.y);
                  List<Vector2Int> move = piece.AvailableMove(board);
                  foreach (Vector2Int vector2Int in move) {
                      int value = 0;
                      bool wasATargetHere = false;
                      Piece cible = null;
                      if (board[vector2Int.x, vector2Int.y] != null) { 
                          wasATargetHere = true;
                          cible = board[vector2Int.x, vector2Int.y];
                      }
                      Piece[,] Node = new Piece[8,8];
                      Array.Copy(board, Node, 64);
                      Node = TheoricMove(Node, piece, vector2Int);
                      value = EvaluateBoard(Node);
                      if (piece.ColorMultiplier == teamMultiplier) {
                          if (value > maxValue) {
                              maxValue = value;
                              BestMove = vector2Int;
                              BestPiece = piece;
                          }
                      }
                      Actions.Add(Node);
                  }
              }*/
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
                        value += VARIABLE.AvailableMove(board).Count * VARIABLE.ColorMultiplier;
                        break;
                    case Team.Black:
                        value -= VARIABLE.IdPiece * 10;
                        value -= VARIABLE.AvailableMove(board).Count * VARIABLE.ColorMultiplier;
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

        private void Kill(Piece[,] board, Piece piece) {
            if (team == Team.White) _score += piece.IdPiece;
            if (team == Team.Black) _score -= piece.IdPiece;
            if (_myPiece.Contains(piece)) _myPiece.Remove(piece);
            if (_opponentPiece.Contains(piece)) _opponentPiece.Remove(piece);
            board[piece.Coordinate.x, piece.Coordinate.y] = null;
        }
    }
}