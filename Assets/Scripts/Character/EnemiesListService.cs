using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesListService
{
    private List<Enemy> _enemies = new();
    private int _totalCount = 0;

    public int Count => _enemies.Count;
    public int KilledCount => _totalCount - _enemies.Count;

    public void Add(Enemy enemy)
    {
        _enemies.Add(enemy);
        _totalCount++;
    }

    public void Update(float deltaTime)
    {
        _enemies.RemoveAll(item => item == null || item.IsDead);
    }

    public void ClearAndDestroy()
    {
        foreach (Enemy enemy in _enemies)
            enemy.Destroy();
        _enemies.Clear();
        _totalCount = 0;
    }
}
