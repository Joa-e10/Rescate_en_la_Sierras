using System;
using UnityEngine;

public class AnimalsCard : MonoBehaviour
{
    public GameObject animalCard;
    private int _animalCounter;
    [SerializeField] private CanvasManager _canvasManager;
    [SerializeField] private ItemData _animalData;
    private bool _isVisible;
    void Start()
    {
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entro en el queridisimo colider");
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            _isVisible = true;
            _canvasManager.AnimalCardUi(_animalData._description, _animalData._icon, _isVisible);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            _isVisible = false;
            _canvasManager.AnimalCardUi(_animalData._description, _animalData._icon, _isVisible);
            Debug.Log("SAlio del queridismo colider");


            //animalCard.SetActive(false); ACA VA LA REFERENCIA AL CANVAS MANAGER
            //playerInventory.SetAnimalCounter(_animalCounter++);
        }
    }
}
