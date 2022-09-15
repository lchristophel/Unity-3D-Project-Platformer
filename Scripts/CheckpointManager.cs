using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 lastPoint;
    public AudioClip checkpointSound;
    public TextMeshProUGUI checkpointText;
    private AudioSource audioSource;

    private void Start()
    {
        lastPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastPoint = transform.position;
            other.gameObject.GetComponent<CoinAnim>().enabled = true;
            audioSource.PlayOneShot(checkpointSound);
            checkpointText.text = "Point de sauvegarde atteint";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            checkpointText.text = "";
        }
    }

    public void Respawn()
    {
        transform.position = lastPoint;
        PlayerInformations.playerInfos.SetHealth(3);
    }
}
