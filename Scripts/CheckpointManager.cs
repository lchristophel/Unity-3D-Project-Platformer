using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 lastPoint;
    public AudioClip checkpointSound;
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
        }
    }

    public void Respawn()
    {
        transform.position = lastPoint;
        PlayerInformations.playerInfos.SetHealth(3);
    }
}
