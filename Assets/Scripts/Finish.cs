using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    private const string PlayerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == PlayerTag)
        {
            _playerManager.PlayerReachFinish(collision.gameObject.GetComponent<Player>());
        }
    }
}
