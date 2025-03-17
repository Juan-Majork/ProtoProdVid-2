using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirEnemigo : MonoBehaviour
{
    public void destruirse(float delay)
    {
        Destroy(gameObject, delay);
    }
}
