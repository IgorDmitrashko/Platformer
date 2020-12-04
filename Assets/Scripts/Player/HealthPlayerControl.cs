﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExcludeFromObjectFactory]
public class HealthPlayerControl : MonoBehaviour
{
    HealthPlayer healthPlayer;
    public int hp;

    private void Start() {
        healthPlayer = GetComponent<HealthPlayer>();
        
        Player.Singelton.TakeHeatPoint += TakeHp;
        Player.Singelton.DeathEvent += Fill;

    }

    private void Fill(AudioSource audio) {
        if(healthPlayer != null)
        {
            for(int i = 0; i < hp; i++)
            {
                healthPlayer.lives[i].SetActive(true);
            }
            hp = 3;
        }

    }

    public void TakeHp(int damage) {
        if(healthPlayer != null)
        {
            healthPlayer.lives[hp - 1].SetActive(false);
            hp -= damage;
        }

    }
}
