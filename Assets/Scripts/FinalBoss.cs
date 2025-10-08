using System;
using UnityEngine;

public class FinalBoss : Enemy
{
    private int _counter;
    private int _counter2;
    private float _cooldownMax = 1.5f;
    private Vector2 _lastBullet;
    private Transform gun;

    void Start()
    {
        livesEnemy = 8;
        lives = GetComponent<Characters>();
        lives.SetLives(livesEnemy);
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("player").GetComponent<Transform>();
        gun = GameObject.Find("gunController(2)").GetComponent<Transform>();

        
    }

    protected override void Attack() 
    {
        if (distanceToPlayer <= 3)
        {

            if (shooting == false && onCooldown == false) // Si se cumplen las 2 condiciones el enemigo puede atacar.
            {
                Debug.Log("ENTRO A ATACAR EL ENEMY");
                attacking = true; // Activamos ataque.
                animator.SetBool("Attacking", attacking); // Activa la animacion de ataque
                _counter2++;

                onCooldown = true; // Activamos cooldown


            }


            if (onCooldown) // Si cooldown esta activo empieza el conteo del cooldown.
            {
                cooldown = cooldown + Time.deltaTime;
                animator.SetBool("Attacking", attacking); // Desactivamos la animacion de ataque.

                if (cooldown >= _cooldownMax) // Si cooldown es mayor o igual a 2
                {
                    onCooldown = false; //Desactivamos cooldown.

                    cooldown = 0;// Reiniciamos el tiempo del cooldown para que el enemigo pueda atacar.
                }
            }
        }
        else if (attacking == false && shooting == true)
        {
            if (distanceToPlayer <= 8) {
                GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);
                BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();
                bulletComponent.setDirectionBullet(_lastBullet);
                _lastBullet = movement;
                _counter++;
                shooting = false;
                onCooldown = true; // Activamos cooldown
            }
        }
        if (onCooldown) // Si cooldown esta activo empieza el conteo del cooldown.
        {
            cooldown = cooldown + Time.deltaTime;

            if (cooldown >= _cooldownMax) // Si cooldown es mayor o igual a 2
            {
                onCooldown = false; //Desactivamos cooldown.

                cooldown = 0;// Reiniciamos el tiempo del cooldown para que el enemigo pueda atacar.
            }
        }
    }
    void Update()
    {
        moveEnemy();
        Attack();

        Debug.Log("Vida "+lives);

        if (livesEnemy <= 5 && attacking == false)
        {
            Attack();
            animator.SetBool("Attacking", attacking);

            shooting = true;
            if (_counter == 5)
            {
                
                attacking = true;
                shooting = false;
                Attack();
                animator.SetBool("Attacking", attacking);
                _counter = 0;
                _counter2 = 0;
            }

            if (_counter2 == 6)
            {
                _cooldownMax = 0.5f;
                shooting = true;
                Attack();
                animator.SetBool("Attacking", attacking);
            }
            Attack();
            animator.SetBool("Attacking", attacking);
        }
    }
}
