using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    //
    //摘要:
    //    計時器構成

    public float RemainingSeconds { get; private set; } //剩餘時間

    public Timer(float duration) //計時器(設定計時時間)
    {
        RemainingSeconds = duration; //剩餘時間等於設定計時時間
    }

    public event Action OnTimeEnd; //計時器歸零時 採取的動作

    public void Tick(float deltaTime) //開始計時(經過的時間)
    {
        if(RemainingSeconds == 0f) return; //計時器歸零時return

        RemainingSeconds -= deltaTime; //計時器倒數

        CheckForTimerEnd(); //檢查是否歸零
    }

    private void CheckForTimerEnd()
    {
        if(RemainingSeconds > 0f) return; //如果還未歸零 return

        RemainingSeconds = 0f; //計時器歸零或小於零 設計時器為零

        OnTimeEnd?.Invoke(); //執行預定的動作
    }
}
