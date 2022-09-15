using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HelpFriend : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public GameObject chicken;
    public GameObject chicken2;
    public GameObject chicken3;
    public AudioClip friendSound;
    public AudioClip chickenSound;
    private bool canOpen = false;
    private GameObject cage;
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cage")
        {
            cage = other.gameObject;
            infoText.text = "Appuie sur E pour ouvrir";
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Cage")
        {
            cage = null;
            canOpen = false;
            infoText.text = "";
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            iTween.ShakeScale(cage, new Vector3(145,145,145), 1f);
            audioSource.PlayOneShot(friendSound);
            Destroy(cage, 1);
            infoText.text = "";
            iTween.ShakeScale(chicken, new Vector3(2,2,2), 5);
            iTween.ShakeScale(chicken2, new Vector3(2,2,2), 5);
            iTween.ShakeScale(chicken3, new Vector3(2,2,2), 5);
            audioSource.PlayOneShot(chickenSound);
        }
    }  
}
