using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigo;

    [SerializeField] private float miniTiempoSpawn;
    [SerializeField] private float maximoTiempoSpawn;
    private float tiempoHastaSpawnear;

    private void Awake()
    {
        setearTiempoDeSpawn();
    }

    private void Update()
    {
        tiempoHastaSpawnear -= Time.deltaTime;

        if (tiempoHastaSpawnear <= 0)
        {
            int selectEnemy = Random.Range(0, enemigo.Length);
            Instantiate(enemigo[selectEnemy], transform.position, Quaternion.identity);
            setearTiempoDeSpawn();
        }
    }

    private void setearTiempoDeSpawn()
    {
        tiempoHastaSpawnear = Random.Range(miniTiempoSpawn, maximoTiempoSpawn);
    }
}
