using System;
using System.Collections.Generic;
using Script.Pieces;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Managers {
    public class DataManager : MonoBehaviour
    {
        private Canvas fdes;

        public bool UseTestingBoard;
        public Transform BoardTransform;
        public Transform PiecesTransform;
        public GameObject WhiteSquarePrefab, BlackSquarePrefab, PiecePrefab;
        public Sprite Empty;
        public Sprite WhiteRook, WhiteKnight, WhiteFool, WhiteQueen, WhiteKing, WhitePawn;
        public Sprite BlackRook, BlackKnight, BlackFool, BlackQueen, BlackKing, BlackPawn;
        public List<GameObject> sprites = new List<GameObject>();

        public Piece[,] board = new Piece[8, 8];
        public static DataManager Instance = new DataManager();

        private void Awake() {
            Instance = this;
            board = UseTestingBoard ? GenerateTestingBoard() : GenerateBoard();
            DisplayBoard();
            DisplayPieces(board);
            AttributeType();
        }

        private void Update() {
            if (MinMax.WhiteHasPlayed || MinMax.BLackHasPlayed) {
                DestroyPieces();
                board = MinMax.NewBoard;
                DisplayPieces(board);
            }
        }

        private Piece[,] GenerateBoard() {
            return new Piece[8, 8] {
                {
                    new Rook(-1), new Knight(-1), new Fool(-1), new King(-1), new Queen(-1), new Fool(-1),
                    new Knight(-1), new Rook(-1)
                }, {
                    new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1),
                    new Pawn(-1)
                },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null }, {
                    new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1),
                    new Pawn(1)
                }, {
                    new Rook(1), new Knight(1), new Fool(1), new Queen(1), new King(1), new Fool(1), new Knight(1),
                    new Rook(1)
                }
            };
        }

        private Piece[,] GenerateTestingBoard() {
            return new Piece[8, 8] {
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null }, 
                {null, new Knight(1), null, null, null, null, new Knight(1), null }
                
            };
        }

        private void DisplayBoard() {
            // Instantiate Squares
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Instantiate((i + j) % 2 == 0 ? WhiteSquarePrefab : BlackSquarePrefab, BoardTransform);
                }
            }

            /*/ Instantiate Pieces
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++) {
                    Piece piece = board[i, j];
                    GameObject instantiate = Instantiate(PiecePrefab, PiecesTransform);
                    instantiate.GetComponent<Image>().sprite = GetSprite(piece);
                }
            }*/
        }

        private void AttributeType() {
            foreach (Piece piece in board) {
                if(piece == null) continue;
                Type type = piece.GetType();
                if (type == typeof(Rook)) {
                    piece.IdPiece = 5 * piece.ColorMultiplier;
                }
                if (type == typeof(Knight) || type == typeof(Fool)) {
                    piece.IdPiece = 3 * piece.ColorMultiplier;
                }
                if (type == typeof(Queen)) {
                    piece.IdPiece = 10 * piece.ColorMultiplier;
                }
                if (type == typeof(King)) {
                    piece.IdPiece = 150 * piece.ColorMultiplier;
                }
                if (type == typeof(Pawn)) {
                    piece.IdPiece = 1 * piece.ColorMultiplier;
                }
            }
        }

        public void DisplayPieces(Piece[,] board) {
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++) {
                    Piece piece = board[i, j];
                    GameObject instantiate = Instantiate(PiecePrefab, PiecesTransform);
                    sprites.Add(instantiate);
                    instantiate.GetComponent<Image>().sprite = GetSprite(piece);
                }
            }
        }

        public void DestroyPieces() {
            foreach (var VARIABLE in sprites) {
                Destroy(VARIABLE);
            }
        }

        private Sprite GetSprite(Piece piece) {
            if (piece == null) return Empty;
            Type type = piece.GetType();
            if (type == typeof(Rook) && piece.ColorMultiplier == 1) {
                return WhiteRook;
            }

            if (type == typeof(Knight) && piece.ColorMultiplier == 1) {
                return WhiteKnight;
            }

            if (type == typeof(Fool) && piece.ColorMultiplier == 1) {
                return WhiteFool;
            }

            if (type == typeof(Queen) && piece.ColorMultiplier == 1) {
                return WhiteQueen;
            }

            if (type == typeof(King) && piece.ColorMultiplier == 1) {
                return WhiteKing;
            }

            if (type == typeof(Pawn) && piece.ColorMultiplier == 1) {
                return WhitePawn;
            }

            if (type == typeof(Rook) && piece.ColorMultiplier == -1) {
                return BlackRook;
            }

            if (type == typeof(Knight) && piece.ColorMultiplier == -1) {
                return BlackKnight;
            }

            if (type == typeof(Fool) && piece.ColorMultiplier == -1) {
                return BlackFool;
            }

            if (type == typeof(Queen) && piece.ColorMultiplier == -1) {
                return BlackQueen;
            }

            if (type == typeof(King) && piece.ColorMultiplier == -1) {
                return BlackKing;
            }

            if (type == typeof(Pawn) && piece.ColorMultiplier == -1) {
                return BlackPawn;
            }

            throw new Exception("Cannot find any sprite for " + type);
        }
    }
}