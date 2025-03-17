using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueEnemigo : MonoBehaviour
{
    [SerializeField] private float daño;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            var controlVida = collision.gameObject.GetComponent<controladorVida>();  
            controlVida.recibirDaño(daño);
        }

    }
}
