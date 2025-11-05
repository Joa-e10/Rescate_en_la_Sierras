using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    private int _amountCageKey = 0;
    private int _amountDoorKey = 0;
    public string _nameItem;
    public GameObject _imageKeyC;
    public GameObject _imageKeyD;
    public TextMeshProUGUI amountCageKey;
    public TextMeshProUGUI amountDoorKey;


    void Start()
    {

    }

    void Update()
    {
        Debug.Log("Nombre del item?: "+_nameItem);
    }

    public void PlayerSlot1(int newAmount)
    {
        _amountCageKey = newAmount;
        Debug.Log("Las llaves amontonadas son: " + _amountCageKey);
        if (!_imageKeyC.activeSelf && _amountCageKey >= 1)
        {
            Debug.Log("Se activa la imagen de la llave dorada");
            _imageKeyC.SetActive(true);
            amountCageKey.text = _amountCageKey.ToString();
        }
        else
        {
            if (_amountCageKey <= 0)
            {
                _imageKeyC.SetActive(false);
            }
            amountCageKey.text = _amountCageKey.ToString();
            Debug.Log("Se actualizo la cantidad de la llaves door");
        }
    }

    public void PlayerSlot2(int newAmount) 
    {
        _amountDoorKey = newAmount;
        if (!_imageKeyD.activeSelf && _amountDoorKey >= 1)
        {
            Debug.Log("Se activa la imagen de la llave plateada");
            _imageKeyD.SetActive(true);
            amountDoorKey.text = _amountDoorKey.ToString();
        }
        else 
        {
            if (_amountDoorKey <= 0) 
            {
                _imageKeyD.SetActive(false);
            }
            Debug.Log("Se actualizo la cantidad de la llaves door");
            amountDoorKey.text = _amountDoorKey.ToString();
        }
    }
}
