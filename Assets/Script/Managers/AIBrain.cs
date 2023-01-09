using System;
using System.Collections.Generic;
using System.Diagnostics;
using Script.Pieces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


namespace Script.Managers {
    public class AIBrain : MonoBehaviour {
        [SerializeField] public int PlayerColorMultiplier;
        private List<Piece> _myPiece = new List<Piece>();
        [SerializeField] public AIBrain Opponent;
        private List<Piece> _opponentPiece = new List<Piece>();
        public bool isYourTurn;
        public Button CurrentTurn;
        public static bool WhiteHasPlayed, BLackHasPlayed;
        public TextMeshProUGUI Text;
        private bool isWhite = true, isMaximizing = true, gameOver, isMaximizingNode, startTimer;
        public int Depth;
        private bool check, checkmate;
        public static Piece[,] NewBoard = new Piece[8, 8]; 
        private DataManager _dataManager => DataManager.Instance;
        private float timer;
        public bool useAlphabêta;
        private Stopwatch _stopwatch = new Stopwatch();

        private int a = int.MinValue;
        private int b = int.MaxValue;

        private void Start() {
            isYourTurn = PlayerColorMultiplier == 1;
            foreach (Piece piece in _dataManager.board) {
                if (piece == null) continue;
                switch (piece.ColorMultiplier) {
                    case 1 when PlayerColorMultiplier == 1:
                        _myPiece.Add(piece);
                        break;
                    case -1 when PlayerColorMultiplier == -1:
                        _myPiece.Add(piece);
                        break;
                    case 1 when PlayerColorMultiplier == -1:
                        _opponentPiece.Add(piece);
                        break;
                    case -1 when PlayerColorMultiplier == 1:
                        _opponentPiece.Add(piece);
                        break;
                }
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

        private void Play() {
            _stopwatch.Start();
            WhiteHasPlayed = false;
            BLackHasPlayed = false;
            Think(_dataManager.board, PlayerColorMultiplier);
            if (PlayerColorMultiplier == 1) WhiteHasPlayed = true;
            if (PlayerColorMultiplier == -1) BLackHasPlayed = true;
            Opponent.isYourTurn = isYourTurn;
            isYourTurn = !isYourTurn;
            isWhite = !isWhite;
            Debug.Log(_stopwatch.Elapsed + " secondes");
            _stopwatch.Stop();
        }

        private Piece[,] TheoricMove(Piece[,] board, Piece piece, Vector2Int vector2Int) {
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;

            Piece target = board[vector2Int.x, vector2Int.y];
            if (target != null) TheoricKill(board, target);
            board[vector2Int.x, vector2Int.y] = piece;
            board[i, j] = null;
            return board;
        }
       
        private void TheoricKill(Piece[,] board, Piece piece) {
            board[piece.Coordinate.x, piece.Coordinate.y] = null;
        }

        private void Think(Piece[,] board, int colorMultiplier) {
            int oldValue = int.MinValue;
            Piece[,] bestBoard = new Piece[8,8];
            foreach (Piece[,] child in BoardChild(board, colorMultiplier)) {
                int newValue = 0;
                if(!useAlphabêta) newValue = MinMax(child, Depth, false, colorMultiplier);
                else {
                    newValue = Alphabeta(child, a, b, colorMultiplier, Depth, false);
                }
                if (newValue > oldValue) {
                    oldValue = newValue;
                    bestBoard = child;
                }
            }
            NewBoard = bestBoard;
        }

        private int MinMax(Piece[,] board, int depth, bool maximizingPlayer, int colorMultiplier) {
            int value;
            if (depth == 0 || IsTerminal(board, colorMultiplier))
                return EvaluateBoard(board);
            // Maximization
            if (maximizingPlayer) {
                value = int.MinValue;
                foreach (Piece[,] child in BoardChild(board, colorMultiplier)) {
                    value = Mathf.Max(value, MinMax(child, depth - 1, false, -colorMultiplier));
                }
            }
            // Minimization
            else {
                value = int.MaxValue;
                foreach (Piece[,] child in BoardChild(board, colorMultiplier)) {
                    value = Mathf.Min(value, MinMax(child, depth - 1, true, -colorMultiplier));
                }
            }
            return value;
        }

        private List<Piece[,]> BoardChild(Piece[,] board, int colorMultiplier) {
            List<Piece[,]> boards = new List<Piece[,]>();
            foreach (Piece piece in board) {
                if (piece == null) continue;
                if (piece.ColorMultiplier != colorMultiplier) continue;
                    foreach (Vector2Int move in piece.AvailableMove(board)) {
                    Piece[,] boardCopy = new Piece[8, 8];
                    Array.Copy(board, boardCopy, 64);
                    TheoricMove(boardCopy, piece, move);
                    if (!IsInCheck(boardCopy, colorMultiplier)) boards.Add(boardCopy);
                    }
            }
            if (boards.Count == 0) checkmate = true;
            else {
                checkmate = false;
            }
            return boards;
        }

        private int EvaluateBoard(Piece[,] board) {
            int value = 0;
            foreach (var piece in board) {
                if (piece == null) continue;
                switch (PlayerColorMultiplier) {
                    case 1:
                        value += piece.IdPiece * 10;
                        value += piece.AvailableMove(board).Count * piece.ColorMultiplier;
                        break;
                    case -1:
                        value -= piece.IdPiece * 10;
                        value -= piece.AvailableMove(board).Count * piece.ColorMultiplier;
                        break;
                }
            }
            return value;
        }
        
        private bool IsTerminal(Piece[,] board, int colorMultiplier) {
            return checkmate;
        }

        private bool IsInCheck(Piece[,] board, int colorMultiplier) {
            bool isInCheck = true;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (board[i,j] == null) continue;
                    if (board[i, j].GetType() == typeof(King) && (board[i, j].ColorMultiplier == colorMultiplier)) isInCheck = false;
                }
            }
            return isInCheck;
        }
        
