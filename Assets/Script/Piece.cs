using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Piece : ScriptableObject {
    public int ColorMultiplier, TypeOfPiece, IdPiece, X, Y, score;
    public Image sprite;
    public List<Vector2Int> AvailableTarget = new List<Vector2Int>();
    public Vector2Int position = new Vector2Int();
    private DataManager _dataManager;
    private BoxCollider collider;
    private Rigidbody rb;
    public bool CanMove;

    private void Awake() {
        collider = this.AddComponent<BoxCollider>();
        collider.size = new Vector3(50, 100, 10);
        
    }

    public abstract List<Vector2Int> AvailableMove();

    public void GetList() {
        AvailableTarget = AvailableMove();
    }

    public void Kill(Piece piece) {
        if (piece.ColorMultiplier != ColorMultiplier) {
            score += piece.IdPiece;
            Destroy(piece);
        }
    }

    private void OnDestroy() {
        score -= IdPiece;
    }

    public bool GetCase(int x, int y) {
        _dataManager = DataManager._DataManager;
        var current = _dataManager.Echequier[x, y];
        current.GetPiece();
        return current.isTaken;
    }
    
    public bool GetFactionCase(int x, int y) {
        _dataManager = DataManager._DataManager;
        bool isSameColor = false;
        Case current = _dataManager.Echequier[x, y];
        current.GetPiece();
        if (current.IdPiece == ColorMultiplier) isSameColor = true;
        return isSameColor;
    }
}