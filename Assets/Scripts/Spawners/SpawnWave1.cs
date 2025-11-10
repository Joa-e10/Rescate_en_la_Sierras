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
        ControllerWave1.OnWave1 += SpawnerEnemyBase;
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
        StartCoroutine(SpawnerWhitTime());

        Debug.Log("El total de enemigos invocados: "+totalAmount);

        if (totalAmount == generatedEnemyB.Length)
        {
            Debug.Log("Entro a generar la key");
            GameObject generatedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            ControllerWave1.OnWave1 -= SpawnerEnemyBase;
        }

    }

    private IEnumerator SpawnerWhitTime()
    {

        for (int i = 0; i < generatedEnemyB.Length; i++)
        {

            generatedEnemyB[i] = Instantiate(enemyBase, transform.position, Quaternion.identity);
            _enemyComponent = generatedEnemyB[i].GetComponent<EnemyBase>();
            yield return new WaitForSeconds(2f);
            totalAmount++;
        }

        if (totalAmount == generatedEnemyB.Length)
        {
            GameObject generatedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            ControllerWave1.OnWave1 -= SpawnerEnemyBase;
        }

    }

    void Update()
    {
        
    }
}
