using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedHPBuff : TimedBuff
{
    public TimedHPBuff(float ExtraHP, GameObject Unit):base(new HPBuff(ExtraHP),Unit)
    {
        base.Buff.Duration = 5;
        base.Buff.IsDurationStacked = false;
        base.Buff.IsEffectStacked = false;
    }
    protected override void ApplyEffect()
    {
        HPBuff _Buff = (HPBuff)Buff;
        BasicInfluences.ChangeHP(Obj, _Buff.ExtraHP);
    }
    public override void End()
    {
        HPBuff _Buff = (HPBuff)Buff;
        BasicInfluences.ChangeHP(Obj,-_Buff.ExtraHP);
        EffectStacks = 0;
        if(EffectStacks==0)
        base.IsFinished = true;
    }

    public override bool Equals(TimedBuff other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            TimedHPBuff p = (TimedHPBuff)other;
            return Buff.Equals(p.Buff);
        }
    }
}
