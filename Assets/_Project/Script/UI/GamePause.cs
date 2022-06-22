using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSubjectCode
{
    public class GamePause : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject PauseMenuUI;

        void Start()
        {
            PauseMenuUI.SetActive(false);
            GameIsPaused = false;
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
        }

        void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}
