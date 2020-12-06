using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Action<int> LoadMainMenuEvent;
   
    public static bool gameIsPaused = false;
    [SerializeField] private GameObject _pauseMenuUi;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume() {
        _pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause() {
        _pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMainMenu(int numberScene = 0) {
        Time.timeScale = 1f;
        LoadMainMenuEvent?.Invoke(numberScene);
    }

    public void QuitGame() {
        Application.Quit();        
    }
}
