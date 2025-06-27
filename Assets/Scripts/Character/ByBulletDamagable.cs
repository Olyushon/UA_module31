using UnityEngine;

public class ByBulletDamagable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            Debug.Log($"By bullet damage: {bullet.Damage}");

            if (TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(bullet.Damage);

            bullet.Destroy();
        }
    }
}
