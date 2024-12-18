using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

[Header("References")]
[SerializeField] private GameObject[] enemyPrefabs;
[SerializeField] private Bullet Bullet;

[Header("Attributes")]
[SerializeField] private int baseEnemies = 8;
[SerializeField] private float enemiesPerSecond = 0.5f;
[SerializeField] private float timeBetweenWaves = 5f;
[SerializeField] private float difficultyScalingFactor = 0.75f;

[Header("Events")]
public static UnityEvent onEnemyDestroy = new UnityEvent(); 

public int currentWave = 1;
private float timeSinceLastSpawn; 
private int enemiesAlive;
private int enemiesLeftToSpawn;
private bool isSpawning = false;

private void Awake() {
    onEnemyDestroy.AddListener(EnemyDestroyed);
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startingPoint.position, Quaternion.identity);
        Debug.Log("spawn Enemy"); 
    }

    private int EnemiesPerWave() {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

     // Update is called once per frame
    private void Update()
    {
        if (!isSpawning) return; 

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0) {
            EndWave();
        }
    }

    private void EndWave() {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
        if (currentWave >= 10) {
            SceneManager.LoadScene(3);
        }
    }
}
