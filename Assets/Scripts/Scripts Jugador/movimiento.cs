using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;
    private Animator animator;

    private Vector2 moveInput;
    private Vector2 smoothMoveInput;
    private Vector2 smoothMoveInputVelocity;

    private float rotationSpeed;
    private float speed;
    private float screenBorder;

    private void Awake()
    {
        rotationSpeed = 720f;
        speed = 4.5f;
        screenBorder = 20f;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = Camera.main;

    }

    private void FixedUpdate()
    {
        rotationDirectionInput();
        setPlayerVelocity();
        elegirAnimacion();
    }

    private void elegirAnimacion()
    {
        bool enMovimiento = moveInput != Vector2.zero;
        animator.SetBool("enMovimiento", enMovimiento);
    }

    void setPlayerVelocity()
    {
        smoothMoveInput = Vector2.SmoothDamp(smoothMoveInput, moveInput, ref smoothMoveInputVelocity, 0.1f);

        rb.linearVelocity = smoothMoveInput * speed;

        preventScape();
    }

    private void preventScape()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);    

        if ((screenPosition.x < screenBorder && rb.linearVelocity.x < 0) ||
            (screenPosition.x > cam.pixelWidth - screenBorder && rb.linearVelocity.x > 0))
        {
            rb.linearVelocity = new Vector2 (0, rb.linearVelocity.y);
        }

        if ((screenPosition.y < screenBorder && rb.linearVelocity.y < 0) ||
            (screenPosition.y > cam.pixelHeight - screenBorder && rb.linearVelocity.y > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    private void rotationDirectionInput()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMoveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    }

}
