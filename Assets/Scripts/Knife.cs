 using UnityEngine;

public class Knife : Weapon
{
    private void OnTriggerEnter2D(Collider2D collision) // Utilizamos este metodo para tomar la colision del objeto y ver si choca con algo.
    {
        Player player = collision.gameObject.GetComponent<Player>(); // Guardamos el componente Player.
        if (player != null) // Verificamos que el objeto choque con un objeto con el componente Player.
        {

            player.takesDamage(quantityDamage); // Si choca, le hara da�o a dicho objeto con el componente Player.

            Debug.Log($"Contacto y da�o recibido = {quantityDamage}");

        }
    }

    void Start()
    {
        
    }


    void Update()
    {
      
    }
}
