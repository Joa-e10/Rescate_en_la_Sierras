using System;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : Characters
{
    //Declaracion de las variables que solo utilizaran los enemigos.
    protected float detectionRadius = 10;
    protected Vector2 movement;
    [SerializeField] protected Transform _player;
    protected NavMeshAgent agent;
    public GameObject bulletEnemy;
    protected float distanceToPlayer;
    protected float cooldown = 0;
    protected bool onCooldown = false;

    void Start()
    {

    }


    protected abstract void moveEnemy();

    protected abstract void Attack();

    protected override void die()
    {
       //pawner.SetAlive(_alive);   
        if (_alive == false) //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.
        {
            
            Destroy(gameObject);
        }
    }
}

