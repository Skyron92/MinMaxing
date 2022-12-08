using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Piece : ScriptableObject {
    public int ColorMultiplier, TypeOfPiece, IdPiece, X, Y;
    public Image sprite;
    public List<Vector2Int> AvailableTarget = new();
    private BoxCollider collider;

    private void Awake() {
        collider = this.AddComponent<BoxCollider>();
        collider.size = new Vector3(50, 100, 10);
    }

    public abstract List<Vector2Int> AvailableMove();
}