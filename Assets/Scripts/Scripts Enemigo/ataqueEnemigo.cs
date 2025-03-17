using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueEnemigo : MonoBehaviour
{
    [SerializeField] private float da�o;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            var controlVida = collision.gameObject.GetComponent<controladorVida>();  
            controlVida.recibirDa�o(da�o);
        }

    }
}
