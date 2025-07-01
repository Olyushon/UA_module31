public class ConditionFactory
{
    private LevelConfig _levelConfig;
    private EnemiesListService _enemiesListService;
    private MainCharacter _mainCharacter;

    public ConditionFactory(LevelConfig levelConfig, EnemiesListService enemiesListService)
    {
        _levelConfig = levelConfig;
        _enemiesListService = enemiesListService;
    }

    public void SetMainCharacter(MainCharacter mainCharacter)
    {
        _mainCharacter = mainCharacter;
    }

    public IEndGameCondition CreateWinCondition()
    {
        switch (_levelConfig.WinCondition)
        {
            case WinCondition.TimeLived:
                return new TimeToWinCondition(_levelConfig.TimeToWin);
            case WinCondition.EnemiesKilled:
                return new KilledEnemiesToWinCondition(_levelConfig.KilledEnemiesToWin, _enemiesListService);
        }
        return null;
    }

    public IEndGameCondition CreateDefeatCondition()
    {
        switch (_levelConfig.DefeatCondition)
        {
            case DefeatCondition.Death:
                return new MainCharacterIsDeadCondition(_mainCharacter);
            case DefeatCondition.EnemiesSpawned:
                return new SpawnedEnemiesToDefeatCondition(_levelConfig.SpawnedEnemiesToDefeat, _enemiesListService);
        }
        return null;
    }
}
