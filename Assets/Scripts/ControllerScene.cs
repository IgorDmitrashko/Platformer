using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    public void LoadScene(int level) {
        StartCoroutine(WaithLoad(level));        
    }
    public IEnumerator WaithLoad(int level) {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(level);
    }

}
