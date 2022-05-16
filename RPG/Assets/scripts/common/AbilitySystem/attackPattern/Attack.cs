using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Attack
{
   
    private bool isActive=false; 

    /// <переменные_отвечающие_за_характеристики>
    public AttackStats Property=new AttackStats();
    public Shift Shift=new Shift();
    /// </переменные_отвечающие_за_характеристики>

    public bool InUse() => isActive;
    public virtual  void StartAttack()
    {
        
        isActive = true;
        Property.Duration.StartСountdown();
    }

    public virtual void TickTime(float delta,float finalSpeedAmp=1)
    {
        Property.Duration.TickTime(delta);
        if(!Shift.AlreadyUsed && Property.Duration.curTime()>Shift.StartTime())
        {
            // В случае если  еще не юзалос перемещение то начинаем перемещать. 
            Shift.Duration.StartСountdown();
            Shift.AlreadyUsed = true;
        }
        if(!Shift.Duration.IsReady())
        {
            Shift.Duration.TickTime(finalSpeedAmp*delta);
        }
    }



    public void RecalculateDuration()
    {
        float shiftEndTime = Shift.Duration.GetCooldown() + Shift.StartTime();
        if (shiftEndTime > Property.Duration.GetCooldown())
        {
            float dt = shiftEndTime - Property.Duration.GetCooldown();
            Property.Duration.SetCooldown(Property.Duration.GetCooldown() + dt);
            // Увеличиваем время чтобы атака кончала в упор к концу деша.
        }

    }
    public virtual void EndAttack()
    {
        isActive = false;
        Shift.AlreadyUsed = false;
    }
}
