using UnityEngine;

public class DataManager : MonoBehaviour {
    [SerializeField] public static Piece[,] board = new Piece[8, 8];
    public Piece KingW, KingB, QueenW, QueenB, FoolW, FoolB, KnightW, KnightB, RookW, RookB, PawnW, PawnB, Void;
    public Transform Board;
    public GameObject White, Black;

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
        var Echiquier = new GameObject[8, 8] {
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
        };
        foreach (var VARIABLE in Echiquier) {
            if (VARIABLE == White) Instantiate(White, transform);
            else Instantiate(Black, transform);
        }
        foreach (var piece in StartBoard)
            Instantiate(piece.sprite, Board);
                for (int x = StartBoard.GetLowerBound(0); x <= StartBoard.GetUpperBound(0); x++){
                    for (int y = StartBoard.GetLowerBound(1); y<= StartBoard.GetUpperBound(1); y++) {
                        Debug.Log(x + " " + y);
                        StartBoard[x, y].X = x;
                        StartBoard[x, y].Y = y;
                    }
                }
    }
}