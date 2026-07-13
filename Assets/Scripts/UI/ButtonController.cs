using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void NewGameButton()
    {
        Debug.Log("Se toco el boton");
        SceneManager.LoadScene("SampleScene");
    
    }
}
