using System;
using UnityEngine;

public class AnimalsCard : MonoBehaviour
{
    public GameObject animalCard;
    private int _animalCounter;
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            Debug.Log("Entro en el queridisimo colider");
            animalCard.SetActive(false);
            playerInventory.SetAnimalCounter(_animalCounter++);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            animalCard.SetActive(true);
        }

    }
}
