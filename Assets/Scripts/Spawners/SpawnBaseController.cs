using System;
using UnityEngine;

public class SpawnBaseController : MonoBehaviour
{
    void Start()
    {

    }

    public static event Action OnWave1;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        
        if (player != null)
        {
            OnWave1?.Invoke();
            Debug.Log("Entro en el spawn 1");
        }

        
    }
    void Update()
    {

    }
}
