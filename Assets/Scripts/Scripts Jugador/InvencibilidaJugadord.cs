using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvencibilidaJugadord : MonoBehaviour
{
    [SerializeField] private float duracion;
    [SerializeField] Color flashColor;
    [SerializeField] private int flasheos;

    private invencibilidadControl invenControl;

    private void Awake()
    {
        invenControl = GetComponent<invencibilidadControl>();
    }

    public void actInvencibilidad()
    {
        invenControl.serInvencible(duracion, flashColor, flasheos);
    }
}
