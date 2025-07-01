public interface IEndGameCondition
{
    void Process(float deltaTime);
    
    bool IsCompleted();

    string GetMessage();
}
