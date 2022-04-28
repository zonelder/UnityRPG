using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
   
    protected bool isActive=false; 
    protected Animation attackAnimation;


    /// <переменные_отвечающие_за_характеристики>
    public AttackStats property=new AttackStats();
    public Shift shift=new Shift();
    /// </переменные_отвечающие_за_характеристики>
    /// 

    public bool InUse() => isActive;
    public virtual  void StartAttack()
    {
        
        isActive = true;
        property.duration.StartСountdown();
    }

    public virtual void TickTime(float delta,float finalSpeedAmp=1)
    {
        property.duration.TickTime(delta);
        if(!shift.alreadyUsed && property.duration.curTime()>shift.startTime)// в случае если  еще не юзалос перемещение то начинаем перемещать 
        {
            shift.duration.StartСountdown();
            shift.alreadyUsed = true;
        }
        if(!shift.duration.IsReady())
        {
            shift.duration.TickTime(finalSpeedAmp*delta);
        }
    }



    public void CalculateDuration()
    {
        float shiftEndTime = shift.duration.GetCooldown() + shift.startTime;
        if (shiftEndTime > property.duration.GetCooldown())//если абилка закоччиться раньше чем дэш
        {
            float dt = shiftEndTime - property.duration.GetCooldown();
            property.duration.SetCooldown(property.duration.GetCooldown() + dt);//увеличиваем время чтобы атака кончала в упор к концу деша
        }
       
    }
    public virtual void EndAttack()
    {
        isActive = false;
        shift.alreadyUsed = false;
    }
}
