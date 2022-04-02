using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift
{
    public bool alreadyUsed=false;
    public float startTime=0;//время от начала каста атаки когда надо начать перемещаться
    public float initialSpeed;//x=0
    public float finalSpeed;//x=shift.magnitude
    public Cooldown duration=new Cooldown(1);//расчитывается как время за которое будет пройден вектор shift и не может быть изменен извне
    private Vector3 shift;//вектор который надо пройти

    public void SetStartTime(float time) { startTime = time; }
    public float GetStartTime() { return startTime; }
    public Vector3 Get() { return shift; }
    public void Set(Vector3 value) { shift = value; }
    public Vector3 VectorOfMove(GameObject unit)
    {
        return unit.transform.forward*shift.z +unit.transform.right * shift.x + unit.transform.up * shift.y;
    }
    public float VelocityAt(float time)
    {
        return ((finalSpeed - initialSpeed) / duration.GetCooldown() * time + initialSpeed);//линейнай зависимость
    }
    public float Velocity()//использует время с момента анчала отсчета 
    {
        return ((finalSpeed - initialSpeed) / duration.GetCooldown() * duration.curTime() + initialSpeed);//линейнай зависимость
    }
    public void SetSpeed(float startSpeed, float endSpeed)
    {
        initialSpeed = startSpeed;
        finalSpeed = endSpeed;
    }
    public void RecalculateDuration()
    {
        float path = shift.magnitude;
        float avrVelocity = (finalSpeed + initialSpeed) / 2;//работает только если скорость изменяется линейно от начала до конца
        duration.SetCooldown(path / avrVelocity);
    }

    public Shift() { }

}
