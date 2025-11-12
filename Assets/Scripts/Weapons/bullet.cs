using UnityEngine;
using UnityEngine.InputSystem;

public class bullet : MonoBehaviour
{
    private float _damage = 1.5f;
    private float _resetTime = 2f;
    private Vector2 _direction;
    private int speed = 8;
    private Rigidbody2D _rb;
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
    }

    // Le asignamos un valor a la direccion de la bala del jugador mediante un metodo "Setter".
    public void setDirectionBullet(Vector2 direction)
    {
        _direction = direction;
    }

    // Verificamos que el objeto colisione con algo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        EnemyShooting enemy1 = collision.gameObject.GetComponent<EnemyShooting>();
        FinalBoss enemy2 = collision.gameObject.GetComponent<FinalBoss>();

        // Si el objeto con el que colisiona contiene el componente "EnemyBase" llama a la funcion de ese objeto para hacerle daño.
        if (enemy != null)
        {
            enemy.takesDamage(_damage);
            Debug.Log($"Contacto y daño recibido = {_damage}");
            Destroy(gameObject);
        }
        // Si el objeto con el que colisiona contiene el componente "EnemyShooting" llama a la funcion de ese objeto para hacerle daño.
        else if (enemy1 != null)
        {
            enemy1.takesDamage(_damage);
            Debug.Log($"Contacto y daño recibido = {_damage}");
            Destroy(gameObject);
        }
        // Si el objeto con el que colisiona contiene el componente "FinalBoss" llama a la funcion de ese objeto para hacerle daño.
        else if(enemy2 != null)
        {
            enemy2.takesDamage(_damage);
            Debug.Log($"Contacto y daño recibido = {_damage}");
            Destroy(gameObject);
        }
    }


    void Update()
    {
        // Iniciamos la velocidad y inicia el conteo del tiempo.
        _rb.linearVelocity = _direction * speed;
        _resetTime -= Time.deltaTime;


        // Si se cumple la condicion, la bala se destruira y el tiempo vuelve a ser de valor 1.5
        if (_resetTime <= 0)
        {
            Destroy(gameObject);
            _resetTime = 1.5f;
        }
    }
}
