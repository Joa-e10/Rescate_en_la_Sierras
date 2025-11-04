using System;
using UnityEngine;

public class SpawnShootController : MonoBehaviour
{
    void Start()
    {

    }

    public static event Action OnWave2;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            OnWave2?.Invoke();
            Debug.Log("Entro en el spawn 1");
        }


    }
    void Update()
    {

    }
}
