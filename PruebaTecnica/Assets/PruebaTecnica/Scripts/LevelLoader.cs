using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public float secondsToWait;
    public Slider progressBar;
    public int sceneToLoad;

    private float remainingSeconds = 0;
    // Start is called before the first frame update
    void Start()
    {       
        LoadLevel(secondsToWait);
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingSeconds < secondsToWait)
        {
            float progress = remainingSeconds;
            progressBar.value = progress;
            remainingSeconds += Time.deltaTime;

        }
    }

    public void LoadLevel(float p_secondsToWait)
    {
        StartCoroutine(LoadAsyn(p_secondsToWait));
    }

    public IEnumerator LoadAsyn(float p_secondsToWait)
    {
        //remainingSeconds = secondsToWait;
        yield return new WaitForSeconds(p_secondsToWait);
        SceneManager.LoadScene(sceneToLoad);
    }
}
