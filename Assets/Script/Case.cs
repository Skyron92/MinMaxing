using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Case")]
public class Case : ScriptableObject {
    public bool isTaken, byWhite;
    public Image sprite;
    public int X, Y, IdPiece;

    private void Awake() {
        GetPiece();
    }
    void GetPiece() {
        if (DataManager.board[X, Y] != null) {
            isTaken = true;
            Debug.Log(isTaken);
            IdPiece = DataManager.board[X, Y].ColorMultiplier;
        }
        else isTaken = false;
    }
}