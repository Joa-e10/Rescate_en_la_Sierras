using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PositionReference : MonoBehaviour
{
    //Declaracion de las variables que solo utilizaran los enemigos.
    protected float detectionRadius = 10;
    protected Vector2 movement;
    protected NavMeshAgent agent;
    public GameObject bulletEnemy;
    protected float distanceToEnemy;
    private Rigidbody2D _rb;
    private Transform _boss;
    private float speed = 5;
    private float _detectionRadius = 10.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _boss = GameObject.Find("boss").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
    }

    private void Update()
    {
        ReferenceMove();
    }

    private void ReferenceMove()
    {
        distanceToEnemy = Vector2.Distance(transform.position, _boss.position); // Tomamos el total de la distancia que tiene el objeto del player.
        if (distanceToEnemy < detectionRadius && distanceToEnemy >= 3) // Condicional donde comparamos si la distancia total hacia el player es menor a el rango del objeto.
        {
            Vector2 direction = (_boss.position - transform.position).normalized; // Declaracion para mover el objeto en relacion a la posicion del player.

            movement = new Vector2(direction.x, direction.y); // Declaracion de la direcciones a las que se movera cuando detecte al player.
        }
        else if(distanceToEnemy < 3) // Si no, el objeto no se movera.
        {
            Vector3 direction = (transform.position - _boss.position);
            Vector3 newDirection = transform.position + direction.normalized * 3f;
            movement = new Vector2(newDirection.x, newDirection.y);
        }

        _rb.linearVelocity = movement * speed; // Generamos el movimiento del objeto.

    }
}
   
