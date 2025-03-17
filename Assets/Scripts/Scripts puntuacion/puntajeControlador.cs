using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class puntajeControlador : MonoBehaviour
{
    public UnityEvent cambioPuntaje;

    public int puntaje { get; private set; }

    public void sumarPuntaje(int sumar)
    {
        puntaje += sumar;

        cambioPuntaje.Invoke();
    }
}
