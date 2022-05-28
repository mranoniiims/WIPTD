using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject gameOverUI;

    void Start()
    {
        gameIsOver = false;
    }
    void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
