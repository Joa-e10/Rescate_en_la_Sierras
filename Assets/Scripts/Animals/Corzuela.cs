using UnityEngine;

public class Corzuela : Animals
{
    public GameObject corzuelaCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameAnimal = "corzuela";
        _spriteAnimal = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFree == true)
        {
           corzuelaCard.SetActive(true);
        }
    }
}
