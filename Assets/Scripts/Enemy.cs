using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
}
