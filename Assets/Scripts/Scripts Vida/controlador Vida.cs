using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class controladorVida : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximaVida;

    public float porcentajeVida
    {
        get
        {
            return vida / maximaVida;
        }
    }

    public bool invencible { get; set; }

    public void recibirDa�o(float da�o)
    {
        if (vida == 0)
        {
            return;
        }

        if (invencible)
        {
            return;
        }

        vida -= da�o;

        cambioEnVida.Invoke();

        if (vida < 0)
        {
            vida = 0;   
        }

        if (vida == 0) 
        {
            muerte.Invoke();
        }
        else
        {
            onDa�o.Invoke();
        }
    }

    public void agregarVida(float curar)
    {
        if (vida == maximaVida) 
        {
            return;
        }

        vida += curar;

        cambioEnVida.Invoke();

        if (vida > maximaVida)
        {
            vida = maximaVida;
        }
    }

    public UnityEvent muerte;
    public UnityEvent onDa�o;
    public UnityEvent cambioEnVida;

}
