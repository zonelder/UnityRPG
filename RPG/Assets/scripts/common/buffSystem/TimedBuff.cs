using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract  class TimedBuff
{
    
    protected float Duration;
    protected int EffectStacks;
    public  ScriptableBuff Buff { get; }
    protected readonly GameObject Obj;
    protected  bool IsFinished;

    public string ShowDuration()
    {
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
        }
    }
    public void Activate()
    {
        if (Buff.IsEffectStacked || Duration <= 0)
        {
            ApplyEffect();
            EffectStacks++;
        }
        if (Buff.IsDurationStacked || Duration <= 0)
        {
            Duration += Buff.Duration;
        }
        if(!Buff.IsDurationStacked)
        {
            Duration = Buff.Duration;
        }
    }
    protected abstract void ApplyEffect();
    public abstract void End();

    public virtual bool Equals(TimedBuff other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            TimedBuff p = (TimedBuff)other;
            return Buff.Equals(p.Buff);
        }


    }

    public bool Finished() => IsFinished;

}