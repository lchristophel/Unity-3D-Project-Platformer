using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Le transform de la cible à filmer
    public Vector3 offset; // Le décalage de la caméra par rapport au personnage

    void Start()
    {
        // Décalage égal la position de la cible moins la position du porteur du script
        offset = target.position - transform.position;
    }

    void Update()
    {
        // Position de la caméra égale la position de la cible moins le décalage
        transform.position = target.position - offset;
    }
}
