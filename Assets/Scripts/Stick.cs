using UnityEngine;

public class Stick : Weapon
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FinalBoss enemy = collision.gameObject.GetComponent<FinalBoss>(); // Guardamos el componente Enemy.
        if (enemy != null) // Verificamos que el objeto choque con un objeto con el componente enemy.
        {
            enemy.takesDamage(quantityDamage); // Si choca, le hara daño a dicho objeto con el componente Enemy.
            Debug.Log($"Contacto y daño recibido = {quantityDamage}");
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision) // Utilizamos este metodo para tomar la colision del objeto y ver si choca con algo.
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>(); // Guardamos el componente Enemy.
        if (enemy != null) // Verificamos que el objeto choque con un objeto con el componente enemy.
        {
            enemy.takesDamage(quantityDamage); // Si choca, le hara daño a dicho objeto con el componente Enemy.
            Debug.Log($"Contacto y daño recibido = {quantityDamage}");
        }
    }*/

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
