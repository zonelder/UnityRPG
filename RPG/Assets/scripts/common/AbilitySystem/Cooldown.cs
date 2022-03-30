using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    //модифицируемой значение
    private float cooldownTime;

    //не модифицируемые значения. пусть нельзя уменьшать время отката 
    private float remainingTime;//
    private bool isCountDown;//ведется ли отсчет(в кд ли способность)

    public Cooldown(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
        remainingTime = 0;
        isCountDown = false;
    }
    public float GetCooldown() { return cooldownTime; }
    public void  SetCooldown(float value) { cooldownTime = value; }
    public bool IsReady()
    {
        return !isCountDown;
    }
    public void TickTime(float delta)
    {
        remainingTime -= delta;
        if (remainingTime <= 0)
        {
            EndCountDown();
        }
    }

    public void StartСountdown()
    {
        if(isCountDown)//на случай еесли юзер будет запрашивать активироваь то, что уже активинованно
        {
            Debug.Log("ability is not ready");
        }
        else
        {
            remainingTime = cooldownTime;
            isCountDown = true;
        }
    }
    private  void EndCountDown()//конец отсчета(оспользуется только если remaningTime стало меньше нуля )
    {
        if(!isCountDown)
        {
            Debug.Log("ability is ready but there was a request to end ability");
        }
        else
        {
            remainingTime = 0;
            isCountDown = false;
        }
    }

}
