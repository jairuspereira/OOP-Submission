using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Vector3 spawnAreaCenter = Vector3.zero;
    [SerializeField] private float innerRadius = 10f;
    [SerializeField] private float outerRadius = 20f;

    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private int maxWaves = 10;

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < maxWaves)
        {
            SpawnWave();
            currentWave++;

            // Wait until all enemies are destroyed before starting the next wave
            yield return new WaitUntil(() => GameObject.FindObjectsByType<BaseEnemy>(0).Length == 0);
        }
    }

    private void SpawnWave()
    {
        int typeCount = Mathf.Min(currentWave + 1, enemyPrefabs.Length);

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnPos = GetRandomDonutPosition();
            int randomIndex = (typeCount == 1) ? 0 : Random.Range(0, typeCount);
            GameObject prefab = enemyPrefabs[randomIndex];
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }

        Debug.Log($"Wave {currentWave + 1} spawned with {enemiesPerWave} enemies from {typeCount} types.");
    }

    private Vector3 GetRandomDonutPosition()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float radius = Mathf.Sqrt(Random.Range(innerRadius * innerRadius, outerRadius * outerRadius));
        float x = spawnAreaCenter.x + radius * Mathf.Cos(angle);
        float z = spawnAreaCenter.z + radius * Mathf.Sin(angle);
        return new Vector3(x, spawnAreaCenter.y, z);
    }
}