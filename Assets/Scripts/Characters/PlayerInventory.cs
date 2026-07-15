using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
   public Dictionary<ItemData, int> _hud = new Dictionary<ItemData, int>();
    private int _cageKey;
    private int _doorKey;
    private ItemData _nameItem;
    private int _itemAmount;
    private int _animalCounter = 0;
    
    private Transform _doorExit;
    private Transform _doorPosition;
    private EntranceDoor _doorEntrance;
    public Animals _animals;
    private string _nameAnimal;
    private bool _inTheRoom = false;
    //Nueva logic
    [SerializeField]private CanvasManager _canvasManager;
    private List<ItemData> _itemsDelete = new List<ItemData>();
    private List<ItemData> _itemsAdded = new List<ItemData>();

    void Start()
    {
        //_doorExit = GameObject.Find("doorExit").GetComponent<Transform>();
       // _doorPosition = GameObject.Find("doorEntrance").GetComponent<Transform>();
        //_doorEntrance = GameObject.Find("doorEntrance").GetComponent<EntranceDoor>();
    }

    void Update()
    {
       /* foreach (KeyValuePair<string, int> item in hud)
        {
            Debug.Log($"La llave es: {item.Key} y el valor que tiene es {item.Value}");
            if (item.Key == "CageKey")
            {
                _canvas.PlayerSlot1(item.Value);

            }
            else if(item.Key == "DoorKey")
            {
                _doorEntrance.SetNumberKey(item.Value);
                _canvas.PlayerSlot2(item.Value);
            }
        }

        if (_animalCounter >= 3) 
        {
            SceneManager.LoadScene("WinScene");
        }*/
    }
    //PUERTAS
   /* public void Entry() 
    {
        
        // Navegamos por todas las celdas del HUD
        foreach (KeyValuePair<ItemData, int> item in _hud)
        {
            //Revisamos donde se encuentra la celda "DoorKey" en el HUD.
            if (item.Key == "DoorKey") 
            {
                //Verifica si el valor actual de la llave  es mayor o igual a 1, en caso de ser asi, se le resta un item y se cambia de posicion al personaje.
                if (item.Value >= 1 && _inTheRoom == false) 
                {
                    StartCoroutine(DepartureTime());
                    _doorKey--;
                    transform.position = _doorExit.position;
                }
            }
        }
        _hud["DoorKey"] = _doorKey;
    }

    public void Exit()
    {
    
        foreach (KeyValuePair<string, int> item in _hud)
        {
            if (item.Key == "DoorKey")
            {
                if (item.Value <= 0 && _inTheRoom == true)
                {
                    StartCoroutine(DepartureTime());
                    _doorKey++;
                    transform.position = _doorPosition.position;

                }
            }
        }
        _hud["DoorKey"] = _doorKey;
        
    }

    private IEnumerator DepartureTime()
    {
        if (_inTheRoom == false)
        {
            Debug.Log("Inicia la corrutina de entrada");
            yield return new WaitForSeconds(1f);
            _inTheRoom = true;
        }
        else
        {
            Debug.Log("Inicia la corrutina de salida");
            yield return new WaitForSeconds(1f);
            _inTheRoom = false;
        }
        Debug.Log("Termina la corrutina");

    }*/

    public void AddKeys(ItemData _nameItem, int _itemAmount)
    {
        if (_nameItem == null) return;

        if (_hud.ContainsKey(_nameItem))
        {
            _hud[_nameItem] += _itemAmount;
            Debug.Log("Se actualizó la cantidad del objeto");
        }
        else
        {
            _hud.Add(_nameItem, 1);
            Debug.Log("Se cargó un nuevo objeto");
        }
        //AddItems();
        _canvasManager.RefreshInventoryUI();
    }

    public void RestKeys(ItemData _nameItem, int _itemAmount)
    {
        if (_nameItem == null) return;

        if (_hud.ContainsKey(_nameItem))
        {
            _hud[_nameItem] -= _itemAmount;

            if (_hud[_nameItem] <= 0)
            {

                _hud.Remove(_nameItem);
            }
        }
       // DiscardItems();
        _canvasManager.RefreshInventoryUI();
    }

    public void AddItems() 
    {
        if (_itemsAdded == null) return;
        foreach (var item in _itemsAdded)
        {
            _hud.Add(item, 1);
        }
    }
    public void DiscardItems() 
    {
        if (_itemsDelete == null) return;
        foreach (var item in _itemsDelete)
        {
            _hud.Remove(item);
        }
    }
}
