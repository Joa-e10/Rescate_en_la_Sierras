using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FinalBoss : Enemy
{
    private float _cooldownMax;
    private bool onCooldown2 = false;
    private Vector2 _isStill;
    private Vector2 _lastBullet;
    Vector2 directionBullet;
    private Transform gun;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        gun = GameObject.Find("gunController(2)").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "gunController(2)".

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    protected override void moveEnemy()
    {
            Debug.Log("Se esta moviendo");
            distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        agent.speed = 4;
        if (distanceToPlayer < detectionRadius)
            {
                
                agent.SetDestination(_player.transform.position);

            if (distanceToPlayer <= 4) {
                
                agent.speed = 0;
            }

            }
    }

    protected override void Attack() 
    {
        //Si la distancia del jugador es menor o igual a 10 puede atacar.
        if (distanceToPlayer <= 10)
        {

            //Si la distancia del jugador es menor o igual a 3 puede atacar a melee.
            if (distanceToPlayer <= 3)
            {

                // Si se cumplen las 2 condiciones el enemigo puede atacar.
                if (shooting == false && onCooldown == false)
                {
                    Debug.Log("ENTRO A ATACAR EL ENEMY");
                    attacking = true;
                    animator.SetBool("Attacking", attacking); // Activa la animacion de ataque
                    onCooldown = true; // Se activa el "cooldown"
                }

                // Si el cooldown esta activo empieza el conteo del mismo.
                if (onCooldown)
                {
                    Debug.Log("Arranco el cooldown");
                    cooldown = cooldown + Time.deltaTime;
                    animator.SetBool("Attacking", attacking); // Desactivamos la animacion de ataque.

                    //Si el cooldown llega a 2 o es mayor se desactiva y se resetea el contador.
                    if (cooldown >= 2.0f)
                    {
                        Debug.Log("entro en cooldown el machete");
                        onCooldown = false;

                        cooldown = 0;
                        Debug.Log("Se restauro el cooldown");
                    }
                }
            }
//LOGICA DEL DISPARO.

            // Si se cumplen las 2 condiciones el enemigo puede disparar.
            if (shooting && onCooldown == false)
            {
                Vector2 direction = (_player.position - transform.position);
                _lastBullet = direction;
                GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);
                BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();
                bulletComponent.setDirectionBullet(direction);
                onCooldown2 = true; //Se activa el "cooldown2"
            }

            // Si el cooldown2 esta activo empieza el conteo del mismo.
            if (onCooldown2)
            {
                shooting = false;
                Debug.Log("Arranco el cooldown de la pistola");
                cooldown = cooldown + Time.deltaTime;

                //Si el cooldown llega a 1 o es mayor se desactiva y se resetea el contador.
                if (cooldown >= 1)
                {
                    onCooldown = false;
                    cooldown = 0;
                    Debug.Log("Se restauro el cooldown");
                }
            }
        }
    }
    void Update()
    {
       
        moveEnemy();
        
        Attack();

        // Si se cumplen las dos condiciones el jefe cabiara de arma.
        if (lives <= 5 && attacking == false)
        {

            Debug.Log("La vida del jefe es menor a 5! Dispara");
            
            shooting = true;
            Attack();
            animator.SetBool("Attacking", attacking);
        }
    }
}
