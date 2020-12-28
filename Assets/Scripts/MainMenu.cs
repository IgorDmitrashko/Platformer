using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] levels;

    private int _levelComplete;

    void Start() {
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");

        for(int i = 1; i < levels.Length; i++)
        {
            levels[i].interactable = false;
        }

        PickLvl(_levelComplete);
    }

    public void PickLvl(int lvl) {
        LvlInteractable(lvl);
    }

    private void LvlInteractable(int id) {
        for(int i = 0; i < id; i++)
        {          
            levels[i].interactable = true;
        }
    }
}
