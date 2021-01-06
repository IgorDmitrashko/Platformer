using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    private void Start() {           
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Ground") Player.Singleton._isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Ground") Player.Singleton._isGround = false;
    }  
}
