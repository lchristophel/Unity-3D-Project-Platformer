using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 lastPoint;
    // Start is called before the first frame update
    void Start()
    {
        lastPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            lastPoint = transform.position;
            other.gameObject.GetComponent<CoinAnim>().enabled = true;
        }
    }

    public void Respawn()
    {
        transform.position = lastPoint;
        PlayerInformations.playerInfos.SetHealth(3);
    }
}
