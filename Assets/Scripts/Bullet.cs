using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private const string PlayerTag = "Player";

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == PlayerTag)
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}
