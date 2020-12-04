using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{

    private void Start() {
        Player.Singelton.LoadingSceneOnDeathEvent += LoadSceneDelayed;
    }



    public void LoadSceneDelayed(int level, int delayed = 5) {
        StartCoroutine(WaithLoad(level,delayed));
    }

    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }

    private IEnumerator WaithLoad(int level,int delayed = 5) {
        yield return new WaitForSeconds(delayed);
        SceneManager.LoadScene(level);

    }
}