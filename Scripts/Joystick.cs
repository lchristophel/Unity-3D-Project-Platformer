using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Vector3 direction;
    public Transform Player;
    public float speed;
    private bool touchStart = false;
    private Vector2 startPoint, endPoint, initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        touchStart = true;
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        touchStart = false;
    }

    private void Update()
    {
        if(touchStart)
        {
            Vector2 offset = endPoint - startPoint;
            direction = new Vector3(Input.GetAxis("Horizontal") * speed, direction.y, Input.GetAxis("Vertical") * speed);
            MovePlayer(direction);
        }
    }

    private void MovePlayer(Vector3 dir)
    {
        Player.Translate(dir * Time.deltaTime * speed);
    }
}
