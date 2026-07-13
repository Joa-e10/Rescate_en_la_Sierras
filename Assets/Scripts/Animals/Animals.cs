using UnityEngine;

public class Animals : MonoBehaviour
{
    protected string _keyRequired = "CageKey";
    protected string nameAnimal;
    //public bool _isFree;
    private SpriteRenderer _spriteAnimal;
    [SerializeField]private Sprite _animalFree;
    [SerializeField]private GameObject _animalCard;


    private void Start()
    {
        _spriteAnimal = GetComponent<SpriteRenderer>();
    }
    // Verificamos que el objeto colisione con algo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item y actualizar el valor en el hud.
        if (inventory != null)
        {
            foreach(var item in inventory._hud) 
            {
                if (_keyRequired == item.Key._name)
                {
                    inventory.RestKeys(item.Key, 1);
                    _spriteAnimal.sprite = _animalFree;
                    _animalCard.SetActive(true);

                }
            }
        }
    }
}
