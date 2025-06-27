using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfig", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public WinCondition WinCondition { get; private set; }
    [field: SerializeField] public DefeatCondition DefeatCondition { get; private set; }
    [field: SerializeField] public float TimeToWin { get; private set; } = 30;
    [field: SerializeField] public int KilledEnemiesToWin { get; private set; } = 5;
    [field: SerializeField] public int SpawnedEnemiesToDefeat { get; private set; } = 10;

    [field: SerializeField] public Vector3 MainHeroStartPosition { get; private set; }

    [field: SerializeField] public EnemyConfig EnemyConfig { get; private set; }
    [field: SerializeField] public float EnemySpawnPeriod { get; private set; } = 5;
    [field: SerializeField] public List<Vector3> EnemiesSpawnPoints { get; private set; }


    [ContextMenu("UpdateStartHeroPosition")]
    private void UpdateStartHeroPosition()
    {
        GameObject point = GameObject.FindGameObjectWithTag("StartHeroPosition");
        MainHeroStartPosition = point.transform.position;
    }

    [ContextMenu("UpdateEnemiesSpawnPoints")]
    private void UpdateEnemiesSpawnPoints()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        EnemiesSpawnPoints = new List<Vector3>(points.Select(point => point.transform.position));
    }
}
