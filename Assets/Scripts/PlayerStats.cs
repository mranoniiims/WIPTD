using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public static int Lives;
    public int startLives = 20;
    public TMPro.TMP_Text playerLivesText;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }

    void Update()
    {
        playerLivesText.text = "Remaining lives:\n" + Lives;
    }
}
