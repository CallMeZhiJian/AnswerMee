using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : QnASystem, ScoreSystem, TimerSystem
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void CountScore()
    {

    }

    public void OnTimer()
    {

    }

    public void CountDown()
    {

    }
}
