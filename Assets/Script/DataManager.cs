using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] public static Piece[,] board = new Piece[8, 8];
    [SerializeField] public GameObject RookPrefab, KnightPrefab, FoolPrefab, QueenPrefab, KingPrefab, PawnPrefab;
    public Piece KingW, KingB, QueenW, QueenB, FoolW, FoolB, KnightW, KnightB, RookW, RookB, PawnW, PawnB; 

    private void Awake() {
        var StartBoard = new Piece[8, 8] {
            { new Rook(1), new Knight(1), new Fool(1), new King(1), new Queen(1), new Fool(1), new Knight(1),
                new Rook(1) },
            { new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1) },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1),
                new Pawn(-1) },
            { new Rook(-1), new Knight(-1), new Fool(-1), new Queen(-1), new King(-1), new Fool(-1), new Knight(-1),
                new Rook(-1) }
        };
        foreach (var VARIABLE in StartBoard) {
            if (VARIABLE != null) InstanciatePiece(CheckPieceClass(VARIABLE));
        }
    }
    int CheckPieceClass(Piece piece) {
        int Id = piece.TypeOfPiece;
        return Id;
    }

    void InstanciatePiece(int id) {
        if(id == null) return;
        if (id == 1) Instantiate(PawnPrefab);
        if (id == 2) Instantiate(RookPrefab);
        if (id == 3) Instantiate(KnightPrefab);
        if (id == 4) Instantiate(FoolPrefab);
        if (id == 5) Instantiate(QueenPrefab);
        if (id == 6) Instantiate(KingPrefab);
    }
}