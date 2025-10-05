using UnityEngine;

public class EnemyBase : Enemy
{

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        speed = 2;
    }

    protected override void Attack()
    {
        if (distanceToPlayer <= 3 && onCooldown == false) // Si se cumplen las 2 condiciones el enemigo puede atacar.
        {
            Debug.Log("ENTRO");
            attacking = true; // Activamos ataque.
            animator.SetBool("attacking", attacking); // Activa la animacion de ataque
            Debug.Log("EL ENEMIGO ATACAAA!!");


            onCooldown = true; // Activamos cooldown


        }


        if (onCooldown) // Si cooldown esta activo empieza el conteo del cooldown.
        {
            Debug.Log("Arranco el cooldown");
            cooldown = cooldown + Time.deltaTime;
            animator.SetBool("attacking", attacking); // Desactivamos la animacion de ataque.

            if (cooldown >= 2f) // Si cooldown es mayor o igual a 2
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
        //Debug.Log($"Vida total: {GetLives()}");
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
