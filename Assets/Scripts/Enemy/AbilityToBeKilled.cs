using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityToBeKilled : MonoBehaviour
{
    public GameObject enemy;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "AbilityToKill")
        {
            Destroy(enemy);
        }
    }
     
}
