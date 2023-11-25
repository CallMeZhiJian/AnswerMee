using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : UIManager, ScoreSystem, TimerSystem
{
    private QnASystem _QnASystem;

    //indicator
    private string answerChose = " ";
    private bool isCorrectAnswer;
    private bool isPressed;
    private bool isPause;
    private float timer;
    private float timeUsed;

    //UI
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI usedTimeText;
    [SerializeField]
    private GameObject resultScreen;
    [SerializeField]
    private GameObject pauseScreen;

    private void Start()
    {
        Time.timeScale = 1;

        AudioManager.instance.PlayBGM();

        _QnASystem = GetComponent<QnASystem>();
        
        isPause = false;

        answerChose = " ";

        ScoreSystem.score = 0;

        timeUsed = 0;

        _QnASystem.DisplayQuestion();

        ResetTimer();
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

        if (QnASystem.currID == _QnASystem.listOfQuestion.Count)
        {
            scoreText.text = "Score: \n" + ScoreSystem.score + "/" + _QnASystem.listOfQuestion.Count;
            UpdateTimeFormat();
            resultScreen.SetActive(true);
        }
        else
        {
            if(timer <= 0)
            {
                isPressed = true;
            }
            else
            {
                StartTimer();
            }
            CalTimeUsage();
        }

        if (isPressed)
        {
            isCorrectAnswer = _QnASystem.CheckAnswer(answerChose);

            if (isCorrectAnswer)
            {
                AddScore();
            }
            else
            {
                AudioManager.instance.PlaySFX("Incorrect");
            }
            QnASystem.currID++;
            _QnASystem.DisplayQuestion();
            ResetTimer();
            isPressed = false;
        }
        else
        {
            return;
        }    
    }

    public void AddScore()
    {
        AudioManager.instance.PlaySFX("Correct");
        ScoreSystem.score++;
    }

    public void StartTimer()
    {
        Mathf.Clamp(timer, 0f, 60f);
        timer -= Time.deltaTime;
        int seconds = ((int)(timer % 60));
        timerText.text = seconds.ToString();
    }

    public void ResetTimer()
    {
        timer = TimerSystem.timer;
    }

    public void CalTimeUsage()
    {
        timeUsed += Time.deltaTime;
    }

    public void UpdateTimeFormat()
    {
        float minutes = Mathf.FloorToInt(timeUsed / 60);
        float seconds = Mathf.FloorToInt(timeUsed % 60);

        usedTimeText.text = "Time: \n" + minutes + ":" + seconds;
    }

    public void OnPressAnswer()
    {
        AudioManager.instance.PlaySFX("Click");
        isPressed = true;

        answerChose = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text;         
    }

    public void PauseResume()
    {
        AudioManager.instance.PlaySFX("Click");
        if (isPause)
        {
            pauseScreen.SetActive(false);
            isPause = false;
            Time.timeScale = 1;
            //AudioManager  
        }
        else
        {
            pauseScreen.SetActive(true);
            isPause = true;
            Time.timeScale = 0;
            //AudioManager
            
        }
    }

    public new void Setting()
    {
        AudioManager.instance.PlaySFX("Click");
        SettingScreen.SetActive(true);
    }

    //void Shuffle<T>(List<T> shuffleNum)
    //{
    //    for (int i = 0; i < shuffleNum.Count - 1; i++)
    //    {
    //        T temp = shuffleNum[i];
    //        int rand = Random.Range(i, shuffleNum.Count);
    //        shuffleNum[i] = shuffleNum[rand];
    //        shuffleNum[rand] = temp;
    //    }
    //}
}
