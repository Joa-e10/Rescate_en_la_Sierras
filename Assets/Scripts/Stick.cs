using UnityEngine;

public class Stick : Weapon
{
    private void OnTriggerEnter2D(Collider2D collision) // Utilizamos este metodo para tomar la colision del objeto y ver si choca con algo.
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>(); // Guardamos el componente Enemy.
        if (enemy != null) // Verificamos que el objeto choque con un objeto con el componente enemy.
        {
            enemy.takesDamage(quantityDamage); // Si choca, le hara daño a dicho objeto con el componente Enemy.
            Debug.Log($"Contacto y daño recibido = {quantityDamage}");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
