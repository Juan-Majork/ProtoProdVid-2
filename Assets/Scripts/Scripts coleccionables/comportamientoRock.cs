using UnityEngine;

public class comportamientoRock : MonoBehaviour, comportaminetoDeColeccionables
{
    [SerializeField] private float manaRegen;

    public void coleccionado(GameObject jugador)
    {
        jugador.GetComponent<disparo>().recibirMana(manaRegen);

        jugador.GetComponent<disparo>().rockAttack = true;
        jugador.GetComponent<disparo>().fireAttack = false;
        jugador.GetComponent<disparo>().waterAttack = false;
        
    }
}
