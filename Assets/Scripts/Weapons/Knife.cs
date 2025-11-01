 using UnityEngine;

public class Knife : MonoBehaviour
{

    private float quantityDamage = 1f;
    private float range = 4.0f;

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        // Si el objeto con el que colisiona contiene el componente "Player" llama a la funcion de ese objeto para hacerle da�o.
        if (player != null)
        {

            player.takesDamage(quantityDamage);

            Debug.Log($"Contacto y da�o recibido = {quantityDamage}");

        }
    }

    void Start()
    {
        
    }


    void Update()
    {
      
    }
}
