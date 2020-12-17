using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    [SerializeField] private UnityEvent levelComplete;
    AudioSource AudioSource;
    private void Start() {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
           //Player player =  collision.gameObject.GetComponent<Player>(); Невозможность движения, но не хочется делать, поле паблик
            

            AudioSource.Play();
            levelComplete?.Invoke();
        }
    }
}
