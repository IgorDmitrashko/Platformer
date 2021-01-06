using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndSound : MonoBehaviour
{
    [SerializeField] private AudioSource backGroundSound;
    [SerializeField] private AudioSource _playerAudioJump;
    [SerializeField] private AudioSource _playerAudioDeath;
    [SerializeField] private AudioSource _playerAudioCoins;
    [SerializeField] private AudioSource _playerAudioDamage;
    [SerializeField] private AudioSource _playerAudioShot;


    private void Start() {
        Player.Singleton.JumpEvent += Jump;        
        Player.Singleton.DeathEvent += DeathAudio;
        Player.Singleton.DontJumpEvent += DontJump;
        Player.Singleton.DamageSoundEvent += DamageAudio;
        Player.Singleton.ShotEvent += ShotAudio;
        Player.Singleton.PickUpCoinsEvent += CoinsAudio;
    }

    private void CoinsAudio() {
        _playerAudioCoins.Play();
    }

    private void DamageAudio() {
        _playerAudioDamage.Play();
    }

    public void DeathAudio() {
        backGroundSound.Stop();
        _playerAudioDeath.Play();
        Player.Singleton.managementAllowed = false;       
    }

    private void Jump(Animator animator) {
        animator.SetBool("IsJump", true);
        _playerAudioJump.Play();
        StartCoroutine( WaitForSeconds(0.4f, animator));
    }

    private void ShotAudio() {
        _playerAudioShot.Play();
    }

    private IEnumerator WaitForSeconds(float second, Animator animator) {             
        yield return new WaitForSeconds(second);
        DontJump(animator);
    }

    private void DontJump(Animator animator) => animator.SetBool("IsJump", false);
}
