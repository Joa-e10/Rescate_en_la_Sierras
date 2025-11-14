using UnityEngine;


public class LetterController : MonoBehaviour
{
    private float _range = 20;
    private bool _isOpen;
    private float _distanceToPlayer;
    private Transform _player;
    public GameObject missionMessage;
    private SpriteRenderer _letterSprite;
    private Animator _animator;


    void Start()
    {
        _player = GameObject.Find("player").GetComponent<Transform>(); // Toma el componente "transform" del objeto llamado "player".
        _animator = GetComponent<Animator>();
        _letterSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        LetterDetection();
    }
    private void LetterDetection() 
    {
        _distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (_distanceToPlayer <= _range)
        {
            _letterSprite.enabled = true;
        }
        else
        {
            _letterSprite.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null) 
        {
            _isOpen = true;
            _animator.SetBool("isOpen", _isOpen);
            missionMessage.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            missionMessage.SetActive(false);
        }
    }
}
