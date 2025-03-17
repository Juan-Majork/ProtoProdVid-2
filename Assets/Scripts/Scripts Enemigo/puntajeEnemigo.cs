using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntajeEnemigo : MonoBehaviour
{
    [SerializeField] private int puntaje;

    private puntajeControlador puntajeControl;

    private void Awake()
    {
        puntajeControl = FindAnyObjectByType<puntajeControlador>();
    }

    public void localizarPuntaje()
    {
        puntajeControl.sumarPuntaje(puntaje);
    }
}
