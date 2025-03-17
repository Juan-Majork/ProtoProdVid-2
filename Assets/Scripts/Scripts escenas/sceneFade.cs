using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneFade : MonoBehaviour
{
    private Image sceneFadeImagen;

    private void Awake()
    {
        sceneFadeImagen = GetComponent<Image>();    
    }

    public IEnumerator fadeInCourtine(float durecion)
    {
        Color startColor = new Color (sceneFadeImagen.color.r, sceneFadeImagen.color.g, sceneFadeImagen.color.b, 1);
        Color targetColor = new Color(sceneFadeImagen.color.r, sceneFadeImagen.color.g, sceneFadeImagen.color.b, 0);

        yield return fadeCortuine(startColor, targetColor, durecion);

        gameObject.SetActive(false);
    }

    public IEnumerator fadeOutCoroutine(float duracion)
    {
        Color startColor = new Color(sceneFadeImagen.color.r, sceneFadeImagen.color.g, sceneFadeImagen.color.b, 0);
        Color targetColor = new Color(sceneFadeImagen.color.r, sceneFadeImagen.color.g, sceneFadeImagen.color.b, 1);

        gameObject.SetActive(true);
        yield return fadeCortuine (startColor, targetColor, duracion);
    }

    private IEnumerator fadeCortuine(Color colorInicial, Color targetColor, float durecion)
    {
        float elapseTIme = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapseTIme / durecion;
            sceneFadeImagen.color = Color.Lerp(colorInicial, targetColor, elapsedPercentage);

            yield return null;
            elapseTIme += Time.deltaTime;
        }
    }
}
