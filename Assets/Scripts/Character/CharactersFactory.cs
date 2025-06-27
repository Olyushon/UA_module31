using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class CharactersFactory 
{
    public T CreateCharacter<T>(
        T prefab,
        Vector3 spawnPosition,
        float moveSpeed,
        float rotationSpeed,
        int health)
        where T : Character
    {
        T instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity, null);

        DirectionalMover mover;
        DirectionalRotator rotator;

        if (instance.TryGetComponent(out CharacterController characterController))
        {
            mover = new CharacterControllerDirectionalMover(characterController, moveSpeed);
            rotator = new TransformDirectionalRotator(instance.transform, rotationSpeed);
        }
        else
        {
            throw new InvalidOperationException("Not found mover component");
        }

        instance.Initialize(mover, rotator, health);

        return instance;
    }
}
