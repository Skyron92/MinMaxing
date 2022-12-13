using System;
using UnityEngine;

public class DataManager : MonoBehaviour {
    public Piece[,] board = new Piece[8, 8];
    public Case[,] Echequier = new Case[8, 8];
    public Piece KingW, KingB, QueenW, QueenB, FoolW, FoolB, KnightW, KnightB, RookW, RookB, PawnW, PawnB, Void;
    public Transform Board;
    public Case White, Black;
    public static DataManager _DataManager;

    private void Awake() {
        var StartBoard = new Piece[8, 8] {
            { RookW, KnightW, FoolW, KingW, QueenW, FoolW, KnightW, RookW },
            { PawnW, PawnW, PawnW, PawnW, PawnW, PawnW, PawnW, PawnW },
            { Void, Void, Void, Void, Void, Void, Void, Void },
            { Void, Void, Void, Void, Void, Void, Void, Void },
            { Void, Void, Void, Void, Void, Void, Void, Void },
            { Void, Void, Void, Void, Void, Void, Void, Void },
            { PawnB, PawnB, PawnB, PawnB, PawnB, PawnB, PawnB, PawnB },
            { RookB, KnightB, FoolB, QueenB, KingB, FoolB, KnightB, RookB }
        };
        board = StartBoard;
        var startexhiquier = new Case[8,8]{
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
        };
        Echequier = startexhiquier;
        foreach (var cases in Echequier) {
            if (cases == White) Instantiate(White.sprite, transform);
            else Instantiate(Black.sprite, transform);
            for (int x = 0; x < 8; x++) {
                for (int y = 0; y < 8; y++) {
                    Echequier[x, y].X = x;
                    Echequier[x, y].Y = y;
                }
            }
        }

        foreach (Piece piece in board) {
            Instantiate(piece.sprite, Board);
            for (int x = 0; x < 8; x++) {
                for (int y = 0; y < 8; y++) {
                    board[x, y].X = x;
                    board[x, y].Y = y;
                }
            }
        }
        _DataManager = this;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            foreach (Piece piece in board) {
                piece.GetList();
                Debug.Log(piece.AvailableTarget);
            }
        }
    }
}