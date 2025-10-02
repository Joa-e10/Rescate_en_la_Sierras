using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy : Characters
{
    //Declaracion de las variables que solo utilizaran los enemigos.
    protected float detectionRadius = 6.0f;
    protected Vector2 movement;
    protected Transform _player;
    protected float distanceToPlayer;
    protected float cooldown = 0;
    protected bool onCooldown = false;
     
    void Start()
    {
       
    }


    protected void moveEnemy()
    {
        
            distanceToPlayer = Vector2.Distance(transform.position, _player.position); // Tomamos el total de la distancia que tiene el objeto del player.
            if (distanceToPlayer < detectionRadius && distanceToPlayer >= 3) // Condicional donde comparamos si la distancia total hacia el player es menor a el rango del objeto.
            {
                Vector2 direccion = (_player.position - transform.position).normalized; // Declaracion para mover el objeto en relacion a la posicion del player.

                movement = new Vector2(direccion.x, direccion.y); // Declaracion de la direcciones a las que se movera cuando detecte al player.
            }
            else // Si no, el objeto no se movera.
            {
                movement = Vector2.zero;
            }
        
        _rb.linearVelocity = movement * speed; // Generamos el movimiento del objeto.
    }


    protected void Attack()
    {
        
        if (distanceToPlayer <= 3 && onCooldown == false) // Si se cumplen las 2 condiciones el enemigo puede atacar.
        {
            Debug.Log("ENTRO");
            attacking = true; // Activamos ataque.
            animator.SetBool("attacking", attacking); // Activa la animacion de ataque
            Debug.Log("EL ENEMIGO ATACAAA!!");

            
            onCooldown = true; // Activamos cooldown


        }

        
        if (onCooldown) // Si cooldown esta activo empieza el conteo del cooldown.
        {
            Debug.Log("Arranco el cooldown");
            cooldown = cooldown + Time.deltaTime;
            animator.SetBool("attacking", attacking); // Desactivamos la animacion de ataque.

            if (cooldown >= 2f) // Si cooldown es mayor o igual a 2
            {
                Debug.Log("entro2");
                onCooldown = false; //Desactivamos cooldown.

                cooldown = 0;// Reiniciamos el tiempo del cooldown para que el enemigo pueda atacar.
                Debug.Log("Se restauro el cooldown");
            }
        }
    }

    void Update()
    {
        Debug.Log("Distancia del player" + distanceToPlayer);
        Debug.Log($"Vida total: {GetLives()}");
    }

    protected override void die()
    {
        if (_alive == false) //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.
        {

             Destroy(gameObject);

            }
        }
    }

