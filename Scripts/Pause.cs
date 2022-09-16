using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public TextMeshProUGUI missionsText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI mobsText;
    public static int friendToHelp = 3;
    public static int coinsTaken = 28;
    public static int mobsToKill = 3;
    private bool isPaused = false;

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void SetMissionText()
    {
        if (friendToHelp <= 1)
        {
            missionsText.text = "Il reste " + friendToHelp + " ami à libérer";
        }
        else
        {
            missionsText.text = "Il reste " + friendToHelp + " amis à libérer";
        }
        if (coinsTaken <= 1)
        {
            coinsText.text = "Il reste " + coinsTaken + " pièce à récupérer";
        }
        else
        {
            coinsText.text = "Il reste " + coinsTaken + " pièces à récupérer";
        }
        if (mobsToKill <= 1)
        {
            mobsText.text = "Il reste " + mobsToKill + " monstre à éliminer";
        }
        else
        {
            mobsText.text = "Il reste " + mobsToKill + " monstres à éliminer";
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                pause.SetActive(isPaused);
                Time.timeScale = 1f;
            }
            else
            {
                SetMissionText();
                isPaused = true;
                pause.SetActive(isPaused);
                Time.timeScale = 0f;
            }
        }
    }
}
