using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    protected float quantityDamage = 2.0f;
   protected float range = 4.0f;
   protected float cooldown = 1.5f;


    void Start()
    {
        
    }

    public void damager()
    {
        void OnCollisionEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takesDamage(quantityDamage);
            }



        }

    }
    void Update()
    {
        
    }
}
