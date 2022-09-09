using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Variable de vitesse de mouvement
    public float jumpForce; // Variable de force de saut
    public float gravity; // Variable de taux de gravité
    public static PlayerController playerController;
    public CharacterController characterController; // Référence à ce component dans Unity
    public Animator animator; // Référence à ce component dans Unity
    public Vector3 moveDirection; // Les 3 axes, x, y, z
    private bool isWalking = false;

    private void Awake()
    {
        playerController = this;
    }

    private void Start() // Effective au lancement
    {
        animator = GetComponent<Animator>(); // Attribution de l'animator de l'élément porteur du script
        characterController = GetComponent<CharacterController>(); // Attribution du CharacterController de l'élément porteur du script
    }

    void Update() // Effective à chaque frame
    {
        // moveDirection = la valeur de l'input sur l'axe horizontal et vertical * la vitesse de mouvement 
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        
        if (Input.GetButtonDown("Jump") && characterController.isGrounded) // Check de la touche saut et au sol
        {
            moveDirection.y = jumpForce; // Attribution de la valeur du jump au mouvement vers le haut
        }
        
        if (moveDirection.x != 0 || moveDirection.z != 0) // Si le personnage n'est pas statique
        {
            isWalking = true;
            // La rotation actuelle du personnage sera égale à la transition entre la rotation actuelle et la prochaine suivant la direction donnée ainsi que l'intensité sur les inputs
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), 0.15f);
        }
        else
        {
            isWalking = false;
        }
        
        animator.SetBool("IsWalking", isWalking);

        moveDirection.y -= gravity * Time.deltaTime; // Force du déplacement sur l'axe y moins la gravité
        characterController.Move(moveDirection * Time.deltaTime); // Attribution de la variable de direction de mouvement à la méthode move
    }
}
