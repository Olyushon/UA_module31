using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameMode 
{
    public event Action Win;
    public event Action Defeat;

    private Func<bool> WinConditionCompleted;
    private Func<bool> DefeatConditionCompleted;

    private Func<string> WinMessage;
    private Func<string> DefeatMessage;

    private LevelConfig _levelConfig;
    private MainCharacter _mainCharacter;
    private EnemiesSpawner _enemiesSpawner;
    private EnemiesListService _enemiesListService;

    private float _currentTime;
    private float _timeToWin;

    private bool _isRunning;

    public GameMode(
        LevelConfig levelConfig, 
        MainCharacter mainCharacter, 
        EnemiesSpawner enemiesSpawner,
        EnemiesListService enemiesListService)
    {
        _levelConfig = levelConfig;
        _mainCharacter = mainCharacter;
        _enemiesSpawner = enemiesSpawner;
        _enemiesListService = enemiesListService;
    }

    public void Start()
    {
        _currentTime = 0;
        _timeToWin = _levelConfig.TimeToWin;

        switch (_levelConfig.WinCondition)
        {
            case WinCondition.TimeLived:
                WinConditionCompleted = TimeToWinConditionCompleted;
                WinMessage = () => $"You win! Time: {_currentTime.ToString("F2")}";
                break;
            case WinCondition.EnemiesKilled:
                WinConditionCompleted = KilledEnemiesToWinConditionCompleted;
                WinMessage = () => $"You win! Killed enemies: {_enemiesListService.KilledCount}";
                break;
        }

        switch (_levelConfig.DefeatCondition)
        {
            case DefeatCondition.Death:
                DefeatConditionCompleted = MainCharacterIsDeadConditionCompleted;
                DefeatMessage = () => $"You lose! Main character is dead";
                break;
            case DefeatCondition.EnemiesSpawned:
                DefeatConditionCompleted = SpawnedEnemiesToDefeatConditionCompleted;
                DefeatMessage = () => $"You lose! Spawned enemies: {_enemiesListService.Count}";
                break;
        }

        _isRunning = true;
    }

    public void Update(float deltaTime)
    {

        if (_isRunning == false)
            return;

        ProcessEnemiesSpawn(deltaTime);

        ProcessCountingTime(deltaTime);

        if (WinConditionCompleted.Invoke())
        {
            ProcessWin();
            return;
        }

        if (DefeatConditionCompleted.Invoke())
        {
            ProcessDefeat();
            return;
        }
    }

    private void ProcessEnemiesSpawn(float deltaTime)
    {
        _enemiesSpawner.ProcessEnemiesSpawn(deltaTime);
    }

    private void ProcessCountingTime(float deltaTime)
    {
        _currentTime += deltaTime;
    }

    private void ProcessEndGame()
    {
        _isRunning = false;
    }

    private void Clear()
    {
        // _enemiesListService.ClearAndDestroy();
    }

    private void ProcessDefeat()
    {
        ProcessEndGame();
        Debug.Log(DefeatMessage.Invoke());
        Clear();
        Defeat?.Invoke();
    }

    private void ProcessWin()
    {
        ProcessEndGame();
        Debug.Log(WinMessage.Invoke());
        Clear();
        Win?.Invoke();
    }

    private bool TimeToWinConditionCompleted() => _currentTime >= _timeToWin;
    private bool KilledEnemiesToWinConditionCompleted() => _enemiesListService.KilledCount >= _levelConfig.KilledEnemiesToWin;

    private bool SpawnedEnemiesToDefeatConditionCompleted() => _enemiesListService.Count >= _levelConfig.SpawnedEnemiesToDefeat;
    private bool MainCharacterIsDeadConditionCompleted() => _mainCharacter == null || _mainCharacter.IsDead;

}
