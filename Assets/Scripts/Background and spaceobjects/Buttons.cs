using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public Button PlayButton;
    public Button QuitButton;
    //public GameObject Background;


	void Start ()
    {
        PlayButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(QuitGame);
    }
    
    void PlayGame()
    {
        Pause();
    }

    void QuitGame()
    {
        Application.Quit();
    }

    private void Pause()
    {
        if (!PlayerStateInput.gamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        PlayerStateInput.gamePaused = !PlayerStateInput.gamePaused;
        gameObject.SetActive(PlayerStateInput.gamePaused);
    }


}
