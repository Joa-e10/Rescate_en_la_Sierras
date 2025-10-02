using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : Characters
{
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
    }
    private void OnMove(InputValue inputValue)  // Utilizamos el metodo OnMove designado para la accion de mover.
    {
        Vector2 move = inputValue.Get<Vector2>(); // Tomamos el valor recibido de la accion.
        _rb.linearVelocity = move * speed; // generamos el movimiento del player.
    }

    private void OnAttack(InputValue value) // Utilizamos el metodo OnAttack designado para la accion de atacar.
    {

        if (value.isPressed) // condicional que toma el valor de la accion para saber si esta presionada o no para cambiar el estado del ataque.
        {
            attacking = true;
            
            Debug.Log("Botón presionado");
            
            
        }

    }


    private void Update()
    {
        animator.SetBool("attacking", attacking);
    }

    protected override void die()
    {
        if (_alive == false) //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.
        {

            SceneManager.LoadScene("SampleScene");

        }
    }
}
