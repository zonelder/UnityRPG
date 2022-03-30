using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract  class TimedBuff
{
    
    protected float Duration;
    protected int EffectStacks;
    public ScriptableBuff Buff { get; }
    protected readonly GameObject Obj;
    public bool IsFinished;

    public string ShowDuration()
    {
       // var ts = TimeSpan.FromSeconds(Duration);
        //highscoreT.text = string.Format("{0:00}:{1:00}", (int)ts.TotalMinutes, (int)ts.Seconds);
        return System.String.Format("{0:0.0}c", Duration);
    }
    public string ShowStacks()
    {
        if (EffectStacks != 1)
            return EffectStacks.ToString();
        else return " ";
    }
    public TimedBuff(ScriptableBuff buff, GameObject obj)
    {
        Buff = buff;
        Obj = obj;
    }

    public void Tick(float delta)
    {
        Duration -= delta;
        if (Duration <= 0)
        {
            End();
            //IsFinished = true;
        }
    }

    /**
     * Activates buff or extends duration if ScriptableBuff has IsDurationStacked or IsEffectStacked set to true.
     */
    public void Activate()
    {
        if (Buff.IsEffectStacked || Duration <= 0)//эфекты стакаются
        {
            ApplyEffect();
            EffectStacks++;
        }
        if (Buff.IsDurationStacked || Duration <= 0)//стакается время
        {
            Duration += Buff.Duration;
        }
        if(!Buff.IsDurationStacked)//не стакаются ни эффекты ни время
        {
            Duration = Buff.Duration;//обновляем эффект
        }
    }
    protected abstract void ApplyEffect();
    public abstract void End();

    public virtual bool Equals(TimedBuff other)//на случай если залетит(метод будет перегружен для всех последующих классов)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            TimedBuff p = (TimedBuff)other;
            return Buff.Equals(p.Buff);
        }


    }

}