using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaBoss : MonoBehaviour
{
    public Image barraDeVidaBoss;
    private FinalBoss _Boss;
    private float vidaMaxima;
    private float vidaMinima;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Boss = GameObject.Find("boss").GetComponent<FinalBoss>();
        vidaMaxima = _Boss.lives;
        

    }
    // Update is called once per frame
    void Update()
    {
        barraDeVidaBoss.fillAmount = _Boss.lives / vidaMaxima;
        if(_Boss._alive == false)
        {
            Destroy(gameObject);
            
        }
    }
}
