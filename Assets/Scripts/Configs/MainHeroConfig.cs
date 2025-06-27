using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/MainHeroConfig", fileName = "MainHeroConfig")]
public class MainHeroConfig : ScriptableObject
{
    [field: SerializeField] public MainCharacter Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 9;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 900;
    [field: SerializeField] public int Health { get; private set; } = 10;
    [field: SerializeField] public int Damage { get; private set; } = 1;
}
