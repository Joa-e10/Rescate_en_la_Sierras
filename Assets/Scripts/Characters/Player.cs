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
    private bool reloading;

    private Vector2 _directionMouse;
    private Camera _camera;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        gun = GameObject.Find("gunController").GetComponent<Transform>();
        _camera = Camera.main;

        lives = 10f;
        speed = 5f;
    }

    public void setShooting(bool state)
    {
        shooting = state;
    }

    

    private void OnMove(InputValue inputValue)  // Utilizamos el metodo OnMove designado para la accion de mover.
    {

            Vector2 move = inputValue.Get<Vector2>(); // Tomamos el valor recibido de la accion.
            _rb.linearVelocity = move * speed; // generamos el movimiento del player.

        animator.SetFloat("Vertical", _rb.linearVelocity.y);
        animator.SetFloat("Horizontal", _rb.linearVelocity.x);

        _directionMove = move;
        moving = true;

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
        if (!shooting && reloading == false)
        {

            if (value.isPressed && attacking == false)
            {
                shooting = true;
                animator.SetBool("Shooting", shooting);
                StartCoroutine(CooldownShoot());
                GameObject generatedBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
                bullet bulletComponent = generatedBullet.GetComponent<bullet>();
                bulletComponent.setDirectionBullet(_directionMouse.normalized);
            }

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
            lives += received;

        }
    }

    protected IEnumerator CooldownShoot()
    {
        if (shooting == true) 
        {
            reloading = true;
            shooting = false;
            animator.SetBool("Shooting", shooting);
            yield return new WaitForSeconds(1.2f);
            reloading = false;
        }
    }

    private void Update()
    {

        Vector2 mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        _directionMouse = mouseWorldPoint - (Vector2)transform.position;

        animator.SetBool("Moving", moving);

        if (_directionMove == Vector2.zero)
        {
            moving = false;
        }

        if (!moving)
        {

            animator.SetFloat("LastX", _directionMouse.x);
            animator.SetFloat("LastY", _directionMouse.y);

        }
        animator.SetBool("attacking", attacking); 
    }
}
