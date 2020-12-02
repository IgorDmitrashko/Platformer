using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D _pLayerRigitBody2D;
    private Animator _playerAnimator;

    private Material _materialBlick;
    private Material _materialDefault;
    private SpriteRenderer _spriteRend;

    [Header("Player movement speed")]
    [SerializeField] private float speed = 2.0f;

    [Header("Jump force")]
    [SerializeField] private float _jumpForce = 1.0f;

    [NonSerialized] private HealthPlayerControl _health;

    private SpriteRenderer _playerSpriteRenderer;

    public static Player Singelton { get; private set; }

    public event Action<int> TakeHeatPoint;
    public event Action Death;
    public event Action<Animator> JumpEvent;

    public bool _isGround;


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
            _playerAnimator.SetBool("IsJump", true);
            Jump();
        }
        else
        {
            _playerAnimator.SetBool("IsJump", false);
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
            Death?.Invoke();
            SceneManager.LoadScene("MainMeny");
        }
        Twinkle();
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
        JumpEvent?.Invoke(_playerAnimator);
    }
}
