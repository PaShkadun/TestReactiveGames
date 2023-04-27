using System;
using System.Collections.Generic;

[Serializable]
public class ObjectSaveData
{
    public List<PlayerSaveInfo> Players;
    public List<EnemySaveInfo> Enemies;

    public ObjectSaveData(List<PlayerSaveInfo> players, List<EnemySaveInfo> enemies)
    {
        Players = players;
        Enemies = enemies;
    }
}

