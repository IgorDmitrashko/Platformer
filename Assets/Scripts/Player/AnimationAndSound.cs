using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndSound : MonoBehaviour
{
    private void Start() {
        Player.Singelton.JumpEvent += Jump;
        Player.Singelton.DontJumpEvent += DontJump;
        Player.Singelton.DeathEvent += PlayerDeathAudio;
    }

    public void PlayerDeathAudio(AudioSource audio) {
        StartCoroutine(WaitForSeconds(3));
        audio.Play();
    }

    private void Jump(Animator animator, AudioSource audio) {
        animator.SetBool("IsJump", true);
        audio.Play();
    }

    private IEnumerator WaitForSeconds(int second) {
        yield return new WaitForSeconds(second);       
    }
    private void DontJump(Animator animator) => animator.SetBool("IsJump", false);


}
