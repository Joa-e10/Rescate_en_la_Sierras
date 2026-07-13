using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public string _nameItem;
    public GameObject _imageKeyC;
    public GameObject _imageKeyD;
    public TextMeshProUGUI amountCageKey;
    public TextMeshProUGUI amountDoorKey;
    public GameObject panelFinal;
    private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _newSlot;
    [SerializeField] private Transform _panelHud;
    [SerializeField] private GameObject _animalCard;
    [SerializeField] private TextMeshProUGUI _descriptionAnimal;

    void Start()
    {
        _playerInventory = GameObject.Find("player").GetComponent<PlayerInventory>(); 
    }

    void Update()
    {
        Debug.Log("Nombre del item?: "+_nameItem);
        //RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
       // _playerInventory = GetComponent<PlayerInventory>();
        Debug.Log("Entramos para refrescar");
        foreach (Transform t in _panelHud)
        {
            Debug.Log("Entramos a limpiar");
            Destroy(t.gameObject);
        }

        foreach (KeyValuePair<ItemData, int> item in _playerInventory._hud)
        {
            GameObject _slot = Instantiate(_newSlot, _panelHud);
            SlotUi slotAttributes = _slot.GetComponent<SlotUi>();
            slotAttributes._textamount.text = item.Value.ToString();
            slotAttributes._icon.sprite = item.Key._icon;
            slotAttributes._data = item.Key;
            Debug.Log("Recorremos la activacion del prefab");
        }

    }

    public void AnimalCardUi(string dataCard, Sprite imageAnimal, bool state) 
    {
        Image componentImage = _animalCard.GetComponent<Image>();
        _animalCard.SetActive(state);
        componentImage.sprite = imageAnimal;
        _descriptionAnimal.text = dataCard;
    }

    public void JugarDeNuevo()
    {
        SceneManager.LoadScene(0);
    }

}
