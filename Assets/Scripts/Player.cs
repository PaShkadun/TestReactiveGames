using System;
using UnityEngine;

[Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] public int _hp;
    [SerializeField] public float _speed;

    public Action<int> HpChanged;

    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public void GetDamage(int damage)
    {
        _hp -= damage;
        HpChanged?.Invoke(_hp);
    }
}
