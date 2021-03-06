﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{
    [SerializeField] private UnityEvent levelComplete;   
    AudioSource AudioSource;

    private void Start() {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            AudioSource.Play();
            levelComplete?.Invoke();            
        }
    }
}
