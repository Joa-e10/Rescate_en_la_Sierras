using UnityEngine;

public class WeaponMelee : Weapon
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.takesDamage(quantityDamage);
            Debug.Log($"Contacto y daño recibido = {quantityDamage}");
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
