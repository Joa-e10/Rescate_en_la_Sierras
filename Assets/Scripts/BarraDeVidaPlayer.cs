using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaPlayer: MonoBehaviour
{
    public Image barraDeVidaPlayer;
    private Player _player;
    private float vidaMaxima;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.Find("player").GetComponent<Player>();
        vidaMaxima = _player.lives;
        
    }

   
    // Update is called once per frame
    void Update()
    {
       barraDeVidaPlayer.fillAmount = _player.lives/vidaMaxima;
        
    }
}
