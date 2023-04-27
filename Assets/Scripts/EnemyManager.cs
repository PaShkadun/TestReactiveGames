using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public List<Enemy> Enemies => _enemies;

    public void SetEnemiesData(List<EnemySaveInfo> enemies)
    {
        if (enemies.Count != _enemies.Count)
        {
            Debug.LogError($"Error while loading enemies...");
        }

        for (var i = 0; i < enemies.Count; i++)
        {
            _enemies[i].Damage = enemies[i].Damage;
            _enemies[i].Speed = enemies[i].Speed;
            _enemies[i].transform.position = enemies[i].Position;
            _enemies[i].transform.rotation = enemies[i].Rotation;
            _enemies[i].gameObject.SetActive(enemies[i].IsAlive);
        }
    }
}
