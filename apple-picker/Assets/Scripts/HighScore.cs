using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    static public int score = 0;
    TextMeshProUGUI scoreGT;

    private void Awake()
    {
        scoreGT = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update()
    {
        scoreGT.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
