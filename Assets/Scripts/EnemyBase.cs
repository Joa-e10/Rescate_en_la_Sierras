using UnityEngine;

public class EnemyBase : Enemy
{
    //Declaracion de las variables que solo utilizaran los enemigos.
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
    }
   
    void Update()
    {
        moveEnemy(); // Llamada al metodo "moveEnemy" para generar el movimiento del enemigo.
        Debug.Log($"Vida total: {GetLives()}");
    }
}
