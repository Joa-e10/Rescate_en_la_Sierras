/*public static event Action OnDoorUnlocked;
    private void OnDisable()
    {
       OnDoorUnlocked?.Invoke();
        _door.SetAlive(false);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }*/
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FinalBoss : Enemy
{
    private Vector2 _lastBullet;
    Vector2 directionBullet;
    private Transform gun;
    private int amountBullet;
    private ExitDoor _door;
    public GameObject _bosslife;

    //Update variables:
    private bool _reloading;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("Player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        gun = GameObject.Find("gunController(2)").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "gunController(2)".
        //_door = GameObject.Find("doorExit").GetComponent<ExitDoor>();
        detectionRadius = 20.0f;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        moveEnemy();
        Attack();
        //_door.SetAlive(true);

        if (_alive != true)
        {
            die();
        }
    }


    protected override void moveEnemy()
    {
        distanceToPlayer = Vector2.Distance(transform.position, _player.position);


        if (distanceToPlayer < detectionRadius)
        {
            if (lives > 5)
            {
                if (distanceToPlayer > 4)
                {
                    agent.isStopped = false;
                    Debug.Log("Esta persiguiendo al player");
                    bool agentdestination = agent.SetDestination(_player.transform.position);
                    Debug.Log("El objetivo actual es verdadero?: " + agentdestination);
                    //_bosslife.SetActive(true);
                }
                else
                {
                    Debug.Log("Esta ignorando al player");
                    agent.isStopped = true;
                }
            }
            else
            {
                agent.isStopped = true;
            }

        }
    }


    public void AttackMelee()
    {
        if (distanceToPlayer <= 4)
        {
            if (attacking == false && _reloading == false)
            {
                Debug.Log("ENTRO A ATACAR EL ENEMY");
                attacking = true;
                _reloading = true;
                // animator.SetBool("Attacking", attacking); // Activa la animacion de ataque.
            }
        }

    }

    public void AttackDistance()
    {
        if (distanceToPlayer <= 6)
        {

            if (shooting == false && _reloading == false)
            {

                Debug.Log("El BOSS esta disparando");
                shooting = true;
                _reloading = true;
                Vector2 direction = (_player.position - transform.position);
                _lastBullet = direction;
                GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);
                BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();
                bulletComponent.setDirectionBullet(_lastBullet);

            }
        }
    }

    protected override void Attack()
    {
        //Si la distancia del jugador es menor o igual a 10 puede atacar.
        if (distanceToPlayer <= detectionRadius)
        {
            if (lives > 5)
            {
                AttackMelee();
                StartCoroutine(AttackWithCooldown());
            }
            else
            {
                StartCoroutine(ShootWithCooldown());
            }
        }
    }

    protected IEnumerator ShootWithCooldown()
    {
        if (_reloading == false)
        {
            AttackDistance();
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            _reloading = false;
            shooting = false;
        }

    }

    protected IEnumerator AttackWithCooldown()
    {
        yield return new WaitForSeconds(1f);
        _reloading = false;
        attacking = false;
    }



    //public static event Action OnDoorUnlocked;
    private void OnDisable()
    {
        //OnDoorUnlocked?.Invoke();
        //_door.SetAlive(false);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
