using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnWave2 : MonoBehaviour
{
    private int totalAmount;
    public GameObject enemyBase;
    public GameObject enemyShooting;
    public GameObject keyPrefab;
    private GameObject[] generatedEnemyB = new GameObject[3];
    private GameObject[] generatedEnemyS = new GameObject[3];
    private EnemyBase _enemyComponent;

    private void OnEnable()
    {
        SpawnShootController.OnWave2 += SpawnerEnemyShoot;

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

        for (int i = 0; i < generatedEnemyB.Length; i++)
        {

            generatedEnemyB[i] = Instantiate(enemyBase, transform.position, Quaternion.identity);
            _enemyComponent = generatedEnemyB[i].GetComponent<EnemyBase>();
            generatedEnemyS[i] = Instantiate(enemyShooting, transform.position, Quaternion.identity);
            _enemyComponent = generatedEnemyS[i].GetComponent<EnemyBase>();

            StartCoroutine(SpawnerTime());
            totalAmount++;
        }

        if (totalAmount == generatedEnemyS.Length)
        {
            GameObject generatedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            SpawnShootController.OnWave2 -= SpawnerEnemyShoot;
        }

    }

    /* public void SetPosition(Vector2 actualPosition)
     {
         _positionDie = actualPosition;
     }

     public void SetAlive(bool actualAlive)
     {
         _isAlive = actualAlive;
     }*/

    void Update()
    {
    }
}