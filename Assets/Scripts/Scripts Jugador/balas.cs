using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private float daño;
    [SerializeField] private float actualTime;
    [SerializeField] private float destroyTime;
    [SerializeField] private bool onCollsionDestroy;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        destroyBala();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<movimientoEnemigo>()) 
        { 
            controladorVida controlVida = collision.GetComponent<controladorVida>();
            controlVida.recibirDaño(daño);

            if (onCollsionDestroy)
            {
                Destroy(gameObject);
            }
        }
    }

    private void destroyBala()
    {
        actualTime += Time.deltaTime;

        if(actualTime > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}

