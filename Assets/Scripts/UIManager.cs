using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    protected TextMeshProUGUI answerText;

    [SerializeField]
    private GameObject SubjectScreen;
    [SerializeField]
    private GameObject LevelScreen;
    [SerializeField]
    protected GameObject SettingScreen;
    

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

    public void Setting()
    {
        SettingScreen.SetActive(true);
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
        else if (SettingScreen.activeInHierarchy)
        {
            SettingScreen.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
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
