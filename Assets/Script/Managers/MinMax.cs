using System;
using System.Collections.Generic;
using Script.Managers;
using Script.Pieces;
using UnityEngine;

public class MinMax : MonoBehaviour
{
    [SerializeField] public Team team;
    public List<Piece> myPiece = new List<Piece>();
    public bool isYourTurn;
    private DataManager _dataManager => DataManager.Instance;
    public enum Team {
        White,
        Black
    }

    private void Awake() {
        if (team == Team.White) isYourTurn = true;
        else {
            isYourTurn = false;
        }
        foreach (Piece piece in _dataManager.board) {
            if(piece.ColorMultiplier == 1 && team == Team.White) myPiece.Add(piece);
            if(piece.ColorMultiplier == - 1 && team == Team.Black) myPiece.Add(piece);
        }

        
    }
    
    private int Evaluation(Piece[,] currentBoard) {
        int value = 0;
        foreach (Piece piece in currentBoard) {
            if(team == Team.White) value += piece.IdPiece;
            if(team == Team.Black) value -= piece.IdPiece;
        }
        return value;
    }
}