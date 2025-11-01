using UnityEngine;

public class Animals : MonoBehaviour
{
    private string _nameKey = "CageKey";
    protected string nameAnimal;
    private bool _isFree;
    protected SpriteRenderer _spriteAnimal;
    public Sprite animalFree;

    // Verificamos que el objeto colisione con algo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el item y actualizar el valor en el hud.
        if (inventory != null)
        {
            inventory.SetNameAnimal(nameAnimal);
            inventory.SetNameKey(_nameKey);
            inventory.RestKey();

            //Si el animal es libre se le cambia de sprite.
            if (_isFree) 
            {
                _spriteAnimal.sprite = animalFree;
            }


        }
    }

    public void SetFree( bool newState) 
    {
        _isFree = newState;
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
