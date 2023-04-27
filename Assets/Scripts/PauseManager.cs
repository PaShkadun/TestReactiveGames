using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private EnemyManager _enemyManager;

    [SerializeField] private List<Button> _buttonsLoad;
    [SerializeField] private List<Button> _buttonsSave;

    private const string FileName = "slot{0}.json";

    private void OnEnable()
    {
        for (var i = 1; i <= _buttonsLoad.Count; i++)
        {
            var path = Path.Combine(Application.persistentDataPath, string.Format(FileName, i));
            if (File.Exists(path))
            {
                _buttonsLoad[i - 1].interactable = true;
            }
            else
            {
                _buttonsLoad[i - 1].interactable = false;
            }
        }
    }

    public void OnLoadClick(int slot)
    {
        var path = Path.Combine(Application.persistentDataPath, string.Format(FileName, slot));
        var objectData = GameSaver.LoadGame(path);

        _playerManager.SetPlayersData(objectData.Players);
        _enemyManager.SetEnemiesData(objectData.Enemies);
    }

    public void OnSaveClick(int slot)
    {
        var path = Path.Combine(Application.persistentDataPath, string.Format(FileName, slot));
        GameSaver.SaveGame(path, _playerManager.Players, _enemyManager.Enemies);
    }
}
