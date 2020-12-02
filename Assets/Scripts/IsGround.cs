using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    Player player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Ground") player._isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Ground") player._isGround = false;
    }  
}
