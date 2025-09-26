using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    protected float quantityDamage = 2.0f;
   protected float range = 4.0f;
   protected float cooldown = 1.5f;


    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takesDamage(quantityDamage);
                Debug.Log($"Contacto y daño recibido = {quantityDamage}");
            }



        

    }
    void Update()
    {
        
    }
}
