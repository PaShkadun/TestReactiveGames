using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class EnemySaveInfo
{
    public bool IsAlive;
    public int Damage;
    public float Speed;
    public Vector3 Position;
    public Quaternion Rotation;
}
