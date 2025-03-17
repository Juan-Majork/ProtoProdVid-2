using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coleccionable : MonoBehaviour
{
    private comportaminetoDeColeccionables coleccionablesComportamiento;

    private void Awake()
    {
        coleccionablesComportamiento = GetComponent<comportaminetoDeColeccionables>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var jugador = collision.GetComponent<movimiento>();

        if(jugador != null)
        {
            coleccionablesComportamiento.coleccionado(jugador.gameObject);
            Destroy(gameObject);
        }
    }
}
