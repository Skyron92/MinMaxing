using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Case")]
public class Case : ScriptableObject {
    public bool isTaken, byWhite;
    public Image sprite;
    public int X, Y;

    void GetPiece() {
        if (DataManager.board[X, Y] != null) isTaken = true;
        else isTaken = false;
    }
}