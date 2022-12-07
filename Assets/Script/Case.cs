using System;
using UnityEngine;

public class Case : MonoBehaviour
{
    public bool isTaken, byWhite;

    private void OnTriggerStay(Collider other) {
        isTaken = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Taken !");
        Piece piece = other.GetComponent<Piece>();
        int id = piece.IdPiece;
        isTaken = true;
        if (id > 0) byWhite = true;
        else
        { byWhite = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        isTaken = false;
    }
}