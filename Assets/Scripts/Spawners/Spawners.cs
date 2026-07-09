using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    protected Vector2 _newPosicion;
    protected bool _isActive;

    [SerializeField] private GameObject[] _listPrefabs = new GameObject[2];
    [SerializeField] private List<Transform> _listPositions = new List<Transform>();
    [SerializeField] private GameObject _animalKey;
    [SerializeField] private GameObject _doorKey;
    [SerializeField] private int _quantityEnemies;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null) 
        {
            _isActive = true;
            SpawnnerEnemies();
        }
    }

    public void SpawnnerEnemies() 
    {
        GameObject[] _listEnemy = new GameObject[_quantityEnemies];
        GameObject newKey;

        if (_isActive == true)
        {
            for (int i = 0; i < _quantityEnemies; i++)
            {
                int _randomNum = Random.Range(0, 2);
                int _randomPos = Random.Range(0, _listPositions.Count);

                Debug.Log("Estamos haciendo: " + _randomPos);
                Debug.Log("Los enemigos son: " + _randomNum);
                GameObject newEnemy;

                Debug.Log("Entro veces");
                if (_quantityEnemies <= 2)
                {
                    newEnemy = Instantiate(_listPrefabs[0], _listPositions[_randomPos].position, Quaternion.identity);
                    _listEnemy[i] = newEnemy;
                }
                else
                {
                    newEnemy = Instantiate(_listPrefabs[_randomNum], _listPositions[_randomPos].position, Quaternion.identity);
                    _listEnemy[i] = newEnemy;
                }
            }
        }

           _isActive = false;

           /* if (_listEnemy.Length == _quantityEnemies && _isActive == false)
            {
                if (_animalKey == null && _doorKey == null)
                {
                    Debug.Log("No existe ninguna llave");
                }
                else
                {
                    if (_animalKey != null)
                    {
                        newKey = Instantiate(_animalKey, _listPositions[1].position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    if (_doorKey != null)
                    {
                        newKey = Instantiate(_doorKey, _listPositions[1].position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
            }*/
        
    }
    private void Update()
    {
        
    }
}
