using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DataManager : MonoBehaviour
{
    public static int[,] Plateau = new int[8,8];
    [SerializeField] private static Button[,] grid = new Button[8,8];
    [SerializeField] public Button CasePrefab;

    private void Awake() {
        foreach (int Int in Plateau) {
            Button instance = Instantiate(CasePrefab, transform);
            foreach (Button cases in grid) {
                int position = Array.IndexOf(grid, cases);
                if (position == 1 || position == 8 || position == 76 || position == 64) cases.AddComponent<Rook>();
                if (position == 2 || position == 7 || position == 77 || position == 63) cases.AddComponent<Knight>();
                if (position == 3 || position == 6 || position == 78 || position == 62) cases.AddComponent<Fool>();
                if (position == 4 || position == 61) cases.AddComponent<Queen>();
                if (position == 5 || position == 60) cases.AddComponent<King>();
                if (position >= 9 && position <= 18 || position >= 67 && position <= 75) cases.AddComponent<Pion>();
            }
        }
    }
}