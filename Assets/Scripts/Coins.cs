using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    UpdateEventGame updateCoins;

    private void Awake() {
        updateCoins = GameObject.FindGameObjectWithTag("UpdateEventGame").GetComponent<UpdateEventGame>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {          
            updateCoins.UpdateConfigeration();
            Destroy(gameObject);
        }
    }
   
}
