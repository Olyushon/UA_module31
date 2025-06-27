using Cinemachine;
using UnityEngine;

public class MainHeroFactory 
{
    private ControllersUpdateService _controllersUpdateService;
    private ControllersFactory _controllersFactory;
    private CharactersFactory _charactersFactory;
    private BulletFactory _bulletFactory;

    public MainHeroFactory(
        ControllersUpdateService controllersUpdateService,
        ControllersFactory controllersFactory,
        CharactersFactory charactersFactory, 
        BulletFactory bulletFactory)
    {
        _controllersUpdateService = controllersUpdateService;
        _controllersFactory = controllersFactory;
        _charactersFactory = charactersFactory;
        _bulletFactory = bulletFactory;
    }

    public MainCharacter Create(
        MainHeroConfig config, 
        Vector3 spawnPosition)
    {
        MainCharacter instance = _charactersFactory.CreateCharacter(
            config.Prefab, 
            spawnPosition, 
            config.MoveSpeed, 
            config.RotationSpeed,
            config.Health)
            as MainCharacter;

        instance.SetBulletFactory(_bulletFactory);

        CinemachineVirtualCamera followCameraPrefab = Resources.Load<CinemachineVirtualCamera>("FollowCamera");
        CinemachineVirtualCamera followCamera = Object.Instantiate(followCameraPrefab);
        followCamera.Follow = instance.CameraTarget;

        Controller controller = _controllersFactory.CreateMainHeroPlayerController(instance);
        controller.Enable();
        _controllersUpdateService.Add(controller, () => instance.IsDestroyed);

        return instance;
    }
}
