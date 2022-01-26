using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int money = 0;

    public int GetMoneyAmount()
    {
        return money;
    }

    public void AddToMoneyAmount(int value)
    {
        money += value;
        Mathf.Clamp(money, 0, int.MaxValue);
        Debug.Log(money);
    }

    public void ResetMoneyAmount()
    {
        money = 0;
    }
}
