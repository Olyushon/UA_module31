public class KilledEnemiesToWinCondition : IEndGameCondition
{
    private int _killedEnemiesToWin;
    private EnemiesListService _enemiesListService;


    public KilledEnemiesToWinCondition(int killedEnemiesToWin, EnemiesListService enemiesListService)
    {
        _killedEnemiesToWin = killedEnemiesToWin;
        _enemiesListService = enemiesListService;
    }

    public void Process(float deltaTime) {}

    public bool IsCompleted() => _enemiesListService.KilledCount >= _killedEnemiesToWin;

    public string GetMessage() => $"You win! Killed enemies: {_enemiesListService.KilledCount}";
}