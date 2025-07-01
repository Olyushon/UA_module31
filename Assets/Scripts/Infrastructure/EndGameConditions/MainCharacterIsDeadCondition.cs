public class MainCharacterIsDeadCondition : IEndGameCondition
{
    private MainCharacter _mainCharacter;

    public MainCharacterIsDeadCondition(MainCharacter mainCharacter)
    {
        _mainCharacter = mainCharacter;
    }

    public void Process(float deltaTime) {}

    public bool IsCompleted() => _mainCharacter == null || _mainCharacter.IsDead;

    public string GetMessage() => "You lose! Main character is dead.";
}
