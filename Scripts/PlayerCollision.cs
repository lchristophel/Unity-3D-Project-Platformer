using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject mobEffect;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;
    public AudioClip hitSound;
    public AudioClip collectSound;
    public AudioClip hurtSound;
    public CheckpointManager checkpointManager;
    public SkinnedMeshRenderer renderer;
    private AudioSource audioSource;
    private bool canInstantiate = true;
    private bool isInvincible = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Void")
        {
            audioSource.PlayOneShot(hurtSound);
            StartCoroutine("TimeForHurtSound");
        }

        // Si le nom du trigger est finalScore
        if (other.gameObject.name == "End")
        {
            Debug.Log(PlayerInformations.playerInfos.GetScore());
        }

        // Si le personnage entre dans la zone trigger "Camera1"
        if (other.gameObject.tag == "Camera1")
        {
            // La caméra1 s'active
            camera1.SetActive(true);
        }

        if (other.gameObject.tag == "Camera2")
        {
            camera2.SetActive(true);
        }

        if (other.gameObject.tag == "Camera3")
        {
            camera3.SetActive(true);
        }

        if (other.gameObject.tag == "Camera3")
        {
            camera3.SetActive(true);
        }

        if (other.gameObject.tag == "Camera3")
        {
            camera3.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Camera1")
        {
            camera1.SetActive(false);
        }

        if (other.gameObject.tag == "Camera2")
        {
            camera2.SetActive(false);
        }

        if (other.gameObject.tag == "Camera3")
        {
            camera3.SetActive(false);
        }

        if (other.gameObject.tag == "Camera4")
        {
            camera4.SetActive(false);
        }

        if (other.gameObject.tag == "Camera5")
        {
            camera5.SetActive(false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision) // Check la collision, plus adapté pour le characterController
    {        
        // Si la collision à le tag Coin
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(collectSound);
            GameObject go = Instantiate(pickupEffect, collision.transform.position, Quaternion.identity); 
            Destroy(go, 0.5f);
            // Détruire le gameObject de la collision, donc le coin
            Destroy(collision.gameObject);
            // Incrémenter nbCoins grâce à la fonction GetCoins() de la classe PlayerInformations du script PlayerInformations
            PlayerInformations.playerInfos.GetCoin();
        }

        // Si la collision à le tag Mob
        if (collision.gameObject.tag == "Mob" && canInstantiate)
        {
            canInstantiate = false;
            audioSource.PlayOneShot(hitSound);
            iTween.PunchScale(collision.gameObject.transform.parent.gameObject, new Vector3(50,50,50), 0.6f);
            GameObject go = Instantiate(mobEffect, collision.transform.position, Quaternion.identity);
            Destroy(go, 0.6f);
            // Détruire le gameObject de la collision, donc le mob après 0.2 seconde
            Destroy(collision.gameObject.transform.parent.gameObject, 0.2f);
            StartCoroutine("ResetInstantiate");
        }

        // Si le tag de la collision est Hurt
        if (collision.gameObject.tag == "Hurt" && !isInvincible)
        {
            PlayerInformations.playerInfos.SetHealth(-1);
            isInvincible = true;
            // iTween.PunchScale(gameObject, new Vector3(50,50,50), 0.6f);
            // Effet de recul du personnage lors de la collision
            iTween.PunchPosition(gameObject, Vector3.back * 2, 0.5f);
            // Joue le son hurtSound
            audioSource.PlayOneShot(hurtSound);
            // Coroutine qui fait patienter le joueur avant le prochain son de collision
            StartCoroutine("ResetInvincible");
        }
    }

    IEnumerator TimeForHurtSound()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(1);
    }

    IEnumerator ResetInstantiate()
    {
        yield return new WaitForSeconds(0.8f);
        canInstantiate = true;
    }

    IEnumerator ResetInvincible()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            renderer.enabled = !renderer.enabled;
        }
        yield return new WaitForSeconds(0.2f);
        renderer.enabled = true;
        isInvincible = false;
    }
}
