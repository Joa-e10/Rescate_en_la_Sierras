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
    [SerializeField] private GameObject _panelHud;
    [SerializeField] private GameObject _animalCard;
    [SerializeField] private TextMeshProUGUI _descriptionAnimal;
    private int _animalIndex = 0;

    private void OnEnable()
    {
        Animals.OnAnimalAdd += EndActive;
    }

    private void OnDisable()
    {
        Animals.OnAnimalAdd -= EndActive;
    }
    void Start()
    {
        _playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>(); 
    }

    void Update()
    {
        Debug.Log("Nombre del item?: "+_nameItem);
    }

    public void RefreshInventoryUI()
    {
        Transform _thud = _panelHud.GetComponent<Transform>();
        Debug.Log("Entramos para refrescar");
        foreach (Transform t in _thud)
        {
            Debug.Log("Entramos a limpiar");
            Destroy(t.gameObject);
        }

        foreach (KeyValuePair<ItemData, int> item in _playerInventory._hud)
        {
            GameObject _slot = Instantiate(_newSlot, _thud);
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

        if (state != false)
        {
            _panelHud.SetActive(false);
        }
        else 
        {
            _panelHud.SetActive(true);
        }
    }

    public void EndActive() 
    {
        _animalIndex++;

        if (_animalIndex >= 3) 
        {
            panelFinal.SetActive(true);
        }
    }

    public void JugarDeNuevo()
    {
        SceneManager.LoadScene(0);
    }

}
