using System;
using System.Collections;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para a�adir el item perdido al hud y transportar al personaje.
        if (inventory != null)
        {
            inventory.Exit();
        }
    }
    void Start()
    {
    }

    void Update()
    {

    }
}
