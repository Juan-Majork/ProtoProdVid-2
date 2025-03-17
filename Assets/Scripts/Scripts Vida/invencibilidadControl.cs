using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invencibilidadControl : MonoBehaviour
{
    private controladorVida controlVida;
    private spriteFlash flash;

    private void Awake()
    {
        controlVida = GetComponent<controladorVida>();
        flash = GetComponent<spriteFlash>();
    }

    public void serInvencible(float durecion, Color flashColor, int flasheos)
    {
        StartCoroutine(tiempoInvencibilidad(durecion, flashColor, flasheos));
    }

    private IEnumerator tiempoInvencibilidad(float durecion, Color flashColor, int flasheos)
    { 
        controlVida.invencible = true;
        yield return flash. tiempoFlash (durecion, flashColor, flasheos);
        controlVida.invencible = false;
    
    }

}
