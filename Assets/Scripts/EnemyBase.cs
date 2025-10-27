using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Enemy
{

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = 3;
    }

    protected override void moveEnemy()
    {
        if (!attacking)
        {
            distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer < detectionRadius)
            {

                Debug.Log("la nueva direccion devuelve: " + distanceToPlayer);
                agent.SetDestination(_player.position);

            }

        }

    }

    protected override void Attack()
    {

        // Si se cumplen las 2 condiciones el enemigo puede atacar.
        if (distanceToPlayer <= 3 && onCooldown == false)
        {
            attacking = true;
            animator.SetBool("attacking", attacking);
            Debug.Log("EL ENEMIGO ATACAAA!!");


            onCooldown = true; // Se activa el "cooldown" 


        }

        // Si el cooldown esta activo empieza el conteo del mismo.
        if (onCooldown)
        {
            Debug.Log("Arranco el cooldown");
            cooldown = cooldown + Time.deltaTime;
            animator.SetBool("attacking", attacking);

            //Si el cooldown llega a 2 o es mayor se desactiva y se resetea el contador.
            if (cooldown >= 2f)
            {

                onCooldown = false; 

                cooldown = 0;
                Debug.Log("Se restauro el cooldown");
            }
        }

    }

    void Update()
    {
        moveEnemy();
        Attack();
        //Debug.Log($"Vida total: {GetLives()}");
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
