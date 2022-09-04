using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int nbCoins = 0;
    public GameObject pickupEffect;
    public GameObject mobEffect;
    private bool canInstantiate = true;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Camera1")
        {
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
            camera3.SetActive(true);
        }

        if (other.gameObject.tag == "Camera4")
        {
            camera4.SetActive(true);
        }

        if (other.gameObject.tag == "Camera5")
        {
            camera5.SetActive(true);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision) // Check la collision, plus adapté pour le characterController
    {
        // Si la collision à le tag Coin
        if (collision.gameObject.tag == "Coin")
        {
            GameObject go = Instantiate(pickupEffect, collision.transform.position, Quaternion.identity); 
            Destroy(go, 0.5f);
            // Détruire le gameObject de la collision, donc le coin
            Destroy(collision.gameObject);
            // Incrémenter nbCoins
            nbCoins++;
        }
        // Si la collision à le tag Mob
        if (collision.gameObject.tag == "Mob" && canInstantiate)
        {
            canInstantiate = false;
            GameObject go = Instantiate(mobEffect, collision.transform.position, Quaternion.identity);
            Destroy(go, 0.6f);
            // Détruire le gameObject de la collision, donc le mob après 0.2 seconde
            Destroy(collision.gameObject.transform.parent.gameObject, 0.2f);
            StartCoroutine("ResetInstantiate");
        }
        // Si le tag de la collision est Hurt
        if (collision.gameObject.tag == "Hurt")
        {
            Debug.Log("Aie !");
        }
    }

    IEnumerator ResetInstantiate()
    {
        yield return new WaitForSeconds(0.8f);
        canInstantiate = true;
    }

    // private void OnCollisionEnter(Collision collision){}
}
