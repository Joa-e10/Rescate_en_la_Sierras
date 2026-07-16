using System.Collections;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    private bool _isInside;
    private Transform _backDoor;
    private ExitDoor _doorExit;
    [SerializeField]private ItemData _keyRequired;
    private Transform _player;
    private bool _inTheRoom;
    private BoxCollider2D _boxCollider;
    [SerializeField]private BoxCollider2D _bcExit;
    // Verificamos que el objeto colisione con algo.
    void Start()
    {
        _backDoor = GameObject.Find("ExitDoor").GetComponent<Transform>();
        _doorExit = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _boxCollider = GetComponent<BoxCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item y actualizar el valor en el hud.
        if (inventory != null && _inTheRoom == false)
        {
            
            _player.position = _backDoor.position;
            inventory.RestKeys(_keyRequired, 1);
            StartCoroutine(DepartureTime());


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
        _doorExit.SetInTheRoom(_inTheRoom);

    }

    public void SetInTheRoom(bool newState) 
    {
        _inTheRoom = newState;
    }
    void Update()
    {
        
    }
}