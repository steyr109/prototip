using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChar : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private PlayerController playerController;

    public Joystick joystick;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveSpeed = playerController.speed;
        // ѕолучаем направление движени€ от осей горизонтали и вертикали
        moveDirection.x = joystick.Horizontal;
        moveDirection.y = joystick.Vertical;

        // ѕоворачиваем персонаж в сторону движени€
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void FixedUpdate()
    {
        // ƒвигаем персонаж
        rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
