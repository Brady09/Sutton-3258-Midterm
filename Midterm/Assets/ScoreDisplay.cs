using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay instance;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null && Score.instance != null)
        {
            scoreText.text = "Score: " + Score.instance.score.ToString();
        }
    }

    public void OnScoreUpdated()
    {
        UpdateScoreText();
    }
}