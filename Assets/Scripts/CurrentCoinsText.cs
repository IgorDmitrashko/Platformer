using System;
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
        Player.Singleton.PickUpCoinsEvent += AddCoins;
        CurrentNumberCoins = PlayerPrefs.GetInt("Coins");
    }  

    public void AddCoins() {
        CurrentNumberCoins ++;
        PlayerPrefs.SetInt("Coins", CurrentNumberCoins);
    }

}
