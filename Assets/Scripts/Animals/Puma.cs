using UnityEngine;

public class Puma : Animals
{
    public GameObject pumaCard;
    

    void Start()
    {   
        nameAnimal = "puma";
        _spriteAnimal = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       if (_isFree == true)
        {
            pumaCard.SetActive(true);
        }
    }
}
