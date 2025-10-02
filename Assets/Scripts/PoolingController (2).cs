using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    [SerializeField] private SimpleObjectPooling _enemy;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private Vector3 spawnRangeY = new Vector2(-4f, 4f); 
    [SerializeField] private float spawnX = 10f;

    private float _timer = 0f;
    private int _countObstacles = 0;


    private void Awake()
    {
        _enemy.SetUp(this.transform);
        _enemy.onEnableObject += CountSpawnedEnemies;
    }

    private void OnDisable()
    {
        _enemy.onEnableObject -= CountSpawnedEnemies;
    }

    private void FixedUpdate()
    {

        if (!canSpawn) return;

        _timer += Time.deltaTime;

        if (_timer >= spawnRate)
        {
            GameObject obstacle = _enemy.GetObject();
            float randomY = UnityEngine.Random.Range(spawnRangeY.x, spawnRangeY.y);
            obstacle.transform.position = new Vector3(spawnX, randomY, 0f);

            _timer = 0f;
        }
    }

    private void CountSpawnedEnemies()
    {
        _countObstacles++;
        //Debug.Log("Obstáculos generados: " + _countObstacles);
    }
}
