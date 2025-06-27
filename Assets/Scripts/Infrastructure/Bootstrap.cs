using Cinemachine;
using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ControllersUpdateService _controllersUpdateService;
    private EnemiesListService _enemiesListService;

    private GameplayCycle _gameplayCycle;

    private void Awake()
    {
        StartCoroutine(StartProcess());
    }

    private IEnumerator StartProcess()
    {
        MainHeroConfig heroConfig = Resources.Load<MainHeroConfig>("MainHeroConfig");
        LevelConfig levelConfig = Resources.Load<LevelConfig>("LevelConfig");
        BulletConfig bulletConfig = Resources.Load<BulletConfig>("BulletConfig");

        _controllersUpdateService = new ControllersUpdateService();

        ControllersFactory controllersFactory = new ControllersFactory();
        CharactersFactory charactersFactory = new CharactersFactory();
        BulletFactory bulletFactory = new BulletFactory(bulletConfig);

        MainHeroFactory mainHeroFactory = new MainHeroFactory(_controllersUpdateService, controllersFactory, charactersFactory, bulletFactory);
        EnemyFactory enemyFactory = new EnemyFactory(_controllersUpdateService, controllersFactory, charactersFactory);
        
        _enemiesListService = new EnemiesListService();
        EnemiesSpawner enemiesSpawner = new EnemiesSpawner(
            enemyFactory, 
            _enemiesListService,
            levelConfig.EnemyConfig,
            levelConfig.EnemiesSpawnPoints,
            levelConfig.EnemySpawnPeriod
            );

        _gameplayCycle = new GameplayCycle(
            mainHeroFactory,
            heroConfig,
            levelConfig,
            enemiesSpawner,
            _enemiesListService);

        yield return _gameplayCycle.Prepare();

        yield return _gameplayCycle.Launch();
    }

    private void OnDestroy()
    {
        _gameplayCycle?.Dispose();
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
        _enemiesListService?.Update(Time.deltaTime);

        _gameplayCycle?.Update(Time.deltaTime);
    }
}
