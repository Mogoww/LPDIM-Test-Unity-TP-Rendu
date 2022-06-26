using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCustom : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject MenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Information()
    {
        SceneManager.LoadScene("Information");
    }

    public void LevelChoix()
    {
        SceneManager.LoadScene("LevelChoix");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
