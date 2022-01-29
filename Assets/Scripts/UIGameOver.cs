using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] Image rankImage;
    [SerializeField] List<Sprite> rankSprites;
    ScoreKeeper score;

    void Awake()
    {
        score = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreDisplay.text = "Final Score: " + score.GetMoneyAmount().ToString("00000000");
        DisplayRank();
    }

    void DisplayRank()
    {
        if (score.GetMoneyAmount() < 1500)
        {
            rankImage.sprite = rankSprites[0];
        }

        else if (score.GetMoneyAmount() < 3000 && score.GetMoneyAmount() > 1501)
        {
            rankImage.sprite = rankSprites[1];
        }

        else if (score.GetMoneyAmount() < 10000 && score.GetMoneyAmount() > 3001)
        {
            rankImage.sprite = rankSprites[2];
        }
        
        else if (score.GetMoneyAmount() < 25000 && score.GetMoneyAmount() > 10001)
        {
            rankImage.sprite = rankSprites[3];
        }

        else if (score.GetMoneyAmount() > 50000)
        {
            rankImage.sprite = rankSprites[4];
        }
    }
}
