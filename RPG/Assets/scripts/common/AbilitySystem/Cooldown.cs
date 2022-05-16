using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Cooldown
{
    //�������������� ��������
    [SerializeField]
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
    public float curTime() { return cooldownTime - remainingTime; }
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
            Debug.Log("timer is not ready");
        }
        else
        {
            remainingTime = cooldownTime;
            isCountDown = true;
        }
    }
    public void RestartCountdown()
    {
        EndCountDown();
        Start�ountdown();
    }
    private  void EndCountDown()//����� �������(������������ ������ ���� remaningTime ����� ������ ���� )
    {
        if(!isCountDown)
        {
            Debug.Log("timer is ready but there was a request to end ability");
        }
        else
        {
            remainingTime = 0;
            isCountDown = false;
        }
    }

}
