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


    private void Update()
    {

    }
}
