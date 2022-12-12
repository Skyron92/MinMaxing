using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Piece : ScriptableObject {
    public int ColorMultiplier, TypeOfPiece, IdPiece, X, Y;
    public Image sprite;
    public List<Vector2Int> AvailableTarget = new List<Vector2Int>();
    public Vector2Int position = new Vector2Int();
    public bool CanMove;

    public abstract List<Vector2Int> AvailableMove();

    public bool GetCase(int x, int y) {
        bool hasPiece = false;
        Case current = DataManager.Echiquier[x, y];
        hasPiece = current.isTaken;
        return hasPiece;
    }
    
    public bool GetFactionCase(int x, int y) {
        bool isSameColor = false;
        Case current = DataManager.Echiquier[x, y];
        if (current.IdPiece == ColorMultiplier) isSameColor = true;
        return isSameColor;
    }
}