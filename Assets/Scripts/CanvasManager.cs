using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private string height;
    private void Update()
    {
        height = gameManager.GetHeight().ToString();
        scoreText.text = "Height: " + height + " m";
    }
}
