using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            SlowSpeedMovement(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            NormalSpeedMovement(player);
        }
    }

    private void NormalSpeedMovement(Player player) {
        player.Speed *= 2;
    }

    private void SlowSpeedMovement(Player player) {
        player.Speed /= 2;
    }

}
