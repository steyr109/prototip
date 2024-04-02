using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInputHorizontal;
    private float moveInputVertical;

    private Rigidbody2D rb;
    public Joystick joystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInputHorizontal = joystick.Horizontal;
        moveInputVertical = joystick.Vertical;

        Vector2 movement = new Vector2(moveInputHorizontal, moveInputVertical);
        rb.velocity = movement * speed;

    }
}
