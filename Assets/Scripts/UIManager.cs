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

    private void Start()
    {
        AudioManager.currDifficulty = "MainMenu";
        AudioManager.instance.PlayBGM();
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySFX("Click");
        SubjectScreen.SetActive(true);
    }

    public void SelectMath()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.currSubject = "Math";
        LevelScreen.SetActive(true);
        SubjectScreen.SetActive(false);
    }

    public void SelectEnglish()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.currSubject = "English";
        LevelScreen.SetActive(true);
        SubjectScreen.SetActive(false);
    }

    public void SelectEasy()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.currDifficulty = "Easy";
        SceneManager.LoadScene("GameScene");
    }

    public void SelectHard()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.currDifficulty = "Hard";
        SceneManager.LoadScene("GameScene");
    }

    public void Setting()
    {
        AudioManager.instance.PlaySFX("Click");
        SettingScreen.SetActive(true);
    }

    public void Back()
    {
        AudioManager.instance.PlaySFX("Click");
        if (LevelScreen != null && SubjectScreen != null)
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
        
        if(SettingScreen!= null)
        {
            if (SettingScreen.activeInHierarchy)
            {
                SettingScreen.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySFX("Click");
        Application.Quit();
    }

    public void TryAgain()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("MainMenu");
    }
}
