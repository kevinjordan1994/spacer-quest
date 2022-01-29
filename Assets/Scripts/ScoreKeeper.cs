using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int money = 0;
    [SerializeField] int rank = 0;

    static ScoreKeeper scoreKeeper;

    void Awake()
    {
        ManageSingleton();
    }

    void Update()
    {
        CalculateRank();
    }

    void ManageSingleton()
    {
        if (scoreKeeper != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreKeeper = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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

    void CalculateRank()
    {
        if (money < 1500)
        {
            rank = 0;
        }

        else if (money < 3000 && money > 1501)
        {
            rank = 1;
        }

        else if (money < 20000 && money > 3001)
        {
            rank = 2;
        }

        else if (money < 50000 && money > 20001)
        {
            rank = 3;
        }

        else if (money > 50000)
        {
            rank = 4;
        }
    }

    public int GetRank()
    {
        return rank;
    }
}
