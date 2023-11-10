using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TimerSystem
{
    public static float timer = 60;

    public void OnTimer();

    public void CountDown();
}
