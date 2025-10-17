using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public Dictionary<string, int> hud = new Dictionary<string, int>();
    private int _cageKey;
    private int _doorKey;
    private string _nameItem;
    private int valueItem = 0;
    void Start()
    {
        
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
    }

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

    private void AddItem() 
    {
        foreach (KeyValuePair<string, int> item in hud)
        {
            Debug.Log($"En: {item.Key} hay una cantidad de: {item.Value}");
        }
    }

    void Update()
    {
        AddItem();
    }
}
