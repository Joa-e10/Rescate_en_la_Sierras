using UnityEngine;

public class EnemyShooting : Enemy
{
    private Vector2 _lastBullet;
    private Transform gun;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("player").GetComponent<Transform>();
        gun = GameObject.Find("gunController(1)").GetComponent<Transform>();
        speed = 1;
    }

    protected override void Attack()
    {
        if (distanceToPlayer <= 5 && onCooldown == false)
        {
            Debug.Log("El enemigo esta disparando");
            shooting = true;
            GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);
            BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();
            bulletComponent.setDirectionBullet(_lastBullet);
            _lastBullet = movement;
            shooting = false;
            onCooldown = true; // Activamos cooldown  
        }

        if (onCooldown) // Si cooldown esta activo empieza el conteo del cooldown.
        {
            Debug.Log("Arranco el cooldown");
            cooldown = cooldown + Time.deltaTime;
            //animator.SetBool("attacking", attacking); // Desactivamos la animacion de ataque.

            if (cooldown >= 1f) // Si cooldown es mayor o igual a 2
            {
                Debug.Log("entro2");
                onCooldown = false; //Desactivamos cooldown.

                cooldown = 0;// Reiniciamos el tiempo del cooldown para que el enemigo pueda atacar.
                Debug.Log("Se restauro el cooldown");
            }
        }

    }

    void Update()
    {
        moveEnemy();
        Attack();
    }
}
