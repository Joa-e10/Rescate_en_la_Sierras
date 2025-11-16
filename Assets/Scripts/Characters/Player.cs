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
    private int _bulletCounter;
    private bool reloading;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        gun = GameObject.Find("gunController").GetComponent<Transform>();

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

        if (_directionMove.x > 0)
        {
            _directionIdle = _directionMove;
        }
        else if (_directionMove.x < 0)
        {
            _directionIdle = _directionMove;
        }
        else if (_directionMove.y > 0)
        {
            _directionIdle = _directionMove;
        }
        else if (_directionMove.y < 0)
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
        if (!shooting && !reloading)
        {

            if (value.isPressed && attacking == false)
            {
                shooting = true;
                animator.SetBool("Shooting", shooting);
                StartCoroutine(CooldownShoot());
                GameObject generatedBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
                bullet bulletComponent = generatedBullet.GetComponent<bullet>();
                bulletComponent.setDirectionBullet(_directionBullet);
                _bulletCounter++;
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
                yield return new WaitForSeconds(0.5f);
                shooting = false;
                animator.SetBool("Shooting", shooting);
            Debug.Log("Entra en la primera");
                if (_bulletCounter >= 4) 
                {
                    reloading = true;
                    _bulletCounter = 0;
                    animator.SetBool("Shooting", shooting);
                Debug.Log("Entra en la segunda");
                    yield return new WaitForSeconds(3f);
                Debug.Log("Sale de la segunda");
                    reloading = false;
            }
            }
    }

    /*protected IEnumerator CooldownAttack()
    {
            if (attacking == true)
            {
                yield return new WaitForSeconds(1f);

                attacking = false;
                //animator.SetBool("Shooting", shooting);
            }
    }*/

    private void Update()
    {

        animator.SetBool("Moving", moving);

        if (_directionMove != Vector2.zero)
        {
            _directionBullet = _directionMove;
        }
        else
        {
            moving = false;
            _directionBullet = _directionIdle.normalized;
        }

        if (!moving)
        {

            animator.SetFloat("LastX", _directionIdle.x);
            animator.SetFloat("LastY", _directionIdle.y);

        }
        animator.SetBool("attacking", attacking);
        
    }
}
