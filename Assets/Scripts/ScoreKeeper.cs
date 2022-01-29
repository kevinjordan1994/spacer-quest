using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int money = 0;

    static ScoreKeeper scoreKeeper;

    void Awake()
    {
        ManageSingleton();
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
}
