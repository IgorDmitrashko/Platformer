using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoinsText : MonoBehaviour
{
    [SerializeField]
    private Text textCurrentCoins;
    [SerializeField] private PointSave point;

    public int CurrentNumberCoins
    {
        get { return Convert.ToInt32(textCurrentCoins.text); }
        set { textCurrentCoins.text = value.ToString(); }
    }

    private void Start() {
        if(point != null) CurrentNumberCoins = point.point;
        Player.Singelton.PickUpCoinsEvent += AddCoins;
    }  

    public void AddCoins() {
        CurrentNumberCoins += 1;
        point.point = CurrentNumberCoins;
    }

}
