using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/BulletConfig", fileName = "BulletConfig")]
public class BulletConfig : ScriptableObject
{
    [field: SerializeField] public Bullet Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 20;
    [field: SerializeField] public float TimeToDestroy { get; private set; } = 2;
    [field: SerializeField] public int Damage { get; private set; } = 1;
}

