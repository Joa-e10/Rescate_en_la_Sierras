using UnityEngine;

public class EnemyShooting : Enemy
{
    private Vector2 _lastBullet;
    Vector2 directionBullet;
    private Transform gun;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        gun = GameObject.Find("gunController(1)").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "gunController(1)".

        speed = 1;
    }

    protected override void Attack()
    {
        // Si se cumplen las 2 condiciones el enemigo puede atacar.
        if (distanceToPlayer <= 5 && onCooldown == false)
        {
            Debug.Log("El enemigo esta disparando");
            shooting = true;

            Vector2 direction = (_player.position - transform.position);

            GameObject generatedBullet = Instantiate(bulletEnemy, gun.transform.position, Quaternion.identity);
            BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();
            bulletComponent.setDirectionBullet(direction);
            _lastBullet = movement;
            onCooldown = true; // Se activa el "cooldown"  
        }

        // Si el cooldown esta activo empieza el conteo del mismo.
        if (onCooldown)
        {
            shooting = false;
            Debug.Log("Arranco el cooldown");
            cooldown = cooldown + Time.deltaTime;

            //Si el cooldown llega a 1 o es mayor se desactiva y se resetea el contador.
            if (cooldown >= 1f)
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
    }
}
