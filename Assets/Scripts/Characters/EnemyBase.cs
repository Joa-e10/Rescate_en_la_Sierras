using System.Collections;
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


                agent.SetDestination(_player.position);
            }

        }
        
    }

    protected override void Attack()
    {

        // Si se cumplen las 2 condiciones el enemigo puede atacar.
        if (distanceToPlayer <= 4 && !attacking)
        {
            StartCoroutine(AttackWithCooldown());
        }

    }

    void Update()
    {
        moveEnemy();
        Attack();
    }

    protected IEnumerator AttackWithCooldown()
    {
        Debug.Log("ENTRO A ATACAR EL ENEMY");
        attacking = true;
        animator.SetBool("attacking", attacking); // Activa la animacion de ataque

        yield return new WaitForSeconds(2f);
        Debug.Log("Salio de la corrutina");
        attacking = false;
        animator.SetBool("attacking", attacking);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
