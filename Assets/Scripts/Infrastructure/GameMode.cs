using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameMode 
{
    public event Action Win;
    public event Action Defeat;

    private IEndGameCondition _winCondition;
    private IEndGameCondition _defeatCondition;

    private EnemiesSpawner _enemiesSpawner;
    private EnemiesListService _enemiesListService;

    private bool _isRunning;

    public GameMode(
        EnemiesSpawner enemiesSpawner,
        EnemiesListService enemiesListService)
    {
        _enemiesSpawner = enemiesSpawner;
        _enemiesListService = enemiesListService;
    }

    public void Start()
    {
        _isRunning = true;
    }

    public void SetWinCondition(IEndGameCondition winCondition)
    {
        _winCondition = winCondition;
    }

    public void SetDefeatCondition(IEndGameCondition defeatCondition)   
    {
        _defeatCondition = defeatCondition;
    }

    public void Update(float deltaTime)
    {
        if (_isRunning == false)
            return;

        ProcessEnemiesSpawn(deltaTime);

        _winCondition?.Process(deltaTime);
        _defeatCondition?.Process(deltaTime);

        if (_winCondition != null && _winCondition.IsCompleted())
        {
            ProcessWin();
            return;
        }

        if (_defeatCondition != null && _defeatCondition.IsCompleted())
        {
            ProcessDefeat();
            return;
        }
    }

    private void ProcessEnemiesSpawn(float deltaTime)
    {
        _enemiesSpawner.ProcessEnemiesSpawn(deltaTime);
    }

    private void ProcessEndGame()
    {
        _isRunning = false;
    }

    private void ProcessDefeat()
    {
        ProcessEndGame();
        Debug.Log(_defeatCondition.GetMessage());
        Clear();
        Defeat?.Invoke();
    }

    private void ProcessWin()
    {
        ProcessEndGame();
        Debug.Log(_winCondition.GetMessage());
        Clear();
        Win?.Invoke();
    }

    private void Clear()
    {
        // _enemiesListService.ClearAndDestroy();
    }
}
