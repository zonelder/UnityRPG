using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAPBuff : TimedBuff
{
    public TimedAPBuff(float a,float b,GameObject Unit):base(new APBuff(a,b),Unit)//инициализиуем все поля этого бафа
    {
        base.Buff.Duration = 2;
        base.Buff.IsDurationStacked = false;
        base.Buff.IsEffectStacked = true;
    }
    protected override void ApplyEffect()
    {
       // ClearConsole();
       // Debug.Log("add AP buff");
        APBuff DMGBuff = (APBuff)Buff;
        BasicInfluences.ChangeDamage(Obj, DMGBuff.ExtraMinAP, DMGBuff.ExtraMaxAP);
    }
    public override void End()
    {
        // ClearConsole();
        //EffectStacks!=0 то как мы будем избавлять от кол-ва эффектов-либо все рабом уходят либо по одному.пусть в данном случае уходят все сразу
       // Debug.Log("removed AP buff");
        APBuff DMGBuff = (APBuff)Buff;
        BasicInfluences.ChangeDamage(Obj, -DMGBuff.ExtraMinAP, -DMGBuff.ExtraMaxAP);
        EffectStacks--;//строчка зменения кол-ва эфектов
        if (EffectStacks == 0)//проверка на конец
            base.IsFinished = true;
        else
            Duration = DMGBuff.Duration;
    }
    /*static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");

        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

        clearMethod.Invoke(null, null);
    }*/
    public override bool Equals(TimedBuff other)
    {
        Debug.Log("chexk on Equals in TimedAPBuffs");
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            TimedAPBuff p = (TimedAPBuff)other;
            return Buff.Equals(p.Buff);
        }
    }

}
