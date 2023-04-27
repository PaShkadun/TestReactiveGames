using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : Enemy
{
    private const string PlayerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == PlayerTag)
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.GetDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}
