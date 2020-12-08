using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _heals = 2;


    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(int damage) {
        _heals -= damage;
        if(_heals <= 0)
        {
            Death();
        }
    }

    private void Death() {
        Destroy(gameObject);
    }
}
