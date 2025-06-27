using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/EnemyConfig", fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 900;
    [field: SerializeField] public float TimeToChangeDirection { get; private set; } = 3;
    [field: SerializeField] public int Health { get; private set; } = 1;
    [field: SerializeField] public int Damage { get; private set; } = 1;
}
