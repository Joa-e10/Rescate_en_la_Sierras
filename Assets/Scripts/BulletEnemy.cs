using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private int _damage = 1;
    private float _resetTime = 2f;
    private Vector2 _direction;
    private int speed = 5;
    private Rigidbody2D _rb;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>(); ;
    }

    public void setDirectionBullet(Vector2 direction)
    {
        _direction = direction;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("le dispare");
            player.takesDamage(_damage);
            Destroy(gameObject);
        }
    }


    void Update()
    {
        _rb.linearVelocity = _direction * speed;
        Debug.Log("Arranque desde:" + _direction);
        _resetTime -= Time.deltaTime;



        if (_resetTime <= 0)
        {
            Destroy(gameObject);
            _resetTime = 2f;
        }
    }
}
