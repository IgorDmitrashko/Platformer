using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    [SerializeField] private GameObject _convas;
    private PauseMenu _pauseMenu;

    private void Start() {
        if(Player.Singelton != null)
        {
            Player.Singelton.LoadingSceneOnDeathEvent += LoadSceneDelayed;
            
        }

        if(_convas != null)
        {
            _pauseMenu = _convas.GetComponent<PauseMenu>();
            _pauseMenu.LoadMainMenuEvent += LoadScene;
            _pauseMenu.QuitGameEvent += QuitOfGame;
        }
    }

    public void QuitOfGame() {
        Application.Quit();
    }

    public void LoadSceneDelayed(int level, int delayed = 5) {
        StartCoroutine(WaithLoad(level, delayed));
    }

    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
        PauseMenu.gameIsPaused = false;
    }

    private IEnumerator WaithLoad(int level, int delayed = 5) {
        yield return new WaitForSeconds(delayed);
        SceneManager.LoadScene(level);
    }
}