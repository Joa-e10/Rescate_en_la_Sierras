using UnityEngine;

public class Animals : MonoBehaviour
{
    private string _nameKey = "CageKey";
    private bool _isFree;
    private SpriteRenderer _spritePuma;
    public Sprite animalFree;

    // Verificamos que el objeto colisione con algo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

        // Si el objeto con el que colisiona contiene el componente "PlayerInventory" llama a la funcion de ese objeto para restar el objeto y actualizar el valor en el hud.
        if (inventory != null)
        {
            inventory.SetNameKey(_nameKey);
            inventory.RestKey();

            //Si el animal es libre se le cambia de sprite.
            if (_isFree) 
            {
                _spritePuma.sprite = animalFree;
            }


        }
    }

    public void SetFree( bool newState) 
    {
        _isFree = newState;
    }

    void Start()
    {
        _spritePuma = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }
}
