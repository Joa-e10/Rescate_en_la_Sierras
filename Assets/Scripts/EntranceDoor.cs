using UnityEngine;

public class DoorBoss : MonoBehaviour
{

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item usado y transportar al personaje.
        if (inventory != null)
        {
            inventory.Entry();
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
