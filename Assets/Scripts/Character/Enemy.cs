using UnityEngine;

public class Enemy : Character
{
    public int Damage { get; private set; }

    public void SetDamage(int damage)
    {
        Damage = damage;
    }
}
