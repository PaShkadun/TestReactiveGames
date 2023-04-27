using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Action<Player> PlayerChanged;

    [SerializeField] private Camera _camera;
    [SerializeField] private List<Player> _players;
    [SerializeField] private GameplayManager _gameManager;

    public List<Player> Players => _players;

    private const int WallLayer = 1 << 6;

    private const float DistanceToCamera = 30f;
    private const float MaxDistanceRaycast = 1f;

    private int _selectedPlayer = -1;

    public void PlayerReachFinish(Player player)
    {
        _players.Remove(player);
        Destroy(player.gameObject);

        if (_players.Count == 0)
        {
            _gameManager.GameOver();
            return;
        }

        ChangeSelectedPlayer();
    }

    public void CheckPlayerHp(int hp)
    {
        if (hp <= 0)
            _gameManager.GameOver();
    }

    public void SetPlayersData(List<PlayerSaveInfo> players)
    {
        if (players.Count != _players.Count)
        {
            Debug.LogError($"Error while loading players...");
        }

        for (var i = 0; i < players.Count; i++)
        {
            _players[i].Hp = players[i].Hp;
            _players[i].Speed = players[i].Speed;
            _players[i].transform.position = players[i].Position;
            _players[i].transform.rotation = players[i].Rotation;
        }

        _camera.transform.position = new Vector3(_players[_selectedPlayer].transform.position.x, DistanceToCamera, 0);
    }

    private void Start()
    {
        ChangeSelectedPlayer();
    }

    private void Update()
    {
        var horizontAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        if (!Physics.Raycast(_players[_selectedPlayer].transform.position, Vector3.forward * verticalAxis, MaxDistanceRaycast, WallLayer))
        {
            var distance = Vector3.forward * verticalAxis * _players[_selectedPlayer].Speed * Time.deltaTime;

            _players[_selectedPlayer].transform.position += distance;
        }

        if (!Physics.Raycast(_players[_selectedPlayer].transform.position, Vector3.right * horizontAxis, MaxDistanceRaycast, WallLayer))
        {
            var distance = Vector3.right * horizontAxis * _players[_selectedPlayer].Speed * Time.deltaTime;

            _players[_selectedPlayer].transform.position += distance;
            _camera.transform.position += distance;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            var json = JsonUtility.ToJson(_players);
            Debug.Log(json);
            ChangeSelectedPlayer();
        }
    }

    private void ChangeSelectedPlayer()
    {
        _selectedPlayer = _selectedPlayer + 1 >= _players.Count ? 0 : _selectedPlayer + 1;

        _camera.transform.position = new Vector3(_players[_selectedPlayer].transform.position.x, DistanceToCamera, 0);

        PlayerChanged?.Invoke(_players[_selectedPlayer]);
    }
}
