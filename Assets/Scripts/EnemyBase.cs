using UnityEngine;

public class EnemyBase : Enemy
{

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Toma el componente rigidbody2D del objeto.
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        speed = 2;
    }

    
   
    void Update()
    {
        moveEnemy();
        Attack();
            
        //Debug.Log($"Vida total: {GetLives()}");
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
