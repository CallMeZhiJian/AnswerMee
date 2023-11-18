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
    public string answerChose;
    public bool isCorrectAnswer;
    public bool isPressed;

    //Scores
    public int score;

    //UI
    public GameObject resultScreen;

    private void Start()
    {
        _QnASystem = GetComponent<QnASystem>();

        answerChose = " ";

        _QnASystem.DisplayQuestion();
    }

    private void Update()
    {
        if (isPressed)
        {
            if(QnASystem.currID == _QnASystem.listOfQuestion.Count - 1)
            {
                resultScreen.SetActive(true);
            }
            else
            {
                isCorrectAnswer = _QnASystem.CheckAnswer(answerChose);

                if (isCorrectAnswer)
                {
                    AddScore();
                }
                QnASystem.currID++;
                _QnASystem.DisplayQuestion();
                isPressed = false;
            }        
        }
        else
        {
            return;
        }    
    }

    public void AddScore()
    {
        score++;
    }

    public void OnTimer()
    {
        
    }

    public void CountDown()
    {

    }

    public void OnPressAnswer()
    {
        isPressed = true;

        answerChose = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text;         
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
