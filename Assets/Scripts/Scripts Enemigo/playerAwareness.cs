using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAwareness : MonoBehaviour
{
    public bool awarePlayer {  get; private set; }  
    public Vector2 directionPlayer {  get; private set; }

    [SerializeField]  private float playerAwarnessDistance;
    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<movimiento>().transform;
    }

    private void FixedUpdate()
    {
        Vector2 enemyToPlaayer = player.position - transform.position;
        directionPlayer = enemyToPlaayer.normalized;

        if(enemyToPlaayer.magnitude <= playerAwarnessDistance)
        {
            awarePlayer = true;
        }
        else
        {
            awarePlayer = false;
        }
    }
}
