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

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private TextMeshProUGUI restartText;

    private string height;

    private void Start()
    {
        gameOverText.enabled = false;
        restartText.enabled = false;
    }

    private void Update()
    {
        height = gameManager.GetHeight().ToString();
        scoreText.text = "Height: " + height + " m";

        if(gameManager.IsGameOver())
        {
            gameOverText.enabled = true;
            restartText.enabled = true;
        }
    }
}
