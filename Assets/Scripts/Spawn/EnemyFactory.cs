using UnityEngine;

public class EnemyFactory 
{
    private ControllersUpdateService _controllersUpdateService;
    private ControllersFactory _controllersFactory;
    private CharactersFactory _charactersFactory;

    public EnemyFactory(
        ControllersUpdateService controllersUpdateService, 
        ControllersFactory controllersFactory, 
        CharactersFactory charactersFactory)
    {
        _controllersUpdateService = controllersUpdateService;
        _controllersFactory = controllersFactory;
        _charactersFactory = charactersFactory;
    }

    public Enemy CreateEnemy(
        EnemyConfig config,
        Vector3 spawnPosition)
    {
        Enemy instance = _charactersFactory.CreateCharacter(
            config.Prefab, 
            spawnPosition, 
            config.MoveSpeed, 
            config.RotationSpeed,
            config.Health)
            as Enemy;

        Controller controller = _controllersFactory.CreateEnemyController(instance, config.TimeToChangeDirection);
        controller.Enable();
        _controllersUpdateService.Add(controller, () => instance.IsDestroyed);

        instance.SetDamage(config.Damage);

        return instance;
    }
}
