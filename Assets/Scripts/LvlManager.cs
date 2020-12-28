using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    private int _sceneIndex;
    void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;        
    }

    public void EndLvl() {
        PlayerPrefs.SetInt("LevelComplete", ++_sceneIndex);
    }

    public void ResetProgres() {
        PlayerPrefs.DeleteKey("LevelComplete");
    }
}
