using UnityEngine;

public class ShooterController : Controller
{
    private const KeyCode SHOOT_KEY = KeyCode.Space;
    private ICanShoot _shooter;

    public ShooterController(ICanShoot shooter)
    {
        _shooter = shooter;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetKeyDown(SHOOT_KEY))
        {
            _shooter.Shoot();
        }
    }
}

