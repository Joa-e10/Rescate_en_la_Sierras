using System;
using UnityEngine;

public class AnimalsCard : MonoBehaviour
{
    public GameObject animalCard;
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Entro en el queridisimo colider");
            animalCard.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            animalCard.SetActive(true);
        }

    }
}
