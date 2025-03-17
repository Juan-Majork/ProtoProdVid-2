using UnityEngine;

public class comportamientoWater : MonoBehaviour, comportaminetoDeColeccionables
{
    [SerializeField] private float manaRegen;

    public void coleccionado(GameObject jugador)
    {
        jugador.GetComponent<disparo>().recibirMana(manaRegen);

        jugador.GetComponent<disparo>().rockAttack = false;
        jugador.GetComponent<disparo>().fireAttack = false;
        jugador.GetComponent<disparo>().waterAttack = true;

    }
}
