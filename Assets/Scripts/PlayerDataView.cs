using TMPro;
using UnityEngine;

public class PlayerDataView : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _speedText;

    private Player _currentPlayer;

    private string _defaultHpText;
    private string _defaultSpeedText;
    
    private void Awake()
    {
        _playerManager.PlayerChanged += PlayerChanged;
        _defaultHpText = _hpText.text;
        _defaultSpeedText = _speedText.text;
    }

    private void OnDestroy()
    {
        _playerManager.PlayerChanged -= PlayerChanged;
        _currentPlayer.HpChanged -= PlayerHpChanged;
    }

    private void PlayerChanged(Player player)
    {
        if (_currentPlayer)
            _currentPlayer.HpChanged -= PlayerHpChanged;

        _currentPlayer = player;

        player.HpChanged -= PlayerHpChanged;
        player.HpChanged += PlayerHpChanged;

        _hpText.text = string.Format(_defaultHpText, player.Hp);
        _speedText.text = string.Format(_defaultSpeedText, player.Speed);
    }

    private void PlayerHpChanged(int newValue)
    {
        _hpText.text = string.Format(_defaultHpText, newValue);
        _playerManager.CheckPlayerHp(newValue);
    }
}
