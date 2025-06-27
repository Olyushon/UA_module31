using UnityEngine;

public class Character : MonoDestroyable, IDirectionalMovable, IDirectionalRotatable, IDamagable
{
    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    private int _health;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 Position => transform.position;

    public int Health => _health;
    public bool IsDead => _health <= 0;

    public void Initialize(DirectionalMover mover, DirectionalRotator rotator, int health)
    {
        _mover = mover;
        _rotator = rotator;
        _health = health;

        foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
            initializable.Initialize();
    }

    private void Update()
    {
        _mover?.Update(Time.deltaTime);
        _rotator?.Update(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void TakeDamage(int damage)
    {        
        if (damage <= 0)
        {
            Debug.LogError("Damage is less than 0");
            return;
        }

        _health -= damage;

        Debug.Log($"TakeDamage {damage}, health: {_health}");

        if (_health <= 0)
            Destroy();
    }

}
