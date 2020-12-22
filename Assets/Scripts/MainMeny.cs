using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMeny : MonoBehaviour
{
    [SerializeField] private Button[] levels;
    [SerializeField] private LvlComplete lvlComplete;
    private int _levelComplete;
    
    void Start() {              
        levels[0].interactable = true;
        _levelComplete = lvlComplete.levelComplete;

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
