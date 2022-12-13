using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Case")]
public class Case : ScriptableObject{
    public bool isTaken;
    public Image sprite;
    public int X, Y, IdPiece;
    private DataManager dataManager;

    private void Awake() {
        //GetPiece();
    }
    public void GetPiece() {
        dataManager = DataManager._DataManager;
        if (dataManager.board[X, Y].ColorMultiplier != 0) {
            isTaken = true;
            Debug.Log(isTaken);
            IdPiece = dataManager.board[X, Y].ColorMultiplier;
        }
        else isTaken = false;
    }
}