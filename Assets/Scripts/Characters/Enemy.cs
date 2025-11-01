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

          /*  distanceToPlayer = Vector2.Distance(transform.position, _player.position); // Tomamos el total de la distancia que tiene el objeto del player.
            if (distanceToPlayer < detectionRadius && distanceToPlayer >= 3) // Condicional donde comparamos si la distancia total hacia el player es menor a el rango del objeto.
            {
                Vector2 direction = (_player.position - transform.position).normalized; // Declaracion para mover el objeto en relacion a la posicion del player.

                movement = new Vector2(direction.x, direction.y); // Declaracion de la direcciones a las que se movera cuando detecte al player.
            }
            else // Si no, el objeto no se movera.
            {
                movement = Vector2.zero;
            }

            _rb.linearVelocity = movement * speed; // Generamos el movimiento del objeto.*/
    


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

