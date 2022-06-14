using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void BuffEvent();
public abstract  class TimedBuff
{
    //protected fields/ надо переделать под приватные
    public event BuffEvent OnApplyEffect;
    public event BuffEvent OnCancelEffect;
    public event BuffEvent OnEndBuff;
    public  float Duration
    {
        get;
        private set;
    }
    public  int EffectStacks
    {
        get;
        private set;
    }
    public  ScriptableBuff Buff { get; }
    protected readonly GameObject Obj;
    public bool IsFinished
    {
        get
        {
            return EffectStacks <= 1 && Duration <= 0;
        }
    }
    public TimedBuff(ScriptableBuff buff, GameObject obj)
    {
        Buff = buff;
        Obj = obj;
        EffectStacks =0;
    }

    public void Tick(float delta)
    {
        Duration -= delta;
        if (Duration <= 0)
        {
            Deactivale();
        }
    }
    public void Activate()
    {
        if (Buff.IsEffectStacked)
        {
            ApplyEffect();
            OnApplyEffect?.Invoke();
            EffectStacks++;
        }
        if (Buff.IsDurationStacked)
        {
            Duration += Buff.Duration;
        }
        if(!Buff.IsDurationStacked)
        {
            Duration = Buff.Duration;
        }
    }
    public void Deactivale()
    {
        EffectStacks--;
        CancelEffect();
        if (EffectStacks==0)
        {
            OnEndBuff?.Invoke();
        }
        else
        {
            Duration = Buff.Duration;
            OnCancelEffect?.Invoke();
        }
    }
    protected  abstract void ApplyEffect();
    protected abstract void CancelEffect();
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