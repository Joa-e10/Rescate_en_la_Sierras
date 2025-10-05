using UnityEngine;
using UnityEngine.InputSystem;

public class gun : Weapon
{
   /* private bool _shooting = false;
    private bool _attacking = false;
    public GameObject bulletEnemy;
    private Player player;
    private Vector2 _directionBullet;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();


    }
    public void setDirectionBullet(Vector2 directionb)
    {
        _directionBullet = directionb;
    }
    public void setAttacking(bool state)
    {
        _attacking = state;
    }

    private void OnShoot(InputValue value)
    {
        if (value.isPressed && _attacking == false)
        { 
        
            _shooting = true;
            GameObject generatedBullet = Instantiate(bulletEnemy, transform.position, Quaternion.identity);
            BulletEnemy bulletComponent = generatedBullet.GetComponent<BulletEnemy>();


        }
        

    }
    
    void Update()
    {

        //onShoot();
        player.setShooting(_shooting);
    }*/
}
