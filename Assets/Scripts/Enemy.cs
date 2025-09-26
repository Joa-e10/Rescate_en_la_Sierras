using UnityEngine;

public class Enemy : Characters
{
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("player").GetComponent<Transform>();
    }


    void Update()
    {
        moveCharacter();
        Debug.Log($"Vida total: {GetLives()}");
    }
}
