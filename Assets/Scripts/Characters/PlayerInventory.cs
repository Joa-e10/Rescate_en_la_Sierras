using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

   /* public void SetAnimalCounter(int newAmount) 
    {
        _animalCounter = _animalCounter + newAmount;
    }

    //Carga del item "DoorKey" en el inventario
    public void AddDoorKey()
    {
        _doorKey++;

        // Si la el valor de _cageKey es distinto a 1 va a cargar el valor de la variable _cageKey en Value del hud.
        if (_doorKey != 1)
        {
            Debug.Log("Se cargo la llave con exito");
            hud["DoorKey"] = _doorKey;
        }

        // Si es igual a 1 va a cargar el contenido de "_nameItem" en key y a cargar el valor de la variable _cageKey en Value del hud.
        else
        {
            _nameItem = "DoorKey";
            hud.Add(_nameItem, _doorKey);
            Debug.Log("Se cargo con exito la primera llave");
        }
        /*for (i = 0; i <= 4; i++)
        {

        }*/
   /* }

    //Carga del item "CageKage" en el inventario
    public void AddCageKey()
    {
        _cageKey++;

        // Si la el valor de _cageKey es distinto a 1 va a cargar el valor de la variable _cageKey en Value del hud.
        if (_cageKey != 1)
        {
            Debug.Log("Se cargo la llave jaula con exito");
            hud["CageKey"] = _cageKey;
        }

        // Si es igual a 1 va a cargar el contenido de "_nameItem" en key y a cargar el valor de la variable _cageKey en Value del hud.
        else
        {
            _nameItem = "CageKey";
            hud.Add(_nameItem, _cageKey);
            Debug.Log("Se cargo con exito la primera llave jaula");

        }
    }

    public void SetNameKey(string newName)
    {
        _nameItem = newName;
    }

    public void SetNameAnimal(string newName)
    {
        _nameAnimal = newName;
    }

    //ANIMALES

    /*public void RestKey()
    {
        // Navegamos por todas las celdas del HUD
        foreach (KeyValuePair<string, int> item in hud)
        {
            //Revisamos donde se encuentra la celda "CageKey" en el HUD.
            if (item.Key == _nameItem)
            {
                //Verifica si el valor actual de la llave  es mayor o igual a 1, en caso de ser asi, se le resta un item y se cambia el estado de "_isFree" del animal.
                if (item.Value >= 1)
                {
                    _animals = GameObject.Find(_nameAnimal).GetComponent<Animals>();
                    _cageKey--;
                    _animals.SetFree(true);
                }
            }
        }
        hud["CageKey"] = _cageKey;
    } */

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
            _hud.Add(_nameItem, _itemAmount);
            Debug.Log("Se cargó un nuevo objeto");
        }

        _canvasManager.RefreshInventoryUI();
    }

    public void RestKeys()
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
        _canvasManager.RefreshInventoryUI();
    }
}
