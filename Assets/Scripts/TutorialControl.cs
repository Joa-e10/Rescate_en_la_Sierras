using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    private float _range = 20;
    private float _distanceToPlayer;
    private Transform _player;
    public GameObject tutorialMessage;
    private SpriteRenderer _tutorial;
    


    void Start()
    {
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        _tutorial = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        TutorialDetection();
    }
    private void TutorialDetection()
    {
        _distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (_distanceToPlayer <= _range)
        {
            _tutorial.enabled = true;
        }
        else
        {
            _tutorial.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            tutorialMessage.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            tutorialMessage.SetActive(false);
        }
    }
}
