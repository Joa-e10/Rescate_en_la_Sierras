using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Characters : MonoBehaviour
{
    // Declaracion de las variables que tienen en conjunto todos los personajes.

    private int lives = 5;
    protected float speed = 4;
    private bool _alive = true;
    protected bool attacking = false;
    protected Rigidbody2D _rb;
    public Animator animator;
    public SpriteRenderer sprite;
    //protected GameObject[] inventory = new GameObject[4];


    private void Start()
    {
    }

   public void takesDamage(int received) // metodo "recibir daño".
    {

        if (lives <= 1) //Condicional para saber si el personaje esta vivo (vidas mayor a 1) para recibir el daño. 
        {
            _alive = false; //En caso contrario, se le cambiara el estado de "vivo" a falso y pasara a ser destruido.
            die();

        }
        else {

            lives = lives - received;

        }
    }

    public float GetLives()
    {
        return lives;
    }

    private void die() // Metodo "morir".
        {
            if (_alive == false) { //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.

                Destroy(gameObject);

            }
        }
    /*protected void interactionCharacter()
    {

        void OnTriggerEnter2D(Collider2D collision)
        {

            collectable collectable = collision.gameObject.GetComponent<collectable>();

            if (collectable != null)
            {
                for (int i = 0; i <= 3; i++)
                {


                    inventory[i] = gameObject;
                    Debug.Log($"Se guardo el objeto {inventory[i]}");

                }
            }
        }

    }*/

}
