using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int lives;
    protected int speed;
    protected Rigidbody2D _rb;
    protected bool _alive = true;

    void Start()
    {
        
    }

    public void takesDamage(int received) // metodo "recibir daño".
    {
        if (lives <= 0) 
        {
            _alive = false;
        }
        else
        { 
            lives = lives - received;
        }
    }

    public void die() 
    {
        if (_alive == false)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
