using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoins : MonoBehaviour
{
    [SerializeField] private Text textCurrentCoins;   

    void Start() {
        textCurrentCoins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

}
