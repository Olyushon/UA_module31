using UnityEngine;

public class CharacterControllerDirectionalMover : DirectionalMover
{
    private CharacterController _characterController;

    public CharacterControllerDirectionalMover(CharacterController characterController, float movementSpeed) : base(movementSpeed)
    {
        _characterController = characterController;
    }

    public override void Update(float deltaTime)
    {
        _characterController.Move(CurrentVelocity * deltaTime);

        Vector3 pos = _characterController.transform.position;
        pos.y = 0f;
        _characterController.transform.position = pos;
    }
}
