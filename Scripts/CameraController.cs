using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Le transform de la cible à filmer
    public Vector3 offset; // Le décalage de la caméra par rapport au personnage

    void Start()
    {
        offset = target.position - transform.position;
    }

    void Update()
    {
        transform.position = target.position - offset;
    }
}
