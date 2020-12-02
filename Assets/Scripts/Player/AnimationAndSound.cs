using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndSound : MonoBehaviour
{
    private void Start() {
        Player.Singelton.JumpEvent += Jump;
    }
    private void Jump(Animator animator) {
        animator.SetBool("IsJump", true);
    }
}
