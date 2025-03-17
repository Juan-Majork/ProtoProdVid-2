using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamientoDeCuras : MonoBehaviour, comportaminetoDeColeccionables
{
    [SerializeField] private float vidaCurada;

    public void coleccionado(GameObject jugador)
    {
        jugador.GetComponent<controladorVida>().agregarVida(vidaCurada);
    }
}
