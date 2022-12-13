using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piece/Rook")]
public class Rook : Piece {

    public void Awake() {
        TypeOfPiece = 5;
        IdPiece = TypeOfPiece * ColorMultiplier;
        if (ColorMultiplier < 0) sprite.color = new Color(100, 100, 100);
    }

    public override List<Vector2Int> AvailableMove() {
        var list = new List<Vector2Int>();
        
        //Déplacement vertical vers l'avant
        for (int i = 1; X + i < 8; i++) {
            if (!GetCase(X + i * ColorMultiplier, Y)) { //si la case est libre
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
            if (!GetCase(X - i * ColorMultiplier, Y)
               ) {
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
            if (!GetCase(X, Y + j * ColorMultiplier)) {
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
                if (!GetCase(X, Y - j * ColorMultiplier)) {
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