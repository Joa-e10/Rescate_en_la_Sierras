using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    protected int quantityDamage = 1;
   protected float range = 4.0f;
   protected float cooldown = 1f;


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
