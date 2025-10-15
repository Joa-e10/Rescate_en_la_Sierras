using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private float _damage = 1f;
    private float _resetTime = 2f;
    private Vector2 _direction;
    private int speed = 8;
    private Transform _player;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
    }

    // Le asignamos un valor a la direccion de la bala del enemigo mediante un metodo "Setter" y lo normalizamos.
    public void setDirectionBullet(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        // Si el objeto con el que colisiona contiene el componente "Player" llama a la funcion de ese objeto para hacerle daño.
        if (player != null)
        {
            Debug.Log("le dispare");
            player.takesDamage(_damage);
            Destroy(gameObject);
        }
    }


    void Update()
    {
        // Iniciamos la velocidad y inicia el conteo del tiempo.
        _rb.linearVelocity = _direction * speed;
        Debug.Log("Arranque desde:" + _direction);
        _resetTime -= Time.deltaTime;


        // Si se cumple la condicion, la bala se destruira y el tiempo vuelve a ser de valor 1.5
        if (_resetTime <= 0)
        {
            Destroy(gameObject);
            _resetTime = 1.5f;
        }
    }
}
