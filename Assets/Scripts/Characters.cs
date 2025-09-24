using UnityEngine;
using UnityEngine.InputSystem;

public class Characters : MonoBehaviour
{

    private float lives = 5.0f;
    protected float speed = 4;
    private bool _alive = true;
    protected Rigidbody2D _rb;
    protected Transform _player;
    protected float detectionRadius = 5.0f;
    protected Vector2 movement;
    //protected GameObject[] inventory = new GameObject[4];


    private void Start()
    {
    }
    protected void moveCharacter()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direccion = (_player.position - transform.position).normalized;

            movement = new Vector2(direccion.x, 0);
        }
        else
        {
            movement = Vector2.zero;
        }

        _rb.MovePosition(_rb.position + movement * speed * Time.deltaTime);
    }

   protected void takesDamage(int received) 
    {

        lives = lives - received;

        if (lives <= 0) 
        {
            _alive = false;
            die();

        }
    }
        private void die() 
        {
            if (_alive == false) {

             Debug.Log("El jugador murio");

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
