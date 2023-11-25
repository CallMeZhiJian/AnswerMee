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
    [SerializeField]
    protected TextMeshProUGUI onOffBGMText;
    [SerializeField]
    protected TextMeshProUGUI onOffSFXText;

    private void Start()
    {
        AudioManager.instance.currDifficulty = "MainMenu";
        AudioManager.instance.PlayBGM();
    }

    private void Update()
    {
        if (AudioManager.instance._BGMSource.mute)
        {
           onOffBGMText.text = "Off";
        }
        else
        {
            onOffBGMText.text = "On";
        }

        if (AudioManager.instance._SFXSource.mute)
        {
            onOffSFXText.text = "Off";
        }
        else
        {
            onOffSFXText.text = "On";
        }
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySFX("Click");
        SubjectScreen.SetActive(true);
    }

    public void SelectMath()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.instance.currSubject = "Math";
        LevelScreen.SetActive(true);
        SubjectScreen.SetActive(false);
    }

    public void SelectEnglish()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.instance.currSubject = "English";
        LevelScreen.SetActive(true);
        SubjectScreen.SetActive(false);
    }

    public void SelectEasy()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.instance.currDifficulty = "Easy";
        SceneManager.LoadScene("GameScene");
    }

    public void SelectHard()
    {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.instance.currDifficulty = "Hard";
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

    public void ToggleMuteUnMuteBGM()
    {
        AudioManager.instance.PlaySFX("Click");
        if (AudioManager.instance._BGMSource.mute)
        {
            AudioManager.instance._BGMSource.mute = false;
        }
        else
        {
            AudioManager.instance._BGMSource.mute = true;
        }
    }

    public void ToggleMuteUnMuteSFX()
    {
        AudioManager.instance.PlaySFX("Click");
        if (AudioManager.instance._SFXSource.mute)
        {
            AudioManager.instance._SFXSource.mute = false;
        }
        else
        {
            AudioManager.instance._SFXSource.mute = true;
        }
    }
}
