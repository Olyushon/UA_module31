public class SpawnedEnemiesToDefeatCondition : IEndGameCondition
{
    private int _spawnedEnemiesToDefeat;
    private EnemiesListService _enemiesListService;

    public SpawnedEnemiesToDefeatCondition(int spawnedEnemiesToDefeat, EnemiesListService enemiesListService)
    {
        _spawnedEnemiesToDefeat = spawnedEnemiesToDefeat;
        _enemiesListService = enemiesListService;
    }

    public void Process(float deltaTime) {}

    public bool IsCompleted() => _enemiesListService.Count >= _spawnedEnemiesToDefeat;  

    public string GetMessage() => $"You win! Spawned enemies: {_enemiesListService.Count}";
}
