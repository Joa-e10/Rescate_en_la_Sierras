using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnWave2 : MonoBehaviour
{
    private int _randomQuantity;
    private int _totalAmount;
    public GameObject enemyBase;
    public GameObject enemyShooting;
    public GameObject keyPrefab;
    private GameObject[] generatedEnemy;
    private EnemyBase _enemyComponent;

    private void OnEnable()
    {
        ControllerWave2.OnWave2 += SpawnerEnemyShoot;

    }
    void Start()
    {
    }

    private IEnumerator SpawnerTime() 
    {
        Debug.Log("Ingreso a la corrutina");
        yield return new WaitForSeconds(10f);

    }

    private void SpawnerEnemyShoot()
    {
        _randomQuantity = Random.Range(4, 6);
        generatedEnemy = new GameObject[_randomQuantity];

        StartCoroutine(SpawnerWithTime());

    }

    private IEnumerator SpawnerWithTime()
    {
        for (int i = 0; i < generatedEnemy.Length; i++)
        {
            if (i <= _randomQuantity/2)
            {
                generatedEnemy[i] = Instantiate(enemyBase, transform.position, Quaternion.identity);
            }
            else 
            {
                generatedEnemy[i] = Instantiate(enemyShooting, transform.position, Quaternion.identity);
            }

            _totalAmount++;

            yield return new WaitForSeconds(2f);
        }

        if (_totalAmount == generatedEnemy.Length)
        {
            GameObject generatedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            ControllerWave2.OnWave2 -= SpawnerEnemyShoot;
        }

    }

    void Update()
    {
    }
}