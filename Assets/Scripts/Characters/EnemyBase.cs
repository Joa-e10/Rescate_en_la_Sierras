using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Enemy
{
    private Vector2 directionEnemy;
    private int _attackCounter = 0;

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
                    moving = true;
                    animator.SetBool("Moving", moving);
                    agent.SetDestination(_player.position);
                    directionEnemy = (agent.steeringTarget - transform.position).normalized;

                    animator.SetFloat("Vertical", directionEnemy.y);
                    animator.SetFloat("Horizontal", directionEnemy.x);

                    Debug.Log("la nueva direccion devuelve: " + directionEnemy);

                    if (directionEnemy.x > 0)
                    {
                        _directionIdle = directionEnemy.normalized;
                    }
                    else if (directionEnemy.x < 0)
                    {
                        _directionIdle = directionEnemy.normalized;
                    }
                    else if (directionEnemy.y > 0)
                    {
                        _directionIdle = directionEnemy.normalized;
                    }
                    else if (directionEnemy.y < 0)
                    {
                        _directionIdle = directionEnemy.normalized;
                    }

                }
                else
                {
                    moving = false;
                    animator.SetBool("Moving", moving);
                }

        }
        
    }

    protected override void Attack()
    {

        // Si se cumplen las 2 condiciones el enemigo puede atacar.
        if (distanceToPlayer <= 3 && !attacking)
        {
            StartCoroutine(AttackWithCooldown());
        }

    }

    void Update()
    {
        moveEnemy();
        if (!moving)
        {

            animator.SetFloat("LastX", _directionIdle.x);
            animator.SetFloat("LastY", _directionIdle.y);

        }

        Attack();
    }

    protected IEnumerator AttackWithCooldown()
    {
        
        if (attacking == false)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Entro de la corrutina donde ataca");
            attacking = true;
            animator.SetBool("Attacking", attacking);

            yield return new WaitForSeconds(1.0f);
            attacking = false;
            animator.SetBool("Attacking", attacking);
            // Debug.Log("Salio de la corrutina donde ataca");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
