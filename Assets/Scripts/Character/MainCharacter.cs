using UnityEngine;

public class MainCharacter : Character, ICanShoot
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Transform _bulletSpawnPoint;

    public Transform CameraTarget => _cameraTarget;

    private BulletFactory _bulletFactory;

    public void SetBulletFactory(BulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    public void Shoot()
    {
        _bulletFactory.CreateAndShoot(_bulletSpawnPoint.position, transform.forward);
    }
    
}
