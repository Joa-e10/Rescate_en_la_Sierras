using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Characters
{
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue inputValue)
    {
        Vector2 move = inputValue.Get<Vector2>();
        _rb.linearVelocity = move * speed;
    }

    private void OnAttack(InputValue value)
    {

        if (value.isPressed)
        {
            attacking = true;
            
            Debug.Log("Botón presionado");
            
            
        }

    }

    public void attackDisabled() 
    {

        attacking = false;

    }


    private void Update()
    {
        animator.SetBool("attacking", attacking);
    }
}
