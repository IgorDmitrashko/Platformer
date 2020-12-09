using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _pLayerRigitBody2D;
    private Animator _playerAnimator;

    public Joystick joystick;

    [SerializeField] private AudioSource _playerAudioJump;
    [SerializeField] private AudioSource _playerAudioDeath;
    [SerializeField] private AudioSource _playerAudioCoins;
    [SerializeField] private AudioSource _playerAudioDamage;
    [SerializeField] private AudioSource _playerAudioShot;

    private Material _materialBlick;
    private Material _materialDefault;
    private SpriteRenderer _spriteRend;


    private readonly float _speed = 3.6f;
    private readonly float _jumpForce = 2.0f;
    private float _moveInput;

    private int _numberscene = 0;
    private int _delayedloadscene = 3;
    private bool _playerTurnRight;
    private bool doubleJump = false;

    [NonSerialized] private HealthPlayerControl _health;
    private SpriteRenderer _playerSpriteRenderer;

    public static Player Singelton { get; private set; }
    public bool managementAllowed = true;

    public event Action<int> TakeHeatPointEvent;
    public event Action<AudioSource> DamageSoundEvent;
    public event Action<AudioSource> ShotEvent;


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
        if(joystick.Vertical >= 0.5f && _isGround)
        {
            Jump();

        }        
        else
        {
            DontJumpEvent?.Invoke(_playerAnimator);
        }
    }
    void Update() {

        if(joystick.Horizontal != 0)
        {
            _playerAnimator.SetBool("IsMooving", true);
            _moveInput = joystick.Horizontal;
            Move();
        }
        else
        {
            _playerAnimator.SetBool("IsMooving", false);
        }

        if(transform.position.y <= -10 && transform.position.y > -10.5f)
        {
            Death();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shot();
        }
    }

    public void TakeDamage(int damage) {
        TakeHeatPointEvent?.Invoke(damage);
        DamageSoundEvent?.Invoke(_playerAudioDamage);
        if(_health.hp <= 0)
        {
            Death();
            LoadingSceneOnDeathEvent?.Invoke(_numberscene, _delayedloadscene);
        }
        Twinkle();
    }

    public void Shot() {
        ShotEvent?.Invoke(_playerAudioShot);
    }

    private void Death() {
        DeathEvent?.Invoke(_playerAudioDeath);
        LoadingSceneOnDeathEvent?.Invoke(_numberscene, _delayedloadscene);
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
        Vector3 tempVector = Vector3.right * _moveInput;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempVector, _speed * Time.deltaTime);

        if(tempVector.x < 0 && !_playerTurnRight)
        {
            transform.Rotate(0, 180, 0);
            _playerTurnRight = true;
        }
        else if(tempVector.x > 0 && _playerTurnRight)
        {
            transform.Rotate(0, 180, 0);
            _playerTurnRight = false;
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
