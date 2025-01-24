using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnDistance = 20f; // Distance minimum du joueur
    [SerializeField] private float maxSpawnDistance = 30f; // Distance maximum du joueur
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int initialEnemyCount = 3;
    [SerializeField] private int enemyIncreaseAmount = 2;
    [SerializeField] private float difficultyIncreaseInterval = 30f;

    private Transform player;
    private int currentEnemyCount;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentEnemyCount = initialEnemyCount;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(IncreaseDifficulty());
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomAngle = Random.Range(0f, 360f);
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
    
        Vector3 direction = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
        Vector3 spawnPosition = player.position + direction * randomDistance;
    
        // Raycast depuis le haut
        RaycastHit hit;
        if (Physics.Raycast(spawnPosition + Vector3.up * 50f, Vector3.down, out hit))
        {
            return hit.point + Vector3.up;  // Ajoute 1 unité en hauteur
        }
    
        return spawnPosition;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < currentEnemyCount; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval / currentEnemyCount);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(difficultyIncreaseInterval);
            currentEnemyCount += enemyIncreaseAmount;
            Debug.Log($"Difficulté augmentée! Nombre d'ennemis: {currentEnemyCount}");
        }
    }
}


