using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayCycle : IDisposable
{
    private MainHeroFactory _mainHeroFactory;
    private MainHeroConfig _mainHeroConfig;
    private MainCharacter _mainHero;

    private LevelConfig _levelConfig;

    private EnemiesSpawner _enemiesSpawner;
    private EnemiesListService _enemiesListService;

    private ConditionFactory _conditionFactory;

    private GameMode _gameMode;

    public GameplayCycle(
        MainHeroFactory mainHeroFactory, 
        MainHeroConfig mainHeroConfig, 
        LevelConfig levelConfig, 
        EnemiesSpawner enemiesSpawner, 
        EnemiesListService enemiesListService,
        ConditionFactory conditionFactory)
    {
        _mainHeroFactory = mainHeroFactory;
        _mainHeroConfig = mainHeroConfig;
        _levelConfig = levelConfig;
        _enemiesSpawner = enemiesSpawner;
        _enemiesListService = enemiesListService;
        _conditionFactory = conditionFactory;
    }

    public IEnumerator Prepare()
    {
        yield return new WaitForSeconds(0.5f);

        _mainHero = _mainHeroFactory.Create(_mainHeroConfig, _levelConfig.MainHeroStartPosition);
        _conditionFactory.SetMainCharacter(_mainHero);
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(0.5f);

        _gameMode = new GameMode(_enemiesSpawner, _enemiesListService);
        _gameMode.SetWinCondition(_conditionFactory.CreateWinCondition());
        _gameMode.SetDefeatCondition(_conditionFactory.CreateDefeatCondition());

        _gameMode.Win += OnGameModeWin;
        _gameMode.Defeat += OnGameModeDefeat;

        _gameMode.Start();
    }

    public void Update(float deltaTime) => _gameMode?.Update(deltaTime);

    private void OnGameModeEnded()
    {
        if(_gameMode != null)
        {
            _gameMode.Win -= OnGameModeWin;
            _gameMode.Defeat -= OnGameModeDefeat;
        }
    }

    public void Dispose()
    {
        OnGameModeEnded();
    }

    private void OnGameModeDefeat()
    {
        OnGameModeEnded();
        Debug.Log("Defeat");
    }

    private void OnGameModeWin()
    {
        OnGameModeEnded();
        Debug.Log("Win");
    }
}
