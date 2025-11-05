using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FinalBoss : Enemy
{
    private Vector2 _lastBullet;
    Vector2 directionBullet;
    private Transform gun;
    private int amountBullet;
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        gun = GameObject.Find("gunController(2)").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "gunController(2)".
        detectionRadius = 10.0f;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    void Update()
    {
            moveEnemy();
            Attack();
    }


    protected override void moveEnemy()
    {
        distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        agent.speed = 4;

        if (lives <= 5)
        {
          
            if (distanceToPlayer < detectionRadius)
            {

                if (distanceToPlayer <= 5)
                {
                    Vector3 direction = (transform.position - _player.position);
                    Vector3 newDirection = transform.position + direction.normalized * 2f;
                    agent.SetDestination(newDirection);
                    
                }

            }
            else 
            {

                //Debug.Log("la nueva direccion devuelve: " + distanceToPlayer);
                agent.SetDestination(_player.position);

            }

        }
        else
        {

            if (shooting || attacking)
            {
                Debug.Log("Se No esta moviendo y esta atacando o disparando");
            }
            else
            {
                Debug.Log("Se esta moviendo");
                if (distanceToPlayer < detectionRadius)
                {
                    if (distanceToPlayer > 2)
                    {
                        agent.SetDestination(_player.transform.position);

                    }

                }

            }

        }

        
            
    }

    //agent.isStopped = true;
    protected override void Attack() 
    {
        //Si la distancia del jugador es menor o igual a 10 puede atacar.
        if (distanceToPlayer <= detectionRadius)
        {
            if (distanceToPlayer <= 4) 
            {
                if (!attacking && shooting == false)
                {
                    StartCoroutine(AttackWithCooldown());
                }
            }

            //LOGICA DEL DISPARO.
            if (lives <= 5) 
            {
                // Si se cumplen las 2 condiciones el enemigo puede disparar.

                if (!shooting && attacking == false)
                {
                    StartCoroutine(ShootWithCooldown());
                }
            }
        }
    }

    protected IEnumerator ShootWithCooldown()
    {
        shooting = true;
        Debug.Log("El enemigo esta disparando");

        Vector2 direction = (_player.position - transform.position);
        _lastBullet = direction;
        GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);
        BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();
        bulletComponent.setDirectionBullet(_lastBullet);
        animator.SetBool("Shooting", shooting);
        amountBullet++;

        yield return new WaitForSeconds(1.5f);

        shooting = false;
        animator.SetBool("Shooting", shooting);
    }

    protected IEnumerator AttackWithCooldown()
    {
        Debug.Log("ENTRO A ATACAR EL ENEMY");
        attacking = true;
        animator.SetBool("Attacking", attacking); // Activa la animacion de ataque

        yield return new WaitForSeconds(2f);
        Debug.Log("Salio de la corrutina");
        attacking = false;
        animator.SetBool("Attacking", attacking);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
