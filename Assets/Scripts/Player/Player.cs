using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D _pLayerRigitBody2D;
    private Animator _playerAnimator;

    [SerializeField] private AudioSource _playerAudioJump;
    [SerializeField] private AudioSource _playerAudioDeath;
    [SerializeField] private AudioSource _playerAudioCoins;

    private Material _materialBlick;
    private Material _materialDefault;
    private SpriteRenderer _spriteRend;

    private float speed = 3.4f;
    private float _jumpForce = 2.0f;

    private int _numberscene = 0;
    private int _delayedloadscene = 3;

    [NonSerialized] private HealthPlayerControl _health;

    private SpriteRenderer _playerSpriteRenderer;

    public static Player Singelton { get; private set; }

    public event Action<int> TakeHeatPoint;


    public event Action<AudioSource> DeathEvent;
    public event Action<int, int> LoadingSceneOnDeathEvent;

    public event Action<Animator, AudioSource> JumpEvent;
    public event Action<Animator> DontJumpEvent;

    public event Action<AudioSource> PickUpCoinsEvent;

    [NonSerialized] public bool _isGround;


    private void Awake() {
        Singelton = this;
        _health = GetComponent<HealthPlayerControl>();
        _pLayerRigitBody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        _spriteRend = gameObject.GetComponent<SpriteRenderer>();
        _materialBlick = Resources.Load("EnemyBlick", typeof(Material)) as Material;
        _materialDefault = _spriteRend.material;

    }

    private void FixedUpdate() {
        if(Input.GetButton("Jump") && _isGround)
        {
            Jump();
        }
        else
        {
            DontJumpEvent?.Invoke(_playerAnimator);
        }

    }
    void Update() {

        if(Input.GetButton("Horizontal"))
        {
            _playerAnimator.SetBool("IsMooving", true);
            Move();
        }
        else
        {
            _playerAnimator.SetBool("IsMooving", false);
        }

        if(transform.position.y < -15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(int damage) {
        TakeHeatPoint?.Invoke(damage);
        if(_health.hp <= 0)
        {
            DeathEvent?.Invoke(_playerAudioDeath);
            LoadingSceneOnDeathEvent?.Invoke(_numberscene, _delayedloadscene);
        }
        Twinkle();
    }
  

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Coins")
        {
            if(_playerAudioCoins != null)
            {
                PickUpCoinsEvent?.Invoke(_playerAudioCoins);
            }

        }
    }

    private void Twinkle() {
        _spriteRend.material = _materialBlick;
        Invoke("ResetMaterial", 0.2f);
    }

    private void ResetMaterial() => _spriteRend.material = _materialDefault;

    private void Move() {

        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempVector, speed * Time.deltaTime);

        if(tempVector.x < 0)
        {
            _playerSpriteRenderer.flipX = true;
        }
        else
        {
            _playerSpriteRenderer.flipX = false;
        }

    }

    private void Jump() {
        _pLayerRigitBody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        if(_playerAnimator != null && _playerAudioJump != null)
        {
            JumpEvent?.Invoke(_playerAnimator, _playerAudioJump);
        }

    }
}
