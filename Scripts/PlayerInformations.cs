using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerInformations : MonoBehaviour
{
    public static PlayerInformations playerInfos;

    public int playerHealth = 3;
    public int nbCoins = 0;
    public Image[] hearts;
    public TextMeshProUGUI coinNumber;
    public TextMeshProUGUI scoreNumber;

    private void Awake()
    {
        playerInfos = this;
    }

    public void SetHealth(int val)
    {
        playerHealth += val;
        if (playerHealth > 3)
            playerHealth = 3;

        if (playerHealth < 0)
            playerHealth = 0;

        SetHealthBar();
    }

    private void SetHealthBar()
    {
        foreach (Image img in hearts)
        {
            img.enabled = false;
        }
        for (int i = 0; i < playerHealth; i++)
        {
            hearts[i].enabled = true;
        }
    }

    public void GetCoin()
    {
        nbCoins++;
        coinNumber.text = nbCoins.ToString();
    }

    public int GetScore()
    {
        int finalScore = (nbCoins * 5) + (playerHealth * 10);
        scoreNumber.text = "Score : " + finalScore;
        return finalScore;
    }
}
