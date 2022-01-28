using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI moneyText;
    
    ScoreKeeper money;

    void Awake()
    {
        money = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealthAmount();
    }

    void Update()
    {
        DisplayMoney();
        ManageHealthSlider();
    }

    void DisplayMoney()
    {
        moneyText.text = money.GetMoneyAmount().ToString("00000000");
    }

    void ManageHealthSlider()
    {
        healthSlider.value = playerHealth.GetHealthAmount();
    }
}
