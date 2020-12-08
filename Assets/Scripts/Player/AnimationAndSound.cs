using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndSound : MonoBehaviour
{
    [SerializeField] private AudioSource backGroundSound;

    private void Start() {
        Player.Singelton.JumpEvent += Jump;
        Player.Singelton.DontJumpEvent += DontJump;
        Player.Singelton.DeathEvent += DeathAudio;
        Player.Singelton.DamageSoundEvent += DamageAudio;
        Player.Singelton.ShotEvent += ShotAudio;
        Player.Singelton.PickUpCoinsEvent += CoinsAudio;

    }

    private void CoinsAudio(AudioSource audio) {
        audio.Play();
    }

    private void DamageAudio(AudioSource audio) {
        audio.Play();
    }

    public void DeathAudio(AudioSource audio) {
        backGroundSound.Stop();
        audio.Play();
        Player.Singelton.managementAllowed = false;
        StartCoroutine(WaitForSeconds(3));
    }

    private void Jump(Animator animator, AudioSource audio) {
        animator.SetBool("IsJump", true);
        audio.Play();
    }

    private void ShotAudio(AudioSource audio) {
        audio.Play();
    }

    private IEnumerator WaitForSeconds(int second) {
        yield return new WaitForSeconds(second);
    }

    private void DontJump(Animator animator) => animator.SetBool("IsJump", false);
}
