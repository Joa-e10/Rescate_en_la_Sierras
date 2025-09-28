using UnityEngine;

public class Enemy : Characters
{
    //Declaracion de las variables que solo utilizaran los enemigos.
    protected float detectionRadius = 5.0f;
    protected Vector2 movement;
    protected Transform _player;
    void Start()
    {

    }

    protected void moveEnemy()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position); // Tomamos el total de la distancia que tiene el objeto del player.
        if (distanceToPlayer < detectionRadius) // Condicional donde comparamos si la distancia total hacia el player es menor a el rango del objeto.
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
    void Update()
    {

        Debug.Log($"Vida total: {GetLives()}");
    }
}

