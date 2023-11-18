using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    private bool isPause;
    protected TextMeshProUGUI answerText;

    [SerializeField]
    private GameObject SubjectScreen;
    [SerializeField]
    private GameObject LevelScreen;

    public void StartGame()
    {
        SubjectScreen.SetActive(true);
    }

    public void SelectMath()
    {
        LevelScreen.SetActive(true);
        SubjectScreen.SetActive(false);
    }

    public void SelectEnglish()
    {
        LevelScreen.SetActive(true);
        SubjectScreen.SetActive(false);
    }

    public void SelectEasy()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SelectHard()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Back()
    {
        if (LevelScreen.activeInHierarchy)
        {
            LevelScreen.SetActive(false);
            SubjectScreen.SetActive(true);
        }
        else if (SubjectScreen.activeInHierarchy)
        {
            SubjectScreen.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {

    }

    public void PauseResume()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            //AudioManager
        }
        else
        {
            Time.timeScale = 0;
            //AudioManager
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
