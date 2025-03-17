using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerDeColeccionables : MonoBehaviour
{
    [SerializeField] private List<GameObject> coleccionablesPrefaps;

    public void spawnearColeccionables(Vector2 posicion, int selecItem)
    {
        var seleccionarColeccionables = coleccionablesPrefaps[selecItem];

        Instantiate(seleccionarColeccionables, posicion, Quaternion.identity);
    }
}