        private int Alphabeta(Piece[,] board, int a, int b, int playerColorMultiplier, int depth, bool isMaximizing) {
            int value = 0;
            if (IsTerminal(board, playerColorMultiplier) || depth == 0)
                return EvaluateBoard(board);
            else {
                if (!isMaximizing) {
                    value = int.MaxValue;
                    foreach (var minChild in BoardChild(board, playerColorMultiplier)) {
                        value = Mathf.Min(value, Alphabeta(minChild, a, b, playerColorMultiplier, depth - 1, isMaximizing));
                        if (a >= value) {
                            return value;
                            b = Mathf.Min(b, value);
                        }
                    }
                }
                else {
                    value = int.MaxValue;
                    foreach (var maxChild in BoardChild(board, playerColorMultiplier)) {
                        value = Mathf.Max(value,
                            Alphabeta(maxChild, a, b, playerColorMultiplier, depth - 1, isMaximizing));
                        if (value >= b) {
                            return value;
                            a = Mathf.Max(a, value);
                        }
                    }
                }
            }
            return value;
        }
        
        /* Ancienne Version
        private int MiniMax(Piece[,] board, int depth) {
            int value = 0;
            List<List<Piece[,]>> Tree = GetNodes(board, depth, true);
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

        private List<List<Piece[,]>> GetNodes(Piece[,] board, int depth, bool isMaximizing) {
            List<List<Piece[,]>> Tree = new List<List<Piece[,]>>();
            int maxValue = -99999;
            int minValue = 99999;
            if (depth > 0) {
                List<List<Piece[,]>> tree = new List<List<Piece[,]>>();
                List<Piece[,]> Actions = new List<Piece[,]>();
                isMaximizingNode = isMaximizing;
                if (isMaximizingNode) {
                    foreach (Piece piece in _myPiece) {
                        List<Vector2Int> move = piece.AvailableMove(board);
                        if (!IsInBoard(piece)) continue;
                        Vector2Int position = new Vector2Int();
                        position.x = piece.Coordinate.x;
                        position.y = piece.Coordinate.y;
                        foreach (Vector2Int vector2Int in move) {
                            int value = 0;
                            bool wasATargetHere = false;
                            Piece cible = null;
                            if (board[vector2Int.x, vector2Int.y] != null) {
                                wasATargetHere = true;
                                cible = board[vector2Int.x, vector2Int.y];
                            }

                            Piece[,] node = new Piece[8, 8];
                            Array.Copy(board, node, 64);
                            node = TheoricMove(node, piece, vector2Int);
                            value = EvaluateBoard(node);
                            if (value > maxValue) {
                                maxValue = value;
                                BestMove = vector2Int;
                                BestPiece = piece;
                            }

                            Actions.Add(node);
                            board = CancelMove(node, piece, position, wasATargetHere, cible);
                        }
                    }
                }
                else {
                    foreach (Piece piece in _opponentPiece) {
                        if (!IsInBoard(piece)) continue;
                        if (piece == null) continue;
                        Vector2Int position = new Vector2Int();
                        for (int i = 0; i < 8; i++) {
                            for (int j = 0; j < 8; j++) {
                                if (board[i, j] == piece)
                                    position = new Vector2Int(i, j);
                            }
                        }

                        List<Vector2Int> move = piece.AvailableMove(board);
                        foreach (Vector2Int vector2Int in move) {
                            int value = 0;
                            bool wasATargetHere = false;
                            Piece cible = null;
                            if (board[vector2Int.x, vector2Int.y] != null) {
                                wasATargetHere = true;
                                cible = board[vector2Int.x, vector2Int.y];
                            }

                            Piece[,] node = new Piece[8, 8];
                            Array.Copy(board, node, 64);
                            node = TheoricMove(node, piece, vector2Int);
                            value = EvaluateBoard(node);
                            if (value < minValue) {
                                minValue = value;
                                BestMove = vector2Int;
                                BestPiece = piece;
                            }

                            Actions.Add(node);
                            board = CancelMove(node, piece, position, wasATargetHere, cible);
                        }
                    }
                }

                tree.Add(Actions);
                depth--;
                isMaximizingNode = !isMaximizingNode;
                foreach (var possibilité in Actions) {
                    GetNodes(possibilité, depth, isMaximizingNode);
                }

                Tree = tree;
            }

            return Tree;
        }

        /* private int EvaluateBoard(Piece[,] board) {
             int value = 0;
             foreach (var piece in board) {
                 if (piece == null) continue;
                 switch (team) {
                     case Team.White:
                         value += piece.IdPiece * 10;
                         value += piece.AvailableMove(board).Count * piece.ColorMultiplier;
                         break;
                     case Team.Black:
                         value -= piece.IdPiece * 10;
                         value -= piece.AvailableMove(board).Count * piece.ColorMultiplier;
                         break;
                 }
             }
 
             return value;
         }

        private bool IsInBoard(Piece piece) {
            return piece.Coordinate.x >= 0 && piece.Coordinate.x <= 7 && piece.Coordinate.y >= 0 &&
                   piece.Coordinate.y <= 7;
        }

        private void Kill(Piece[,] board, Piece piece) {
            if (PlayerColorMultiplier == 1) _score += piece.IdPiece;
            if (PlayerColorMultiplier == -1) _score -= piece.IdPiece;
            if (_myPiece.Contains(piece)) _myPiece.Remove(piece);
            if (_opponentPiece.Contains(piece)) _opponentPiece.Remove(piece);
            board[piece.Coordinate.x, piece.Coordinate.y] = null;
        }

        private Piece[,] CancelMove(Piece[,] board, Piece piece, Vector2Int vector2Int, bool wasATargetHere,
           Piece cible) {
           int i = piece.Coordinate.x;
           int j = piece.Coordinate.y;
           board[vector2Int.x, vector2Int.y] = piece;
           if (wasATargetHere && cible != null) board[i, j] = cible;
           else {
               board[i, j] = null;
           }

           return board;
       }

        private void Minimax(Piece[,] board, int depth, Team team) {
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
        }

        private void ChooseTheBestMove(Piece [,] board) {
          Vector2Int bestMove;
          int index;
          if (isYourTurn) index = MiniMax(board, 1);

        }
        
        private Piece[,] Move(Piece[,] board, Piece piece, Vector2Int vector2Int) {
            Piece[,] newBoard = new Piece[8, 8];
            int i = piece.Coordinate.x;
            int j = piece.Coordinate.y;

            Piece target = board[vector2Int.x, vector2Int.y];
            if (target != null) Kill(board, target);
            board[vector2Int.x, vector2Int.y] = piece;
            board[i, j] = null;
            newBoard = board;

            Opponent.isYourTurn = isYourTurn;
            isYourTurn = !isYourTurn;
            isWhite = !isWhite;
            return newBoard;
        }*/
    }
}