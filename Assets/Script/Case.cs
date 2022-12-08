using UnityEngine;
using UnityEngine.UI;

public class Case : MonoBehaviour {
    public bool isTaken, byWhite;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Taken !");
        isTaken = true;
        var piece = other.GetComponent<Image>();
        if (piece.color == Color.white) byWhite = true;
        else
            byWhite = false;
    }

    private void OnTriggerExit(Collider other) {
        isTaken = false;
    }

    private void OnTriggerStay(Collider other) {
        isTaken = true;
    }
}