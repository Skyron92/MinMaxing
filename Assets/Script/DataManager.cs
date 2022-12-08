using UnityEngine;

public class DataManager : MonoBehaviour {
    [SerializeField] public static Piece[,] board = new Piece[8, 8];
    public static  Case[,] Echiquier = new Case[8, 8];
    public Piece KingW, KingB, QueenW, QueenB, FoolW, FoolB, KnightW, KnightB, RookW, RookB, PawnW, PawnB, Void;
    public Transform Board;
    public Case White, Black;

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
        Case[,] Echiquier = {
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
            { White, Black, White, Black, White, Black, White, Black },
            { Black, White, Black, White, Black, White, Black, White },
        };
        foreach (var cases in Echiquier) {
            if (cases == White) Instantiate(White.sprite, transform);
            else Instantiate(Black.sprite, transform);
            for (int x = 0; x < 8; x++){
                for (int y = 0; y< 8; y++) {
                    Debug.Log(x + " " + y);
                    Echiquier[x, y].X = x;
                    Echiquier[x, y].Y = y;
                }
            }
        }
        foreach (Piece piece in StartBoard)
            Instantiate(piece.sprite, Board);
                for (int x = 0; x < 8; x++){
                    for (int y = 0; y< 8; y++) {
                        Debug.Log(x + " " + y);
                        StartBoard[x, y].X = x;
                        StartBoard[x, y].Y = y;
                    }
                }
    }
}