using UnityEngine;

public class fireController : MonoBehaviour
{
    [SerializeField] private float da�o;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<movimientoEnemigo>())
        {
            controladorVida controlVida = collision.GetComponent<controladorVida>();
            controlVida.recibirDa�o(da�o);


        }
    }
}
