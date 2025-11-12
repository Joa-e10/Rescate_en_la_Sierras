 using UnityEngine;

public class Knife : MonoBehaviour
{

    private float quantityDamage = 0.5f;

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        // Si el objeto con el que colisiona contiene el componente "Player" llama a la funcion de ese objeto para hacerle daño.
        if (player != null)
        {

            player.takesDamage(quantityDamage);

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
