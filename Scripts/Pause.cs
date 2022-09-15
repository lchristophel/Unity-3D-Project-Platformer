using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public TextMeshProUGUI missions;
    public static int friendToHelp = 3;
    private bool isPaused = false;

    public void SetMissionText()
    {
        missions.text = "Il reste " + friendToHelp + " amis à libérer";
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
