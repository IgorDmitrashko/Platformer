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
        Player.Singelton.JumpEvent += Jump;
        Player.Singelton.DontJumpEvent += DontJump;
        Player.Singelton.DeathEvent += DeathAudio;
        Player.Singelton.DamageSoundEvent += DamageAudio;
        Player.Singelton.ShotEvent += ShotAudio;
        Player.Singelton.PickUpCoinsEvent += CoinsAudio;
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
        Player.Singelton.managementAllowed = false;
        StartCoroutine(WaitForSeconds(3));
    }

    private void Jump(Animator animator) {
        animator.SetBool("IsJump", true);
        _playerAudioJump.Play();
    }

    private void ShotAudio() {
        _playerAudioShot.Play();
    }

    private IEnumerator WaitForSeconds(int second) {
        yield return new WaitForSeconds(second);
    }

    private void DontJump(Animator animator) => animator.SetBool("IsJump", false);
}
