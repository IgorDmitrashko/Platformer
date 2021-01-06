using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _pLayerRigitBody2D;
    private Animator _playerAnimator;
    public Joystick joystick;

    private Material _materialBlick;
    private Material _materialDefault;
    private SpriteRenderer _spriteRend;


    private float _speed = 3.6f;
    private readonly float _jumpForce = 5.0f;
    private float _moveInput;



    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }


   
    private bool _playerTurnRight;
    private bool _isMooving = true;

    [NonSerialized] private HealthPlayerControl _health;
    private SpriteRenderer _playerSpriteRenderer;

    public static Player Singleton { get; private set; }

    public bool managementAllowed = true;

    public event Action<int> TakeHeatPointEvent;
    public event Action DamageSoundEvent;
    public event Action ShotEvent;


    public event Action DeathEvent;
    public event Action EndGameEvent;

    public event Action<Animator> JumpEvent;
    public event Action<Animator> DontJumpEvent;

    public event Action PickUpCoinsEvent;
    [NonSerialized] public bool _isGround;


    private void Awake() {
        Singleton = this;
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

    void Update() {

        if(joystick.Horizontal != 0 && _isMooving)
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void TakeDamage(int damage) {
        TakeHeatPointEvent?.Invoke(damage);
        DamageSoundEvent?.Invoke();
        if(_health.hp <= 0)
        {
            Death();
            EndGameEvent?.Invoke();
        }
        Twinkle();
    }

    public void Shot() {
        ShotEvent?.Invoke();
    }

    private void Death() {
        DeathEvent?.Invoke();
        EndGameEvent?.Invoke();
        _isMooving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Coins")
        {
            PickUpCoinsEvent?.Invoke();
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

    public void Jump() {      
        if(_playerAnimator != null && _isGround)
        {
            JumpEvent?.Invoke(_playerAnimator);
            _pLayerRigitBody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);          
        }       
    }
}
