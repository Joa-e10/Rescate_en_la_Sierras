using UnityEngine;

public class Zorro : Animals
{
    public GameObject zorroCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameAnimal = "zorro";
        _spriteAnimal = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFree == true)
        {
            zorroCard.SetActive(true);
        }
    }
}
