using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : Enemy
{
    private Vector2 _lastBullet;
    private Vector2 directionBullet;
    private Vector2 directionEnemy;
    private Transform gun;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        gun = GameObject.Find("gunController(1)").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "gunController(1)".

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = 2;
    }

    protected override void moveEnemy()
    {
        if (!shooting)
        {
           /* if (agent.velocity.magnitude <= 0)
            {
                moving = false;
                animator.SetBool("Moving", moving);
            }*/
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
        if (distanceToPlayer < detectionRadius && !shooting)
        {
            StartCoroutine(ShootWithCooldown());
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

        yield return new WaitForSeconds(1.5f);

        shooting = false;
        animator.SetBool("Shooting", shooting);
    }


    void Update()
    {

        if (!moving)
        {

            animator.SetFloat("LastX", _directionIdle.x);
            animator.SetFloat("LastY", _directionIdle.y);

        }
        moveEnemy();

        Attack();
    }
}
