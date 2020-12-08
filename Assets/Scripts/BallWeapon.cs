using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWeapon : MonoBehaviour
{
    private float _speed = 10;
    private int _damage = 1;

    [SerializeField] private Rigidbody2D _rb;
    private Enemy _enemy;

    private void Start() {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        _enemy = collision.GetComponent<Enemy>();
        if(_enemy != null)
        {
            _enemy.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
