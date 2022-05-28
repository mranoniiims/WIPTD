using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMPro.TMP_Text roundsTXT;


    void OnEnable()
    {
        roundsTXT.text = "Waves survived:\n" + PlayerStats.Rounds.ToString();
    }

}
