using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoinsText : MonoBehaviour
{
    [SerializeField]
    private Text textCurrentCoins;

    public int CurrentNumberCoins
    {
        get { return Convert.ToInt32(textCurrentCoins.text); }
        set { textCurrentCoins.text = value.ToString(); }
    }

    private void Start() {
       Player.Singelton.PickUpCoinsEvent += AddCoins;
    }

    public void AddCoins(AudioSource audio) {
        CurrentNumberCoins += 1;
    }
 
}
