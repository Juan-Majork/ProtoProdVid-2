using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();    

    }

    public IEnumerator tiempoFlash(float duracion, Color flashColor, int flasheos)
    {
        Color colorInicial = spriteRenderer.color;

        float elapsDuracion = 0;
        float elapsePorcentaje = 0;

        while (elapsDuracion < duracion) 
        {
            elapsDuracion += Time.deltaTime;
            elapsePorcentaje = elapsDuracion / duracion;

            if (elapsePorcentaje > 1)
            {
                elapsePorcentaje = 1;
            }

            float pingPongPorcentaje = Mathf.PingPong(elapsePorcentaje * 2 * flasheos, 1);
            spriteRenderer.color = Color.Lerp(colorInicial, flashColor, pingPongPorcentaje);

            yield return null;
        }

    }
}
