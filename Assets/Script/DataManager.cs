using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] public static Piece[,] board = new Piece[8, 8];
    public Piece KingW, KingB, QueenW, QueenB, FoolW, FoolB, KnightW, KnightB, RookW, RookB, PawnW, PawnB; 

    private void Awake() {
        var StartBoard = new Piece[8, 8] {
            { RookW, KnightW, FoolW, KingW, QueenW, FoolW, KnightW, RookW },
            { PawnW, PawnW, PawnW, PawnW, PawnW, PawnW, PawnW, PawnW },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { PawnB, PawnB, PawnB, PawnB, PawnB, PawnB, PawnB, PawnB },
            { RookB, KnightB, FoolB, QueenB, KingB, FoolB, KnightB, RookB }
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
    }
}