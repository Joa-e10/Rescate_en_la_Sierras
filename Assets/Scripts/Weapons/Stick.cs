using UnityEngine;
using UnityEngine.Timeline;

public class Stick : MonoBehaviour
{

    private float quantityDamage = 1f;

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        EnemyShooting enemy1 = collision.gameObject.GetComponent<EnemyShooting>();
        FinalBoss enemy2 = collision.gameObject.GetComponent<FinalBoss>();

        // Si el objeto con el que colisiona contiene el componente "EnemyBase" llama a la funcion de ese objeto para hacerle daño.
        if (enemy != null)
        {
            enemy.takesDamage(quantityDamage);
            Debug.Log($"Contacto y daño recibido = {quantityDamage}");
        }
        // Si el objeto con el que colisiona contiene el componente "EnemyShooting" llama a la funcion de ese objeto para hacerle daño.
        else if (enemy1 != null)
        {
            enemy1.takesDamage(quantityDamage);
            Debug.Log($"Contacto y daño recibido = {quantityDamage}");
        }
        // Si el objeto con el que colisiona contiene el componente "FinalBoss" llama a la funcion de ese objeto para hacerle daño.
        else if(enemy2 != null)
        {
            enemy2.takesDamage(quantityDamage);
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
