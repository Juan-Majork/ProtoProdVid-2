using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemigo : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D rb;
    private playerAwareness playerAwarenessControl;
    private Camera cam;

    private Vector2 targetDirection;

    private float changeDirection;
    private float screenBorder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarenessControl = GetComponent<playerAwareness>();
        cam = Camera.main;

        targetDirection = transform.up;
        screenBorder = -20f;

    }

    private void FixedUpdate()
    {
        updateTargetDirection();
        rotateTowardsTargets();
        setVelocity();
    }


    private void updateTargetDirection()
    {
        randomDirection();
        handleTarget();
        handleOffScreen();
    }

    private void randomDirection()
    {
        changeDirection -= Time.deltaTime;

        if(changeDirection <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirection = Random.Range(1f, 5f);
        }
    }

    private void handleTarget()
    {
        if (playerAwarenessControl.awarePlayer)
        {
            targetDirection = playerAwarenessControl.directionPlayer;
        }
    }

    private void handleOffScreen()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && targetDirection.x < 0) ||
            (screenPosition.x > cam.pixelWidth - screenBorder && targetDirection.x > 0))
        {
            targetDirection = new Vector2(-targetDirection.x, targetDirection.y);
        }

        if ((screenPosition.y < screenBorder && targetDirection.y < 0) ||
            (screenPosition.y > cam.pixelHeight - screenBorder && targetDirection.y > 0))
        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
        }
    }

    private void rotateTowardsTargets()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 

        rb.SetRotation(rotation);
    }
    private void setVelocity()
    {
        rb.linearVelocity = transform.up * speed;
    }
}
