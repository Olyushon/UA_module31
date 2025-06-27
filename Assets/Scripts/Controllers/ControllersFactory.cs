using UnityEngine;

public class ControllersFactory
{
    public CompositeController CreateMainHeroPlayerController(MainCharacter character)
    {
        return new CompositeController(
            CreatePlayerDirectionalMovableController(character),
            CreateAlongMovableVelocityRotatableController(character, character),
            CreateShooterController(character)
            );
    }

    public CompositeController CreateEnemyController(Character character, float timeToChangeDirection)
    {
        return new CompositeController(
            CreateRandomMovableController(character, timeToChangeDirection),
            CreateAlongMovableVelocityRotatableController(character, character)
            );
    }

    private DirectionalMovableController CreatePlayerDirectionalMovableController(IDirectionalMovable movable)
    {
        return new DirectionalMovableController(movable);
    }

    private AlongMovableVelocityRotatableController CreateAlongMovableVelocityRotatableController(
        IDirectionalMovable movable,
        IDirectionalRotatable rotatable)
    {
        return new AlongMovableVelocityRotatableController(rotatable, movable);
    }

    private ShooterController CreateShooterController(ICanShoot shooter)
    {
        return new ShooterController(shooter);
    }

    private RandomAIDirectionalMovableController CreateRandomMovableController(IDirectionalMovable movable, float timeToChangeDirection)
    {
        return new RandomAIDirectionalMovableController(movable, timeToChangeDirection);
    }
}
