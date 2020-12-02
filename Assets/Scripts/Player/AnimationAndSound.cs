using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndSound : MonoBehaviour
{
    private void Start() {
        Player.Singelton.JumpEvent += Jump;
        Player.Singelton.DontJumpEvent += DontJump;
    }

    private void Jump(Animator animator, AudioSource audio) {
        animator.SetBool("IsJump", true);
        audio.Play();
    }

    private void DontJump(Animator animator) => animator.SetBool("IsJump", false);


}
