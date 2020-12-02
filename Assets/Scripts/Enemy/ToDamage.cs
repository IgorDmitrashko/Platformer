using UnityEngine;

public class ToDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    private Player _player;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            _player.TakeDamage(_damage);          
        }
    }
}
