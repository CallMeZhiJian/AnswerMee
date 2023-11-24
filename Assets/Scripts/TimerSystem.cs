using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface TimerSystem
{
    public static float timer = 30;
    public static int seconds;

    public void StartTimer();

    public void ResetTimer();

    public void CalTimeUsage();

    public void UpdateTimeFormat();
}
