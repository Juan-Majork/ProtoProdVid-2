using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mostrarPuntaje : MonoBehaviour
{
    private TMP_Text textoPuntaje;

    private void Awake()
    {
        textoPuntaje = GetComponent<TMP_Text>();    
    }

    public void actualizarPuntaje (puntajeControlador puntajeControlador)
    {
        textoPuntaje.text = $"Puntaje: {puntajeControlador.puntaje}";
    }
}
