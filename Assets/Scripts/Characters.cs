using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Characters : MonoBehaviour
{
    // Declaracion de las variables que tienen en conjunto todos los personajes.

    private int lives = 5;
    protected float speed = 4;
    protected bool _alive = true;
    protected bool attacking = false;
    protected bool shooting = false;
    protected Rigidbody2D _rb;
    public Animator animator;
    public SpriteRenderer sprite;


    private void Start()
    {
    }

   public void takesDamage(int received) // metodo "recibir da�o".
    {

        if (lives <= 1) //Condicional para saber si el personaje esta vivo (vidas mayor a 1) para recibir el da�o. 
        {
            _alive = false; //En caso contrario, se le cambiara el estado de "vivo" a falso y pasara a ser destruido.
            die();

        }
        else { //si no, se le restara el da�o recibido a "lives".

            lives = lives - received;

        }
    }

    public float GetLives()
    {
        return lives;
    }

    public void attackDisabled() // Metodo "Ataque Deshabilitado"
    {

        attacking = false; //Cambia el estado del ataque.
        Debug.Log("El evento anda");
    }

    protected abstract void die(); // Metodo "morir".
        
            //if (_alive == false) { //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.

               // Destroy(gameObject);

            //}
       
}
