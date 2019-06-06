using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneSwitcher sceneSwitcher;
    public bool isPaused;

    public GameObject pauseMenu;
    public GameObject youLose;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        } 
        #endregion
    }

    public void togglePaused()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
    }
    public void resetGameTime()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void stopGameTime()
    {
        Time.timeScale = 0.0f;
    }

    public void youLoseMenu()
    {
        youLose.SetActive(true);
        resetGame();
    }

    public void resetGame()
    {
        StartCoroutine(resetGameDefaults());
    }

    IEnumerator resetGameDefaults()
    {
        yield return new WaitForSeconds (3.0f);
        resetGameTime();
        sceneSwitcher.loadScene("MainMenuScene");
    }
}
