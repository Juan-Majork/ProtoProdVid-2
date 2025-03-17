using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropeoDeColeccionables : MonoBehaviour
{
    [SerializeField] private float posibilidadDeDropeo;
    [SerializeField] private int item;

    private spawnerDeColeccionables spawner;

    private void Awake()
    {
        spawner = FindAnyObjectByType<spawnerDeColeccionables>();
    }

    public void dropeoRandomizado()
    {
        float random = Random.Range(0f, 1f);

        if (posibilidadDeDropeo >= random)
        {
            spawner.spawnearColeccionables(transform.position, item);
        }
    }
}
