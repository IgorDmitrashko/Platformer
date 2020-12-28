using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    [SerializeField] private GameObject _convas;

    private PauseMenu _pauseMenu;
    private int _numberNainMenu = 0;
    private int _delayedloadscene = 5;

  
    private void Start() {      
        if(Player.Singelton != null) Player.Singelton.EndGameEvent += LoadSceneDelayed;

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

    public void LoadSceneDelayed(int _delayedloadscene = 5) {
        StartCoroutine(WaithLoad(_numberNainMenu, _delayedloadscene));
    }

    public void LoadSceneDelayed() {
        StartCoroutine(WaithLoad(_numberNainMenu, _delayedloadscene));
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