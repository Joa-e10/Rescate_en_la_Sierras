using UnityEngine;

public class Kit : MonoBehaviour
{
    private float _healing = 1f;

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        // Si el objeto con el que colisiona contiene el componente "Player" llama a la funcion de ese objeto para curarlo.
        if (player != null)
        {
            player.takeHealing(_healing);
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
