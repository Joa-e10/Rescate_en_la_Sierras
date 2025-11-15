using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Characters : MonoBehaviour
{
    // Declaracion de las variables que tienen en conjunto todos los personajes.

    public float lives = 8f;
    protected float speed = 4;
    public bool _alive = true;
    protected bool attacking = false;
    protected bool shooting = false;
    protected bool damaged = false;
    protected bool moving = false;
    protected Rigidbody2D _rb;
    public Animator animator;
    public SpriteRenderer sprite;

    private void Start()
    {
    }

    public void takesDamage(float received) // metodo "recibir daño".
    {
        if (lives <= 1) //Condicional para saber si el personaje esta vivo (vidas mayor a 1) para recibir el daño. 
        {
            _alive = false; //En caso contrario, se le cambiara el estado de "vivo" a falso y pasara a ser destruido.
            animator.SetBool("Alive", _alive);
        }
        else
        { //si no, se le restara el daño recibido a "lives".

            lives = lives - received;
            damaged = true;
            animator.SetBool("Damaged", damaged);
        }
    }

    // Metodo "Ataque Deshabilitado" para cambiar el estado del ataque.
    public void attackDisabled()
    {

        attacking = false;
    }

    public void DamagedDisabled()
    {

        damaged = false;
        animator.SetBool("Damaged", damaged);
    }

    /* public void ShootDisabled()
     {

         shooting = false;
     }*/

    protected abstract void die(); // Metodo "morir".
        
            //if (_alive == false) { //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.

               // Destroy(gameObject);

            //}
       
}