using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggerwin : MonoBehaviour
{
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            Debug.Log("Entro en el queridisimo colider");
            SceneManager.LoadScene("WinScene");
        }
    }

    void Update()
    {
        
    }
}
