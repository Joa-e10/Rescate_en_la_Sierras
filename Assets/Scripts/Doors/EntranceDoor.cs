using System.Collections;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    private bool _isInside;
    private Transform _doorExit;
    [SerializeField]private ItemData _keyRequired;
    private Transform _player;
    private bool _inTheRoom;
    // Verificamos que el objeto colisione con algo.
    void Start()
    {
        _doorExit = GameObject.Find("ExitDoor").GetComponent<Transform>();
        _player = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item y actualizar el valor en el hud.
        if (inventory != null)
        {
            inventory.RestKeys(_keyRequired, 1);
            StartCoroutine(DepartureTime());
            _player.position = _doorExit.position;
            
            //inventory.DiscardItems();
        }
    }

    private IEnumerator DepartureTime()
    {
        if (_inTheRoom == false)
        {
            Debug.Log("Inicia la corrutina de DoorEntrance");
            yield return new WaitForSeconds(1f);
            _inTheRoom = true;
        }

    }

    public bool GetInTheRoom()
    {
        return _inTheRoom;
    }

    public void SetInTheRoom(bool newState) 
    {
        _inTheRoom = newState;
    }
    void Update()
    {
        
    }
}