using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public Player mainPlayer;

    void Start()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        mainPlayer.PlayerController.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!GameIsPaused)
            {
                Pause();
            }else
            {
                Resume();
            }
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        mainPlayer.PlayerController.SetActive(true);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        mainPlayer.PlayerController.SetActive(false);
    }
}
