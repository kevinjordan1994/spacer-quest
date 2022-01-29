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
        rankImage.sprite = rankSprites[score.GetRank()];
    }
}
