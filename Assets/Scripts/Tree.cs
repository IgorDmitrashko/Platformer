using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    [SerializeField] private UnityEvent levelComplete;

    private void Start() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            levelComplete?.Invoke();
        }
    }
}
