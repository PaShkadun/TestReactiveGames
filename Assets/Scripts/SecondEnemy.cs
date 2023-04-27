using UnityEngine;

public class SecondEnemy : Enemy
{
    private const string PlayerTag = "Player";

    private Player _player;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == PlayerTag)
        {
            _player = collider.GetComponent<Player>();
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject == _player.gameObject)
        {
            transform.LookAt(_player.transform);
            transform.position += gameObject.transform.forward * Time.deltaTime * _speed;

            var distance = Vector3.Distance(transform.position, _player.transform.position);

            if (distance < transform.localScale.x)
            {
                _player.GetDamage(_damage);
                _player = null;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == PlayerTag)
        {
            _player = null;
        }
    }
}
