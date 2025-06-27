using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemiesSpawner
{
    private EnemyFactory _enemyFactory;
    private EnemiesListService _enemiesListService;
    private EnemyConfig _enemyConfig;   
    private List<Vector3> _spawnPoints;
    private float _enemySpawnPeriod;
    private float _time = 0;

    public EnemiesSpawner(
        EnemyFactory enemyFactory, 
        EnemiesListService enemiesListService,
        EnemyConfig enemyConfig,
        List<Vector3> spawnPoints,
        float enemySpawnPeriod
        )
    {
        _enemyFactory = enemyFactory;
        _enemiesListService = enemiesListService;
        _enemyConfig = enemyConfig;
        _spawnPoints = spawnPoints;
        _enemySpawnPeriod = enemySpawnPeriod;
    }

    public void ProcessEnemiesSpawn(float deltaTime)
    {
        _time += deltaTime;

        if (_time >= _enemySpawnPeriod)
        {
            _enemiesListService.Add(_enemyFactory.CreateEnemy(_enemyConfig, _spawnPoints[Random.Range(0, _spawnPoints.Count)]));
            _time = 0;
        }
    }
}
