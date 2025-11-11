using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;


public class Player : Characters
{
    private Vector2 _directionMove;
    private Vector2 _directionBullet;
    public GameObject bullet;
    private Transform gun;
    private Vector2 _directionIdle = Vector2.down;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        gun = GameObject.Find("gunController").GetComponent<Transform>();

        lives = 10;
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

        if (_directionMove.x > 0) 
        {
            _directionIdle = _directionMove;
        }
        if (_directionMove.x < 0)
        {
            _directionIdle = _directionMove;
        }
        if (_directionMove.y > 0)
        {
            _directionIdle = _directionMove;
        }
        if (_directionMove.y < 0)
        {
            _directionIdle = _directionMove;
        }

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

            StartCoroutine(Cooldown());
            GameObject generatedBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            bullet bulletComponent = generatedBullet.GetComponent<bullet>();
            bulletComponent.setDirectionBullet(_directionBullet);

        }


    }

    protected override void die()
    {
        if (_alive == false) //Condicional para saber si el personaje se encuentra vivo para destruirlo o no.
        {

            SceneManager.LoadScene("SampleScene");

        }
    }

    public void takeHealing(float received) 
    {
        if (lives < 10 && _alive)
        {
            Debug.Log("El jugador se curó");
            lives =+ received;

        }
    }

    protected IEnumerator Cooldown()
    {
        if (shooting == true) 
        {
            yield return new WaitForSeconds(3f);

            shooting = false;
            //animator.SetBool("Shooting", shooting);
        }
    }

    private void Update()
    {


        if (_directionMove != Vector2.zero)
        {
            _directionBullet = _directionMove;
        }
        else
        {
            _directionBullet = _directionIdle.normalized;
        }

            animator.SetBool("attacking", attacking);
    }
}
