using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : Characters
{
    private Vector2 _directionMove;
    private Vector2 _directionBullet;
    private Transform gun;
    public GameObject bullet;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        gun = GameObject.Find("gunController").GetComponent<Transform>();
    }

    public void setShooting(bool state)
    {
        shooting = state;
    }

    private void OnMove(InputValue inputValue)  // Utilizamos el metodo OnMove designado para la accion de mover.
    {
        
            Vector2 move = inputValue.Get<Vector2>(); // Tomamos el valor recibido de la accion.
            _rb.linearVelocity = move * speed; // generamos el movimiento del player.
        _directionMove = move;

}

    private void OnAttack(InputValue value) // Utilizamos el metodo OnAttack designado para la accion de atacar.
    {

        if (value.isPressed && shooting == false) // condicional que toma el valor de la accion para saber si esta presionada o no para cambiar el estado del ataque.
        {

            attacking = true;

            Debug.Log("Botón derecho presionado y estamos atacando");
        }

    }

    private void OnShoot(InputValue value)
    {
        if (value.isPressed && attacking == false)
        {

            shooting = true;
            GameObject generatedBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            bullet bulletComponent = generatedBullet.GetComponent<bullet>();
            bulletComponent.setDirectionBullet(_directionBullet);
            shooting = false;

        }


    }



    private void Update()
    {

        if (_directionMove.x > 0)
        {
            Debug.Log("Arranque desde: 1");
            _directionBullet = Vector2.right;
        }
        else if (_directionMove.x < 0)
        {
            Debug.Log("Arranque desde: 2");
            _directionBullet = Vector2.left;
        }
        else if (_directionMove.y > 0)
        {
            Debug.Log("Arranque desde: 3");
            _directionBullet = Vector2.up;
        }
        else if (_directionMove.y < 0)
        {
            Debug.Log("Arranque desde: 4");
            _directionBullet = Vector2.down;
        }
        else
        {
            Debug.Log("Arranque desde: else");
            _directionBullet = Vector2.right;
        }

            animator.SetBool("attacking", attacking);
        Debug.Log("Posicion: "+gun);
    }

    protected override void die()
    {
        if (_alive == false) //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.
        {

            SceneManager.LoadScene("SampleScene");

        }
    }
}
