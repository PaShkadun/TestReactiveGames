using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdEnemy : Enemy
{
    [SerializeField] private Bullet _bullet;

    private const float TimeBetweenShots = 2f;

    private float _lastShotTime;

    private void OnTriggerEnter(Collider collider)
    {
        ShotIfNeed(collider);
    }

    private void OnTriggerStay(Collider collider)
    {
        ShotIfNeed(collider);
    }

    private void ShotIfNeed(Collider collider)
    {
        Debug.Log("Shot!");
        if (_lastShotTime + TimeBetweenShots < Time.time)
        {
            _lastShotTime = Time.time;
            var bullet = Instantiate<Bullet>(_bullet, transform.parent);
            bullet.transform.position = transform.position;
            bullet.transform.LookAt(collider.transform);
        }
    }
}
