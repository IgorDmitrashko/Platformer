using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoinsText : MonoBehaviour
{
    [SerializeField]
    private Text textCurrentCoins;

    private UpdateEventGame updateEventGame;

    public int CurrentNumberCoins
    {
        get { return Convert.ToInt32(textCurrentCoins.text); }
        set { textCurrentCoins.text = value.ToString(); }
    }
    
    private void Awake() {
        updateEventGame = GameObject.FindGameObjectWithTag("UpdateEventGame").GetComponent<UpdateEventGame>();
       // updateEventGame.CoinsChanged += AddCoins;
    }   
    public void AddCoins() {
        CurrentNumberCoins ++;
    }

}
