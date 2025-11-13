using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    private bool _isInside;
    private ExitDoor _exitDoor;
    private int _numbreKeys;
    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item usado y transportar al personaje.

        if (inventory != null) 
        {
            if (_numbreKeys >= 1) 
            {
                inventory.Entry();
                _isInside = true;
                _exitDoor.SetInside(_isInside);
            }
        }
    }

    public void SetNumberKey(int newNumbre) 
    {
        _numbreKeys = newNumbre;
    }
    void Start()
    {
        _exitDoor = GameObject.Find("doorExit").GetComponent<ExitDoor>();
    }

    void Update()
    {
        
    }
}