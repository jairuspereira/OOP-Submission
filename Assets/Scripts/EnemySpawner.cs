using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Vector3 spawnAreaCenter = Vector3.zero;
    public float spawnRange = 20f;

    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 10f;
    public int maxWaves = 10;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < maxWaves)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
            currentWave++;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0f,
            Random.Range(-spawnRange, spawnRange)
        );
        Vector3 spawnPos = spawnAreaCenter + randomOffset;

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject prefab = enemyPrefabs[randomIndex];

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

        Debug.Log($"Wave {currentWave + 1} spawned with {enemiesPerWave} enemies.");
    }
}
