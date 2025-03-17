using UnityEngine;

public class barraManaUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image manaImagen;

    public void actualizarMana(disparo manaScript)
    {
        manaImagen.fillAmount = manaScript.porcentajeMana;

    }
}
