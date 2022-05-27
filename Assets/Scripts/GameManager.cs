using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool gameEnded = false;
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameEnded = true;
        Debug.Log("Game OVER!");
    }
}
