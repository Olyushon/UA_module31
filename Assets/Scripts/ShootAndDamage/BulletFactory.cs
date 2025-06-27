using UnityEngine;
using Object = UnityEngine.Object;

public class BulletFactory
{
    private BulletConfig _bulletConfig;

    public BulletFactory(BulletConfig bulletConfig)
    {
        _bulletConfig = bulletConfig;
    }

    public void CreateAndShoot(Vector3 spawnPosition, Vector3 direction)
    {
        Bullet bullet = Object.Instantiate(_bulletConfig.Prefab, spawnPosition, Quaternion.identity);
        bullet.Initialize(_bulletConfig.Damage);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
            rb.velocity = direction * _bulletConfig.Speed;

        Object.Destroy(bullet?.gameObject, _bulletConfig.TimeToDestroy);
    }

}
