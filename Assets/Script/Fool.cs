using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Fool")]
public class Fool : Piece {
    public void Awake() {
        TypeOfPiece = 4;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        List<Vector2Int> list = new List<Vector2Int>();
        bool hasPiece;
        
        for (int i = 1; X + i < 8; i++) {
            hasPiece = DataManager.Echiquier[X + i * ColorMultiplier, Y + i * ColorMultiplier].isTaken;
            if (!hasPiece) {
                Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y + i * ColorMultiplier);
                list.Add(move);
            }
            else { //sinon on vérifie la couleur de la pièce
                if (GetFactionCase(X + i * ColorMultiplier, Y + i * ColorMultiplier)) {
                    break;
                }
                else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                    Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y + i * ColorMultiplier);
                    list.Add(move);
                    break;
                }
            }
        }
        for (int i = 1; X - i >= 0; i++) {
            hasPiece = DataManager.Echiquier[X - i * ColorMultiplier, Y - i * ColorMultiplier].isTaken;
            if (!hasPiece) {
                Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y - i * ColorMultiplier);
                list.Add(move);
            }
            else { //sinon on vérifie la couleur de la pièce
                if (GetFactionCase(X - i * ColorMultiplier, Y - i * ColorMultiplier)) {
                    break;
                }
                else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                    Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y - i * ColorMultiplier);
                    list.Add(move);
                    break;
                }
            }
        }

        for (int i = 1; X + i < 8; i++) {
            for (int j = 1; Y - j >= 0; j++) {
                hasPiece = DataManager.Echiquier[X + i * ColorMultiplier, Y - j * ColorMultiplier].isTaken;
                if (!hasPiece) {
                    Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y - j * ColorMultiplier);
                    list.Add(move);
                }
                else { //sinon on vérifie la couleur de la pièce
                    if (GetFactionCase(X + i * ColorMultiplier, Y - j * ColorMultiplier)) {
                        break;
                    }
                    else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                        Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y - j * ColorMultiplier);
                        list.Add(move);
                        break;
                    }
                }
            }
        }
        for (int i = 1; X - i >= 0; i++) {
            for (int j = 1; Y + j < 8; j++) {
                hasPiece = DataManager.Echiquier[X - i * ColorMultiplier, Y + j * ColorMultiplier].isTaken;
                if (!hasPiece) {
                    Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y + j * ColorMultiplier);
                    list.Add(move);
                }
                else { //sinon on vérifie la couleur de la pièce
                    if (GetFactionCase(X - i * ColorMultiplier, Y + j * ColorMultiplier)) {
                        break;
                    }
                    else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                        Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y + j * ColorMultiplier);
                        list.Add(move);
                        break;
                    }
                }
            }
        }

        return list;
    }
}