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
    private bool _isMove;
    private Transform _positionShoot;
    [SerializeField]private int[] _listAngle = new int[3];

    //Update variables:
    private bool _reloading;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("Player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        gun = GameObject.Find("gunController(2)").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "gunController(2)".
        _positionShoot = GameObject.Find("PositionShoot").GetComponent<Transform>();
        detectionRadius = 20.0f;
        lives = 4;
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

        if (attacking == false && shooting == false)
        {
            if (distanceToPlayer < detectionRadius)
            {
                _isMove = true;
                if (lives > 5)
                {
                    if (distanceToPlayer > 3)
                    {
                        agent.isStopped = false;
                        Debug.Log("Esta persiguiendo al player");
                        agent.SetDestination(_player.transform.position); agent.SetDestination(_player.transform.position);

                        _bosslife.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Esta ignorando al player");
                        agent.isStopped = true;
                        _isMove = false;
                    }
                }
                else
                {
                    agent.isStopped = false;
                    agent.SetDestination(_positionShoot.transform.position);
                }
            }
        }
        else 
        {
            agent.isStopped = true;
            _isMove = false;
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
                StartCoroutine(AttackWithCooldown());
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

                 Vector2 direction = (_player.position - transform.position);

                GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);

                BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();

                bulletComponent.setDirectionBullet(direction);
                _reloading = true;
                StartCoroutine(ShootWithCooldown());
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
                
            }
            else
            {
                AttackDistance();
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
