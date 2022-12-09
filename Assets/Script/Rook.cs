using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Rook")]
public class Rook : Piece {

    public void Awake() {
        TypeOfPiece = 2;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        var list = new List<Vector2Int>();
        bool hasPiece;
        
        //Déplacement vertical vers l'avant
        for (int i = 1; X + i < 8; i++) {
            hasPiece = DataManager.Echiquier[X + i * ColorMultiplier, Y].isTaken;
            if (!hasPiece) { //si la case est libre
                Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y);
                list.Add(move);
            }
            else { //sinon on vérifie la couleur de la pièce
                if (GetFactionCase(X + i * ColorMultiplier, Y)) {
                    break;
                }
                else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                    Vector2Int move = new Vector2Int(X + i * ColorMultiplier, Y);
                    list.Add(move);
                    break;
                }
            }
        }

        for (int i = 1; X - i >= 0; i++) {
            hasPiece = DataManager.Echiquier[X - i * ColorMultiplier, Y].isTaken;
            if (!hasPiece) {
                Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y);
                list.Add(move);
            }
            else { //sinon on vérifie la couleur de la pièce
                if (GetFactionCase(X - i * ColorMultiplier, Y)) {
                    break;
                }
                else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                    Vector2Int move = new Vector2Int(X - i * ColorMultiplier, Y);
                    list.Add(move);
                    break;
                }
            }
        }

        int j;
        for (j = 1; Y + j < 8; j++) {
            hasPiece = DataManager.Echiquier[X, Y + j * ColorMultiplier].isTaken;
            if (!hasPiece) {
                Vector2Int move = new Vector2Int(X, Y + j * ColorMultiplier);
                list.Add(move);
            }
            else { //sinon on vérifie la couleur de la pièce
                if (GetFactionCase(X, Y + j * ColorMultiplier)) {
                    break;
                }
                else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                    Vector2Int move = new Vector2Int(X, Y + j * ColorMultiplier);
                    list.Add(move);
                    break;
                }
            }

            for (j = 1; Y - j >= 0; j++) {
                hasPiece = DataManager.Echiquier[X, Y - j * ColorMultiplier].isTaken;
                if (!hasPiece) {
                    Vector2Int move = new Vector2Int(X, Y - j * ColorMultiplier);
                    list.Add(move);
                }
                else { //sinon on vérifie la couleur de la pièce
                    if (GetFactionCase(X, Y - j * ColorMultiplier)) {
                        break;
                    }
                    else { //si c'est une pièce ennemie, on arrête le mouvement sur sa position 
                        Vector2Int move = new Vector2Int(X, Y - j * ColorMultiplier);
                        list.Add(move);
                        break;
                    }
                }
            }
        }
        return list;
    }
}