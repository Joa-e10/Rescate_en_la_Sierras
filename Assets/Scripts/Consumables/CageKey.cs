using System.Collections;
using UnityEngine;

public class CageKey : Keys
{
    private bool _inInventory;
    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para añadir el objeto al hud.
        if (inventory != null)
        {
            inventory.AddKeys(_data, _data._amount);
            
            Destroy(gameObject);
        }
     
    }
    void Start()
    {
    }

    
    void Update()
    {
        
    }
}
