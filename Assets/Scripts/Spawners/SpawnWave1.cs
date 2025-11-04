using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnWave1 : MonoBehaviour
{
    private int totalAmount;
    public GameObject enemyBase;
    public GameObject keyPrefab;
    private GameObject[] generatedEnemyB = new GameObject[3];
    private EnemyBase _enemyComponent;

    private void OnEnable()
    {
        SpawnBaseController.OnWave1 += SpawnerEnemyBase;
    }
    void Start()
    {
    }

    private IEnumerator SpawnerTime()
    {
        Debug.Log("Ingreso a la corrutina");
        yield return new WaitForSeconds(10f);

    }

    private void SpawnerEnemyBase()
    {
        for (int i = 0; i < generatedEnemyB.Length; i++)
        {

            generatedEnemyB[i] = Instantiate(enemyBase, transform.position, Quaternion.identity);
            _enemyComponent = generatedEnemyB[i].GetComponent<EnemyBase>();

            StartCoroutine(SpawnerTime());
            totalAmount++;
        }

        if (totalAmount == generatedEnemyB.Length)
        {
            Debug.Log("Entro a generar la key");
            GameObject generatedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            SpawnBaseController.OnWave1 -= SpawnerEnemyBase;
        }

    }
    void Update()
    {
        
    }
}
