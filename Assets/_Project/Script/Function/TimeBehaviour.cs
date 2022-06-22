using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeBehaviour : MonoBehaviour
{
    //
    //摘要:
    //    讓物件擁有計時器功能的組件，需要放在物件上

    [SerializeField] private float duration = 1f; //設定計時器時間
    [SerializeField] private UnityEvent onTimeEnd = null; //設定計時器歸零時所採取的動作

    private Timer timer; //新建計時器

    private void Start()
    {
        timer = new Timer(duration); //設定計時器時間

        timer.OnTimeEnd += HandleTimerEnd; //當OnTimeEnd發生時 執行HandleRimerEnd
    }

    private void Update() 
    {
        timer.Tick(Time.deltaTime); //開始計時
    }

    private void HandleTimerEnd()
    {
        onTimeEnd.Invoke(); //開始執行事件

        Destroy(this); //摧毀這個組件(TimeBehaviour)
    }    
}
