using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraVidaUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image vidaImagen;

    public void actualizarVida(controladorVida controlador)
    {
        vidaImagen.fillAmount = controlador.porcentajeVida;

    }
}
