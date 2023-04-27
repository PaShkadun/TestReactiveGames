using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public static class GameSaver
{
    public static void SaveGame(string path, List<Player> players, List<Enemy> enemies)
    {
        var playerInfo = new List<PlayerSaveInfo>(players.Count);
        var enemiesInfo = new List<EnemySaveInfo>(enemies.Count);

        try
        {
            for (var i = 0; i < players.Count; i++)
            {
                playerInfo.Add(new PlayerSaveInfo()
                {
                    Hp = players[i].Hp,
                    Speed = players[i].Speed,
                    Position = players[i].transform.position,
                    Rotation = players[i].transform.rotation
                });
            }

            for (var i = 0; i < enemies.Count; i++)
            {
                enemiesInfo.Add(new EnemySaveInfo()
                {
                    Speed = enemies[i].Speed,
                    Damage = enemies[i].Damage,
                    IsAlive = enemies[i].isActiveAndEnabled,
                    Position = enemies[i].transform.position,
                    Rotation = enemies[i].transform.rotation
                });
            }
            var objectInfo = new ObjectSaveData(playerInfo, enemiesInfo);
            var json = JsonUtility.ToJson(objectInfo);

            File.WriteAllText(path, json);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public static ObjectSaveData LoadGame(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("File is not exists.");
        }

        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<ObjectSaveData>(json);
        return data;
    }
}
