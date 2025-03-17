using UnityEngine;

public class comportamientoFire : MonoBehaviour, comportaminetoDeColeccionables
{
    [SerializeField] private float manaRegen;

    public void coleccionado(GameObject jugador)
    {
        jugador.GetComponent<disparo>().recibirMana(manaRegen);

        jugador.GetComponent<disparo>().rockAttack = false;
        jugador.GetComponent<disparo>().fireAttack = true;
        jugador.GetComponent<disparo>().waterAttack = false;

    }
}
