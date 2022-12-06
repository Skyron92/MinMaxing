using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DataManager : MonoBehaviour
{
    public static int[,] Plateau = new int[8,8];
    [SerializeField] private static Piece[,] grid = new Piece[8,8];
    [SerializeField] public GameObject CasePrefab;

    private void Awake() {
        GameObject instance = Instantiate(CasePrefab, transform);
            Piece[,] board = new Piece[,] {
                { new Rook(1), new Knight(1), new Fool(1), new King(1), new Queen(1), new Fool(1), new Knight(1), new Rook(1) },
                { new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1), new Pawn(1)},
                { null, null, null, null, null, null, null ,null},
                { null, null, null, null, null, null, null ,null},
                { null, null, null, null, null, null, null ,null},
                { null, null, null, null, null, null, null ,null},
                { new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1), new Pawn(-1)},
                { new Rook(-1), new Knight(-1), new Fool(-1), new Queen(-1), new King(-1), new Fool(-1), new Knight(-1), new Rook(-1)},
            };
    }
}
