using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMeny : MonoBehaviour
{
    [SerializeField] private Button[] levels;
    private int _levelComplete;
  

    void Start() {      
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");
        levels[0].interactable = true;
        _levelComplete = 2;


        for(int i = 1; i < levels.Length; i++)
        {
            levels[i].interactable = false;
        }

        PickLvl(_levelComplete);
    }

    void PickLvl(int lvl) {
        LvlInteractable(lvl);
    }

    private void LvlInteractable(int id) {
        for(int i = 0; i < id; i++)
        {
            levels[i].interactable = true;
        }
    }
}
