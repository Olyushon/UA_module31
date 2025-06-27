using UnityEngine;

public class ByEnemyTouchDamagable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Debug.Log($"By enemy damage: {enemy.Damage}");

            if (TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(enemy.Damage);
        }
    }
}
