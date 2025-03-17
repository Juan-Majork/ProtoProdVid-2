using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class disparo : MonoBehaviour
{
    [SerializeField] private GameObject balaPrefap;
    [SerializeField] private GameObject firePrefap;
    [SerializeField] private GameObject waterPrefap;
    [SerializeField] private GameObject rockPrefap;
    [SerializeField] private Transform arma;
    [SerializeField] private Transform water;
    [SerializeField] private Transform rock;

    [SerializeField] private float mana;
    [SerializeField] private float maxMana;

    public float porcentajeMana
    {
        get
        {
            return mana / maxMana;
        }
    }

    private float speedBala;
    private float waitShoot;
    private float lastShoot;

    private bool fireContinue;

    public bool baseAttack;
    public bool fireAttack;
    public bool waterAttack;
    public bool rockAttack;

    private void Awake()
    {
        baseAttack = true;

        fireAttack = false;
        waterAttack = false;    
        rockAttack = false;
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            fireContinue = true;
        }
        else
        {
            fireContinue= false;
        }

        if (fireContinue)
        {

            if (baseAttack)
            {
                speedBala = 8f;
                waitShoot = 0.25f;
                float timeSinceShoot = Time.time - lastShoot;

                if (timeSinceShoot >= waitShoot)
                {
                    disparar(balaPrefap, arma);
                    lastShoot = Time.time;
                }
            }
            if (fireAttack)
            {

                if (mana > 0)
                {
                    firePrefap.SetActive(true);
                }
                else
                {
                    firePrefap.SetActive(false);
                    fireAttack = false;
                }
            }
            if (waterAttack)
            {
                speedBala = 20f;
                waitShoot = 0.25f;

                if (mana > 0)
                {
                    float timeSinceShoot = Time.time - lastShoot;

                    if (timeSinceShoot >= waitShoot)
                    {
                        disparar(waterPrefap, water);
                        lastShoot = Time.time;
                    }
                }
                else
                {
                    waterAttack = false;
                }
            }
            if (rockAttack)
            {
                speedBala = 4f;
                waitShoot = 1f;

                if (mana > 0)
                {
                    float timeSinceShoot = Time.time - lastShoot;

                    if(timeSinceShoot >= waitShoot)
                    {
                        disparar(rockPrefap, rock);
                        lastShoot = Time.time;
                    }
                }
                else
                {
                    rockAttack = false;
                }
            }
            
        }

    }

    private void FixedUpdate()
    {
        if (mana > 0)
        {
            mana -= Time.deltaTime;
            baseAttack = false;

            cambioMana.Invoke();
        }
        else
        {
            baseAttack = true;

            if (mana < 0)
            {
                mana = 0;   
            }

            cambioMana.Invoke();

            if (fireAttack)
            {
                fireAttack = false;
            }
            if (waterAttack)
            {
                waterAttack = false;
            }
            if (rockAttack)
            {
                rockAttack = false;
            }

        }

        if (!fireAttack)
        {
            firePrefap.SetActive(false);
        }

    }

    private void disparar(GameObject attackPrefap, Transform spawnPoint)
    {
        GameObject bala = Instantiate(attackPrefap, spawnPoint.position, spawnPoint.rotation);  
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.linearVelocity = speedBala * transform.up;
    }

    public void recibirMana(float recharge)
    {
        if (mana == maxMana && baseAttack == false) 
        { 
            return; 
        }

        mana += recharge;

        if (mana > maxMana)
        {
            mana = maxMana;
        }

        cambioMana.Invoke();
    }

    public UnityEvent cambioMana;
}
