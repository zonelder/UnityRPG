using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAPBuff : TimedBuff
{
    public TimedAPBuff(float a,float b,GameObject Unit):base(new APBuff(a,b),Unit)
    {
        base.Buff.Duration = 2;
        base.Buff.IsDurationStacked = false;
        base.Buff.IsEffectStacked = true;
    }

    protected override void ApplyEffect()
    {
        APBuff DMGBuff = (APBuff)Buff;
        BasicInfluences.ChangeDamage(Obj, DMGBuff.ExtraMinAP, DMGBuff.ExtraMaxAP);
    }
    protected override void CancelEffect()
    {
        APBuff DMGBuff = (APBuff)Buff;
        BasicInfluences.ChangeDamage(Obj, -DMGBuff.ExtraMinAP, -DMGBuff.ExtraMaxAP);
    }
    public override bool Equals(TimedBuff other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            TimedAPBuff p = (TimedAPBuff)other;
            return Buff.Equals(p.Buff);
        }
    }

}
