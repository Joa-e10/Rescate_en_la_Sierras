using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ExitDoor : MonoBehaviour
{
    private bool _isAliveBoss;
    [SerializeField]private ItemData _keyReturned;
    private FinalBoss _boss;
    private bool _inTheRoom;
    private EntranceDoor _entranceDoor;
    private Transform _frontDoor;
    private Transform _player;
    private BoxCollider2D _boxCollider;
    [SerializeField]private BoxCollider2D _bcEntrance;
    private bool _contactEntrance;

    private void OnEnable()
    {
        //FinalBoss.OnDoorUnlocked += Unlocked;
    }

    private void OnDisable()
    {
        //FinalBoss.OnDoorUnlocked -= Unlocked;
    }
    // Verificamos que el objeto colisione con algo.

    void Start()
    {
      //  _boss = GameObject.Find("boss").GetComponent<FinalBoss>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _frontDoor = GameObject.Find("EntranceDoor").GetComponent<Transform>();
        _entranceDoor = GameObject.Find("EntranceDoor").GetComponent<EntranceDoor>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void SetAlive(bool newState)
    {
        _isAliveBoss = newState;
    }

    public void SetInTheRoom(bool newState)
    {
        _inTheRoom = newState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item y actualizar el valor en el hud.
        if (inventory != null && _inTheRoom == true)
        {
            //_contactEntrance = true;

            if (_isAliveBoss == false) 
            {
                _player.position = _frontDoor.position;
                inventory.AddKeys(_keyReturned, 1);
                StartCoroutine(DepartureTime());
            }

        }
    }

    private IEnumerator DepartureTime()
    {
        if (_inTheRoom == true)
        {
            Debug.Log("Inicia la corrutina de ExitDoor");
            
            yield return new WaitForSeconds(1f);
            _inTheRoom = false;
            
        }
        _entranceDoor.SetInTheRoom(_inTheRoom);
    }

    void Update()
    {
        Debug.Log("El estado: "+_inTheRoom);
    }
}
