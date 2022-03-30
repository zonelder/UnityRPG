using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    //�������������� ��������
    private float cooldownTime;

    //�� �������������� ��������. ����� ������ ��������� ����� ������ 
    private float remainingTime;//
    private bool isCountDown;//������� �� ������(� �� �� �����������)

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

    public void Start�ountdown()
    {
        if(isCountDown)//�� ������ ����� ���� ����� ����������� ����������� ��, ��� ��� �������������
        {
            Debug.Log("ability is not ready");
        }
        else
        {
            remainingTime = cooldownTime;
            isCountDown = true;
        }
    }
    private  void EndCountDown()//����� �������(������������ ������ ���� remaningTime ����� ������ ���� )
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
