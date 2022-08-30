using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.P)) || (Input.GetKeyDown(KeyCode.Escape)))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void LevelSelect()
    {
        Resume();
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
