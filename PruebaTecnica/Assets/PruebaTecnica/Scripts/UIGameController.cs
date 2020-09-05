using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameController : MonoBehaviour
{
    public GameObject game1, game2, game3, particles;
    // Start is called before the first frame update
    void Start()
    {
        switch(GameManager.gameSelected)
        {
            case 1:
                game1.SetActive(true);
                break;
            case 2:
                game2.SetActive(true);
                particles.SetActive(true);
                break;
            case 3:
                game3.SetActive(true);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
