using UnityEngine;

public class RandomAIDirectionalMovableController : Controller
{
    private IDirectionalMovable _movable;

    private float _time;
    private float _timeToChangeDirection;

    Vector3 _inputDirection;

    public RandomAIDirectionalMovableController(IDirectionalMovable movable, float timeToChangeDirection)
    {
        _movable = movable;
        _timeToChangeDirection = timeToChangeDirection;
        _inputDirection = GetRandomDirection();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _time += deltaTime;

        if (_time >= _timeToChangeDirection)
        {
            _inputDirection = GetRandomDirection();
            _time = 0;
        }

        _movable.SetMoveDirection(_inputDirection);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
}
