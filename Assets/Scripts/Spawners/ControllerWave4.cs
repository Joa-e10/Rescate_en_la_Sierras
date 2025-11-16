using System;
using UnityEngine;

public class ControllerWave4 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public static event Action OnWave4;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            OnWave4?.Invoke();
            Debug.Log("Entro en el spawn 4");
        }


    }
    // Update is called once per frame
    void Update()
    {

    }
}
