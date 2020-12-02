using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Start() {

    }

    private void Spin() {
        transform.Rotate(new Vector3(0, 0, -1.5f));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    void Update() {
        Spin();
    }
}
