using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
