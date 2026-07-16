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
       
    }

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
        _canvasManager.RefreshInventoryUI();
    }
}
