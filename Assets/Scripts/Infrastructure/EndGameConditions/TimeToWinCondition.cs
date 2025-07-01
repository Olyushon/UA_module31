public class TimeToWinCondition : IEndGameCondition
{
    private float _timeToWin;
    private float _currentTime;

    public TimeToWinCondition(float timeToWin)
    {
        _timeToWin = timeToWin;
    }

    public void Process(float deltaTime) => _currentTime += deltaTime;

    public bool IsCompleted() => _currentTime >= _timeToWin;

    public string GetMessage() => $"You win! Time: {_currentTime.ToString("F2")}";
}
