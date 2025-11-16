using UnityEngine;
using System;
public class ControllerWave3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public static event Action OnWave3;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            OnWave3?.Invoke();
            Debug.Log("Entro en el spawn 3");
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
