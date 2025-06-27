using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage { get; private set; }

    public void Initialize(int damage)
    {
        Damage = damage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
