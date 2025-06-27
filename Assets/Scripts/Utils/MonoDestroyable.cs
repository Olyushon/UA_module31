using System;
using UnityEngine;

public class MonoDestroyable : MonoBehaviour
{
    public event Action<MonoDestroyable> Destroyed;

    public bool IsDestroyed { get; private set; }

    public void Destroy()
    {
        Destroy(gameObject);
        Debug.Log($"Destroyed {gameObject.name}");

        IsDestroyed = true;
        Destroyed?.Invoke(this);
    }
}
