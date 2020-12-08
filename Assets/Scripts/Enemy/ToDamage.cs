using UnityEngine;

public class ToDamage : MonoBehaviour
{
    private int _damage = 1;
    private Player _player;

    private void Start() {
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        _player = collision.GetComponent<Player>();

        if(_player != null)
        {
            _player.TakeDamage(_damage);
        }
    }
}
