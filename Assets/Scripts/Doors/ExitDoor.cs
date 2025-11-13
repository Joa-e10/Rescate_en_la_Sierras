using System;
using System.Collections;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool _isInside;
    private bool _isAlive;
    private FinalBoss _boss;

    private void OnEnable()
    {
        //FinalBoss.OnDoorUnlocked += Unlocked;
    }

    private void OnDisable()
    {
        //FinalBoss.OnDoorUnlocked -= Unlocked;
    }
    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para añadir el item perdido al hud y transportar al personaje.
        if (inventory != null)
        {
            Debug.Log("Esta vivo?: " + _isAlive);
            if (_isInside && !_isAlive)
            {
                inventory.Exit();
            }
            else 
            {
                Debug.Log("El player no debe salir");
            }

        }
    }

    public void SetAlive(bool newState)
    {
        _isAlive = newState;
    }

    public void SetInside(bool newState)
    {
            _isInside = newState;
        
    }

    void Start()
    {
        _boss = GameObject.Find("boss").GetComponent<FinalBoss>();
        
    }

    void Update()
    {
        
    }
}
